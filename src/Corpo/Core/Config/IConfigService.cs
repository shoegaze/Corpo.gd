using TeamSports.Services;

using ConfigJson = Corpo.Generated.Json.Config.Config;


namespace Corpo.Core.Config;


public interface IConfigService : IService, IStartable {
  ConfigJson ConfigVars { get; }
}
