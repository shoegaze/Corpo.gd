using System;
using System.IO;

using Corpo.Scripts.Services.Core;

using Godot;

using QuickType;

namespace Corpo.Scripts.Services.Environment;

// ReSharper disable once ClassNeverInstantiated.Global
public class EnvironmentService : Service {
  public enum EnvironmentMode {
    Development,
    Production
  }

  // Can't be injected since this is a root* service
  private const string environmentFileNamePrefix = "environment";
  private const string environmentFileNameExtension = "json";

  // private readonly LoggingService loggingService;
  //
  // public EnvironmentService(
  //   LoggingService loggingService
  // ) {
  //   this.loggingService = loggingService;
  // }

  public EnvironmentJson Environment { get; private set; }

  private static string MapEnvironmentModeToFileNameFragment(EnvironmentMode mode) {
    return mode switch {
      EnvironmentMode.Development => "dev",
      EnvironmentMode.Production => "prod",
      _ => throw new Exception($"Environment mode '{mode}' not supported")
    };
  }

  public void LoadEnvironment(string rootPath, EnvironmentMode mode) {
    string modeName = MapEnvironmentModeToFileNameFragment(mode);

    string fullFileName =
        $"{environmentFileNamePrefix}.{modeName}.{environmentFileNameExtension}";

    string fullFilePath = Path.Combine(rootPath, fullFileName);

    // TODO: Use LoggerService.Info(...)
    GD.Print("Loading environment file ...");
    GD.Print($" * {fullFilePath}");

    using var reader = new StreamReader(fullFilePath);
    string jsonString = reader.ReadToEnd();

    // TODO(spike): Validate JSON object from schema
    Environment = EnvironmentJson.FromJson(jsonString);

    // TODO: Use LoggerService.Info(...)
    GD.Print("> Complete!");
  }
}
