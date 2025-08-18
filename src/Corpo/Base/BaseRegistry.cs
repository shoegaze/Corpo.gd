using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Base;


public sealed class BaseRegistry : ServiceRegistry {
  public BaseRegistry() {
    Scan(
      s => {
        s.TheCallingAssembly();

        s.WithDefaultConventions(
          OverwriteBehavior.NewType,
          ServiceLifetime.Singleton);

        s.IncludeNamespaceContainingType<BaseRegistry>();
      });
  }
}
