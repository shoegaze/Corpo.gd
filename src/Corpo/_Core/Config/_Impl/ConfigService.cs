using System.IO;

using Corpo._Core.Environments;
using Corpo.Adapters.TeamSports.Logging;

using Godot;

using ConfigJson = Corpo.Generated.Json.Config.Config;


namespace Corpo._Core.Config._Impl;


public sealed class ConfigService(
  ILogger logger,
  IEnvironmentService environmentService
) : IConfigService {
  public ConfigJson ConfigVars { get; private set; } = null!;

  public void Start() {
    string varsRoot = environmentService.EnvironmentVars.Path.Assets.Vars;
    string configPath = environmentService.EnvironmentVars.Path.File.Var.Config;

    { // TODO: Refactor into FileService.LoadVarFile
      string filePath = Path.Combine(varsRoot, configPath);

      logger.Info("Loading config file ...");
      logger.Debug($"> {filePath}");

      string globalFilePath = ProjectSettings.GlobalizePath(filePath);

      using var reader = new StreamReader(globalFilePath);
      string jsonString = reader.ReadToEnd();

      ConfigVars = ConfigJson.FromJson(jsonString);

      logger.Info("> Complete!");
    }
  }
}
