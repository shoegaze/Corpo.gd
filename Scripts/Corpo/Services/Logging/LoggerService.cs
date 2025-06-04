using System;

using Serilog;
using Serilog.Core;

using Corpo.Services.Core;
using Corpo.Services.Environment;

using EnvironmentMode = Corpo.Services.Environment.Models.Environment.EnvironmentMode;


namespace Corpo.Services.Logging;

// TODO(shoegaze): @Module(SharedModule, Public)
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class LoggerService : Service {
  private readonly EnvironmentService environmentService;
  
  // TODO(shoegaze): Inject Logger using Injector.Get<Logger>();
  private Logger logger;

  public LoggerService(EnvironmentService environmentService) {
    this.environmentService = environmentService;
  }
  
  
  // TODO(shoegaze): Define IService#Initialize()
  public void Initialize() {
    // TODO(shoegaze): Inject Logger instead of manual initialization
    logger = InjectLogger();
  }

  private Logger InjectLogger() {
    EnvironmentMode mode = environmentService.Mode;
    
    // TODO(shoegaze): Dynamic dispatch; Get<LoggerProvider>()#GetLogger()
    return mode switch {
      EnvironmentMode.Development => MakeDevelopmentLogger(),
      EnvironmentMode.Staging => MakeStagingLogger(),
      EnvironmentMode.Production => MakeProductionLogger(),
      _ => throw new ArgumentOutOfRangeException(
            nameof(mode), 
            $"Invalid environment mode: ${mode}"
          )
    };
  }

  private Logger MakeDevelopmentLogger() {
    // TODO(shoegaze): Add log formatting (timestamp etc.)
    return new LoggerConfiguration()
          .MinimumLevel.Debug()
           // TODO(shoegaze): Configure GD.Print etc.
           // .WriteTo.Sink()
           // TODO(shoegaze): Get log path from SettingsService
          .WriteTo.File("path/to/logs/TODO.dev.log")
          .CreateLogger();
  }

  private Logger MakeStagingLogger() {
    // TODO(shoegaze): Add log formatting (timestamp etc.)
    throw new NotImplementedException("Production Logger creation");
  
    return new LoggerConfiguration()
          .MinimumLevel.Warning()
           // TODO(shoegaze): Configure GD.Print etc.
           // .WriteTo.Sink()
          .WriteTo.File("path/to/logs/TODO.pre.log")
          .CreateLogger();
  }

  private Logger MakeProductionLogger() {
    // TODO(shoegaze): Add log formatting (timestamp etc.)
    throw new NotImplementedException("Production Logger creation");

    return new LoggerConfiguration()
          .MinimumLevel.Error()
           // TODO(shoegaze): Configure GD.Print etc.
           // .WriteTo.Sink()
          .WriteTo.File("path/to/logs/TODO.log")
          .CreateLogger();
  }

  // ReSharper disable once UnusedMember.Global
  public void Debug(string message) {
    logger.Debug("{}", message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Info(string message) {
    logger.Information("{}", message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Warn(string message) {
    logger.Warning("{}", message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Error(string message) {
    logger.Error("{}", message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Fatal(string message) {
    logger.Fatal("{}", message);
  }
}
