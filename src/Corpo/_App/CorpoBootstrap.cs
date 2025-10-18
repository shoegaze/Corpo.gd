using Corpo._App.Providers;
using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.App.Concrete;


namespace Corpo._App;


public partial class CorpoBootstrap
  : DefaultGodotBootstrap<
    CorpoUserInput,
    CorpoProvidersAggregate,
    CorpoApp,
    CorpoEventHandler
  >;
