using System;
using System.IO;

using Godot;

using Environment = Corpo.Generated.Json.Environment.Environment;
using EnvironmentMode =
    Corpo.Base.Environments.Models.Environment.EnvironmentMode;


namespace Corpo.Base.Environments;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class EnvironmentService : IEnvironmentService {
  public EnvironmentMode Mode => Models.Environment.GetEnvironmentMode();


  // TODO: Refactor into SettingsService
  public Environment Environment { get; private set; }


  public void Start() {
    string modeName = MapEnvironmentModeToFileNameFragment(Mode);
    var fullFileName = $".env.{modeName}.json";

    string rootPath = ProjectSettings.GlobalizePath("res://");
    string fullFilePath = Path.Combine(rootPath, fullFileName);

    // TODO: Use LoggerService.Info(...)
    GD.Print("Loading environment file ...");
    GD.Print($" * {fullFilePath}");

    using var reader = new StreamReader(fullFilePath);
    string jsonString = reader.ReadToEnd();

    // TODO: Validate JSON object from schema
    Environment = Environment.FromJson(jsonString);

    // TODO: Use LoggerService.Info(...) after this#Initialize() ... Store context info?
    GD.Print("> Complete!");
  }

  private static string MapEnvironmentModeToFileNameFragment(
    EnvironmentMode mode
  ) {
    return mode switch {
      EnvironmentMode.Development => "dev",
      EnvironmentMode.Staging => "stg",
      EnvironmentMode.Production => "prod",
      _ => throw new ArgumentOutOfRangeException(
        nameof(mode),
        $"Environment mode '{mode}' not supported")
    };
  }
}
