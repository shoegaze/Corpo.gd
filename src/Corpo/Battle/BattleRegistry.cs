using Corpo.Base;

using Lamar;
using Lamar.Scanning.Conventions;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Battle;


public sealed class BattleRegistry : ServiceRegistry {
  public BattleRegistry() {
    IncludeRegistry<BaseRegistry>();

    Scan(s => {
      s.TheCallingAssembly();

      s.WithDefaultConventions(
        OverwriteBehavior.NewType,
        ServiceLifetime.Singleton);

      s.IncludeNamespaceContainingType<BattleRegistry>();
    });
  }
}
