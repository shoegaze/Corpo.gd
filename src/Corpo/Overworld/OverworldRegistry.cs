using Corpo.Base;

using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Overworld;


public sealed class OverworldRegistry : ServiceRegistry {
  public OverworldRegistry() {
    IncludeRegistry<BaseRegistry>();

    Scan(s => {
      s.TheCallingAssembly();
      s.WithDefaultConventions(
        OverwriteBehavior.NewType,
        ServiceLifetime.Singleton);

      s.IncludeNamespaceContainingType<OverworldRegistry>();
    });
  }
}
