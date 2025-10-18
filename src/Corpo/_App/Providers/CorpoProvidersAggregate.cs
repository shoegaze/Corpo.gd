using Corpo.Adapters.TeamSports.Input.Concrete;
using Corpo.Adapters.TeamSports.Input.Concrete.Providers;

using TeamSports.Adapters.Godot.App.Providers.Concrete;
using TeamSports.Core.Game.Providers;


namespace Corpo._App.Providers;


public sealed class CorpoProvidersAggregate
  : DefaultGodotProvidersAggregate<CorpoUserInput> {
  public override IInputProvider<CorpoUserInput> InputProvider { get; } =
    new CorpoInputProvider();

  public override IServiceProvider ServiceProvider { get; } = new CorpoServiceProvider();
}
