using Lamar;

using TeamSports.Core.Game;


namespace Corpo._Core.Runtime;


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
