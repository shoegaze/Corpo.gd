using Engine;

using Lamar;

using Microsoft.Extensions.DependencyInjection;


namespace Corpo.Logging;


public sealed class LoggerRegistry : ServiceRegistry {
  public LoggerRegistry() {
    this.AddSingleton<ILogger, Logger>();
  }
}
