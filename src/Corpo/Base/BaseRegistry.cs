using Corpo.Logging;

using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Base;


public sealed class BaseRegistry : ServiceRegistry {
  public BaseRegistry() {
    IncludeRegistry<LoggerRegistry>();

    Scan(s => {
      s.TheCallingAssembly();
      s.WithDefaultConventions(
        OverwriteBehavior.NewType,
        ServiceLifetime.Singleton);

      s.IncludeNamespaceContainingType<BaseRegistry>();
    });
  }
}
