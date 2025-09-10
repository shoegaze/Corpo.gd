using Corpo.Adapters.TeamSports.Game;

using ConfigJson = Corpo.Generated.Json.Config.Config;


namespace Corpo.Core.Config;


public interface IConfigService : IStartable {
  ConfigJson ConfigVars { get; }
}
