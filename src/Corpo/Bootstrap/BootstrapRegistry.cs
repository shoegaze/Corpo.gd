using Corpo.Adapters.TeamSports.Game;
using Corpo.Core;

using Lamar;


namespace Corpo.Bootstrap;


public class BootstrapRegistry : ServiceRegistry {
  public BootstrapRegistry() {
    IncludeRegistry<CoreRegistry>();
    IncludeRegistry<ScreensRegistry>();

    For<ICorpoStartable>()
     .OnCreationForAll(
        (_, startable) => {
          startable.Start();
        });
  }
}
