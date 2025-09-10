using Corpo.Adapters.TeamSports.Game;
using Corpo.Core.Environments.Models;

using Environment = Corpo.Generated.Json.Environment.Environment;


namespace Corpo.Core.Environments;


public interface IEnvironmentService : IStartable {
  EnvironmentMode Mode { get; }

  Environment EnvironmentVars { get; }
}
