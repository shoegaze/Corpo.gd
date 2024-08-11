using System;
using System.IO;

using Corpo.Services.Core;
using Corpo.Services.Environment.Models;

using Godot;

using QuickType;

namespace Corpo.Services.Environment;

// ReSharper disable once ClassNeverInstantiated.Global
public class EnvironmentService : Service {
  // Can't be injected since this is a root* service
  private const string environmentFileNamePrefix = "environment";
  private const string environmentFileNameExtension = "json";

  public const EnvironmentMode Mode =
#if DEBUG
      EnvironmentMode.Development;

  // TODO(shoegaze): Pre environment mode
  // #elif PREPRODUCTION
  //       EnvironmentMode.Preproduction;

  // TODO(shoegaze): #elif RELEASE for production mode
#else 
      EnvironmentMode.Production;
#endif

  // TODO(shoegaze): Refactor into SettingsService
  public EnvironmentJson Environment { get; private set; }

  private static string MapEnvironmentModeToFileNameFragment(EnvironmentMode mode) {
    return mode switch {
      EnvironmentMode.Development => "dev",
      // TODO(shoegaze): Pre environment mode
      // EnvironmentMode.Pre => "pre",
      EnvironmentMode.Production => string.Empty,
      _ => throw new ArgumentOutOfRangeException(
             nameof(mode),
             $"Environment mode '{mode}' not supported")
    };
  }

  public void Initialize(string rootPath) {
    string modeName = MapEnvironmentModeToFileNameFragment(Mode);

    string fullFileName =
        $"{environmentFileNamePrefix}.{modeName}.{environmentFileNameExtension}";

    string fullFilePath = Path.Combine(rootPath, fullFileName);

    // TODO: Use LoggerService.Info(...)
    GD.Print("Loading environment file ...");
    GD.Print($" * {fullFilePath}");

    using var reader = new StreamReader(fullFilePath);
    string jsonString = reader.ReadToEnd();

    // TODO(shoegaze): Validate JSON object from schema
    Environment = EnvironmentJson.FromJson(jsonString);

    // TODO: Use LoggerService.Info(...) after this#Initialize() ... Store context info?
    GD.Print("> Complete!");
  }
}
