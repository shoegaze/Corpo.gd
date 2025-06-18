using System;
using System.IO;

using Engine;

using Godot;

using Environment = Corpo.Generated.Json.Environment.Environment;
using EnvironmentMode =
    Corpo.Base.Environments.Models.Environment.EnvironmentMode;


namespace Corpo.Base.Environments.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class EnvironmentService(
  ILogger logger
) : IEnvironmentService {
  public EnvironmentMode Mode => Models.Environment.GetEnvironmentMode();


  // TODO: Refactor into SettingsService
  public Environment Environment { get; private set; }


  public void Start() {
    string modeName = MapEnvironmentModeToFileNameFragment(Mode);
    var fullFileName = $".env.{modeName}.json";

    string rootPath = ProjectSettings.GlobalizePath("res://");
    string fullFilePath = Path.Combine(rootPath, fullFileName);

    logger.Info("Loading environment file ...");
    logger.Debug($" * {fullFilePath}");

    using var reader = new StreamReader(fullFilePath);
    string jsonString = reader.ReadToEnd();

    Environment = Environment.FromJson(jsonString);

    logger.Info("> Complete!");
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
