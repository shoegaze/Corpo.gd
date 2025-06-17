using Corpo.Generated.Json.Environment;

using Engine.Services;

using EnvironmentMode =
    Corpo.Base.Environments.Models.Environment.EnvironmentMode;


namespace Corpo.Base.Environments;


public interface IEnvironmentService : IService, IStartable {
  EnvironmentMode Mode { get; }


  Environment Environment { get; }
}
