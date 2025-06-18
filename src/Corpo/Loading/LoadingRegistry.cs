using Corpo.Base;

using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Loading;


public sealed class LoadingRegistry : ServiceRegistry {
  public LoadingRegistry() {
    IncludeRegistry<BaseRegistry>();

    Scan(s => {
      s.TheCallingAssembly();
      s.WithDefaultConventions(
        OverwriteBehavior.NewType,
        ServiceLifetime.Singleton);

      s.IncludeNamespaceContainingType<LoadingRegistry>();
    });
  }
}
