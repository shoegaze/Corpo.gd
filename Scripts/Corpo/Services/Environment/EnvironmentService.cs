using System;
using System.IO;

using Corpo.Services.Core;

using Godot;

using EnvironmentMode = Corpo.Services.Environment.Models.Environment.EnvironmentMode;
using Json = Corpo.Generated.Json;


namespace Corpo.Services.Environment;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class EnvironmentService : Service {
  public readonly EnvironmentMode Mode = 
      Models.Environment.GetEnvironmentMode();
  
  // TODO(shoegaze): Refactor into SettingsService
  public Json.Environment.Environment Environment { get; private set; }

  
  private static string MapEnvironmentModeToFileNameFragment(EnvironmentMode mode) {
    return mode switch {
      EnvironmentMode.Development => "dev",
      EnvironmentMode.Staging => "stg",
      EnvironmentMode.Production => "prod",
      _ => throw new ArgumentOutOfRangeException(
            nameof(mode),
            $"Environment mode '{mode}' not supported"
          )
    };
  }

  public void Initialize(string rootPath) {
    string modeName = MapEnvironmentModeToFileNameFragment(Mode);
    string fullFileName = $"env.{modeName}.json";

    string fullFilePath = Path.Combine(rootPath, fullFileName);

    // TODO: Use LoggerService.Info(...)
    GD.Print("Loading environment file ...");
    GD.Print($" * {fullFilePath}");

    using var reader = new StreamReader(fullFilePath);
    string jsonString = reader.ReadToEnd();

    // TODO(shoegaze): Validate JSON object from schema
    Environment = Json.Environment.Environment.FromJson(jsonString);

    // TODO: Use LoggerService.Info(...) after this#Initialize() ... Store context info?
    GD.Print("> Complete!");
  }
}
