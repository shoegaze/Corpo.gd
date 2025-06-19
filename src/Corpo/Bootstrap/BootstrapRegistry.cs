using Corpo.Bootstrap.Implementations;
using Corpo.Logging;

using Lamar;


namespace Corpo.Bootstrap;


public class BootstrapRegistry : ServiceRegistry {
  public BootstrapRegistry() {
    IncludeRegistry<LoggerRegistry>();

    For<IBootstrapService>()
       .Use<BootstrapService>()
       .Transient();
  }
}
