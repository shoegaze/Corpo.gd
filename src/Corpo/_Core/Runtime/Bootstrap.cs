using Lamar;


namespace Corpo._Core.Runtime;


public static class Bootstrap {
  public static Container GetBootstrappedContainer() {
    return new Container(
      services => {
        services.IncludeRegistry<BootstrapRegistry>();

        // TODO: Track Startables
        // services.AddSingleton<StartablesTracker>();
      });
  }
}
