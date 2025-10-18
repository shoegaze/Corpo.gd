using Corpo._Core.Runtime;

using Lamar;

using IServiceProvider = TeamSports.Core.Game.Providers.IServiceProvider;


namespace Corpo._App.Providers;


public sealed class CorpoServiceProvider : IServiceProvider {
  private Container container = null!;

  public void Configure() {
    container = Container.For<BootstrapRegistry>();
  }

  public TService GetService<TService>() {
    return container.GetInstance<TService>();
  }
}
