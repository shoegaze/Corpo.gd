using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.MainMenu.Debug;


public class MainMenuDebugRegistry : ServiceRegistry {
  public MainMenuDebugRegistry() {
    Scan(
      s => {
        s.TheCallingAssembly();

        s.WithDefaultConventions(
          OverwriteBehavior.Never,
          ServiceLifetime.Scoped);

        s.IncludeNamespaceContainingType<MainMenuDebugRegistry>();
      });
  }
}
