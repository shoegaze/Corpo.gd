using System.IO;

using Corpo.Core.Environments.Helpers;
using Corpo.Core.Environments.Models;

using Godot;

using TeamSports.Logging;

using EnvironmentJson = Corpo.Generated.Json.Environment.Environment;


namespace Corpo.Core.Environments._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class EnvironmentService(
  ILogger logger
) : IEnvironmentService {
  private const string EnvRoot = "res://";

  public EnvironmentMode Mode => EnvironmentHelper.GetEnvironmentMode();
  public EnvironmentJson EnvironmentVars { get; private set; } = null!;

  public void Start() {
    string envName = EnvironmentHelper.GetEnvironmentModeAsName();
    var fileName = $".env.{envName}.json";

    { // TODO: Refactor into FileService.LoadEnvFile
      string filePath = Path.Combine(EnvRoot, fileName);

      logger.Info("Loading environment file ...");
      logger.Debug($"> {filePath}");

      string globalFilePath = ProjectSettings.GlobalizePath(EnvRoot);

      using var reader = new StreamReader(globalFilePath);
      string jsonString = reader.ReadToEnd();

      EnvironmentVars = EnvironmentJson.FromJson(jsonString);

      logger.Info("> Complete!");
    }
  }
}
