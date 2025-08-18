using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Loading;


public class LoadingRegistry : ServiceRegistry {
  public LoadingRegistry() {
    Scan(
      s => {
        s.TheCallingAssembly();

        s.WithDefaultConventions(
          OverwriteBehavior.Never,
          ServiceLifetime.Singleton);

        s.IncludeNamespaceContainingType<LoadingRegistry>();
      });
  }
}
