using System;

using Corpo.Services.Core;
using Corpo.Services.Environment;
using Corpo.Services.Environment.Models;

using Serilog;
using Serilog.Core;

namespace Corpo.Services.Log;

// TODO(shoegaze): @Module(SharedModule, Public)
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class LoggerService : Service {
  // TODO(shoegaze): Inject Logger using Injector.Get<Logger>();
  private Logger logger;

  // TODO(shoegaze): Define IService#Initialize()
  public void Initialize() {
    // TODO(shoegaze): Inject Logger instead of manual initialization
    logger = InjectLogger();
  }

  private Logger InjectLogger() {
    // TODO(shoegaze): Dynamic dispatch; Get<LoggerProvider>()#GetLogger()
    return EnvironmentService.Mode switch {
      EnvironmentMode.Development => CreateDevelopmentLogger(),
      EnvironmentMode.Production => CreateProductionLogger(),
      _ => throw new ArgumentOutOfRangeException(
             nameof(EnvironmentService.Mode),
             $"Invalid environment mode: ${EnvironmentService.Mode}")
    };
  }

  private Logger CreateDevelopmentLogger() {
    // TODO(shoegaze): Add log formatting (timestamp etc.)
    return new LoggerConfiguration()
          .MinimumLevel.Debug()
           // TODO(shoegaze): Configure GD.Print etc.
           // .WriteTo.Sink()
           // TODO(shoegaze): Get log path from SettingsService
          .WriteTo.File("path/to/logs/TODO.dev.log")
          .CreateLogger();
  }

  // TODO(shoegaze): Pre environment mode
  // private Logger CreatePreLogger() {
  //   // TODO(shoegaze): Add log formatting (timestamp etc.)
  //   throw new NotImplementedException("Production Logger creation");
  //
  //   return new LoggerConfiguration()
  //         .MinimumLevel.Warning()
  //          // TODO(shoegaze): Configure GD.Print etc.
  //          // .WriteTo.Sink()
  //         .WriteTo.File("path/to/logs/TODO.pre.log")
  //         .CreateLogger();
  // }

  private Logger CreateProductionLogger() {
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
    logger.Debug(message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Info(string message) {
    logger.Information(message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Warn(string message) {
    logger.Warning(message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Error(string message) {
    logger.Error(message);
  }

  // ReSharper disable once UnusedMember.Global
  public void Fatal(string message) {
    logger.Fatal(message);
  }
}
