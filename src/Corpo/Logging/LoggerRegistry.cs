using Lamar;

using Microsoft.Extensions.DependencyInjection;

using TeamSports;


namespace Corpo.Logging;


public sealed class LoggerRegistry : ServiceRegistry {
  public LoggerRegistry() {
    this.AddSingleton<ILogger, Logger>();
  }
}
