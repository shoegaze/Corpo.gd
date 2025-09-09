using Corpo.Core;

using Lamar;

using TeamSports.Services;


namespace Corpo.Bootstrap;


public class BootstrapRegistry : ServiceRegistry {
  public BootstrapRegistry() {
    IncludeRegistry<CoreRegistry>();
    IncludeRegistry<ScreensRegistry>();

    For<IStartable>()
     .OnCreationForAll(
        (_, startable) => {
          startable.Start();
        });
  }
}
