using TeamSports.Services;

using Environment = Corpo.Generated.Json.Environment.Environment;
using EnvironmentMode =
    Corpo.Base.Environments.Models.Environment.EnvironmentMode;


namespace Corpo.Base.Environments;


public interface IEnvironmentService : IService, IStartable {
  EnvironmentMode Mode { get; }


  Environment Environment { get; }
}
