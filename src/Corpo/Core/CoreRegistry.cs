using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Core;


public class CoreRegistry : ServiceRegistry {
  public CoreRegistry() {
    Scan(s => {
      s.TheCallingAssembly();
      s.WithDefaultConventions(
        OverwriteBehavior.Never,
        ServiceLifetime.Singleton);

      s.IncludeNamespaceContainingType<CoreRegistry>();
    });
  }
}
