using Corpo._Core.Environments.Models;

using TeamSports.Core.Game;

using Environment = Corpo.Generated.Json.Environment.Environment;


namespace Corpo._Core.Environments;


public interface IEnvironmentService : IStartable {
  EnvironmentMode Mode { get; }

  Environment EnvironmentVars { get; }
}
