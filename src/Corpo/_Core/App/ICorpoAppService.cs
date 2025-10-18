using Corpo._App;
using Corpo._App.Providers;

using TeamSports.Adapters.Godot.Services;


namespace Corpo._Core.App;


public interface ICorpoAppService : IGodotAppService<CorpoApp> {
  CorpoProvidersAggregate Providers { get; }
}
