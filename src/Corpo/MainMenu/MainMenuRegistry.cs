using Corpo.Base;

using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.MainMenu;


public sealed class MainMenuRegistry : ServiceRegistry {
  public MainMenuRegistry() {
    IncludeRegistry<BaseRegistry>();

    Scan(s => {
      s.TheCallingAssembly();
      s.WithDefaultConventions(
        OverwriteBehavior.Never,
        ServiceLifetime.Singleton);

      s.IncludeNamespaceContainingType<MainMenuRegistry>();
    });
  }
}
