using Corpo.Core.Environments.Models;

using TeamSports.Services;

using Environment = Corpo.Generated.Json.Environment.Environment;


namespace Corpo.Core.Environments;


public interface IEnvironmentService : IService, IStartable {
  EnvironmentMode Mode { get; }

  Environment EnvironmentVars { get; }
}
