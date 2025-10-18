using Corpo._App.Providers;
using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.App.Concrete;


namespace Corpo._App;


public sealed class CorpoOrchestrator
  : DefaultGodotOrchestrator<
    CorpoUserInput,
    CorpoProvidersAggregate,
    CorpoApp,
    CorpoEventHandler
  >;
