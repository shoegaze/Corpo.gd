using TeamSports.Core.Game;

using ConfigJson = Corpo.Generated.Json.Config.Config;


namespace Corpo._Core.Config;


public interface IConfigService : IStartable {
  ConfigJson ConfigVars { get; }
}
