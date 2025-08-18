using System;
using System.IO;

using Corpo.Core.Environments.Helpers;
using Corpo.Core.Environments.Models;

using Serilog;
using Serilog.Events;

using TeamSports.Adaptors.Godot.Logging.Serilog;


namespace Corpo.Core.Logging._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class Logger : TeamSports.Logging.ILogger {
  private const string LogSinkOutputPath = "logs";

  private const string FileOutputTemplate =
    "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}";

  private readonly ILogger logger;

  public Logger() {
    logger = GetLogger();
  }

  public void Write(LogEvent logEvent) {
    throw new NotImplementedException();
  }

  public void Debug(string message) {
    logger.Debug("{Message}", message);
  }

  public void Info(string message) {
    logger.Information("{Message}", message);
  }

  public void Warn(string message) {
    logger.Warning("{Message}", message);
  }

  public void Error(string message, Exception? exception = null) {
    logger.Error("{Message}{NewLine}{Exception}", message, '\n', exception);
  }

  public void Fatal(string message, Exception? exception = null) {
    logger.Fatal("{Message}{NewLine}{Exception}", message, '\n', exception);
  }

  private ILogger GetLogger() {
    EnvironmentMode mode = EnvironmentHelper.GetEnvironmentMode();

    return mode switch {
      EnvironmentMode.Development =>
        MakeDevelopmentLogger(),
      EnvironmentMode.Staging =>
        MakeStagingLogger(),
      EnvironmentMode.Production =>
        MakeProductionLogger(),
      _ => throw new ArgumentOutOfRangeException(
        nameof(mode),
        $"Invalid environment mode: {mode}")
    };
  }

  private string GetLogFileName() {
    EnvironmentMode mode = EnvironmentHelper.GetEnvironmentMode();

    if (mode == EnvironmentMode.Production) {
      return "log-.txt";
    }

    string envName = EnvironmentHelper.GetEnvironmentModeAsName();

    return $"log.{envName}-.txt";
  }

  private ILogger MakeDevelopmentLogger() {
    string logFilePath = Path.Combine(LogSinkOutputPath, GetLogFileName());

    // TODO: Route to separate loggers for each level
    //  * level >= Warn => Log File
    //  * level < Warn  => GodotSink
    Serilog.Core.Logger developmentLogger =
      new LoggerConfiguration()
       .MinimumLevel.Debug()
       .WriteTo.File(
          logFilePath,
          outputTemplate: FileOutputTemplate,
          rollingInterval: RollingInterval.Day,
          rollOnFileSizeLimit: true)
       .WriteTo.GodotSink()
       .CreateLogger();

    return developmentLogger;
  }

  private ILogger MakeStagingLogger() {
    string logFilePath = Path.Combine(LogSinkOutputPath, GetLogFileName());

    Serilog.Core.Logger stagingLogger =
      new LoggerConfiguration()
       .MinimumLevel.Warning()
       .WriteTo.File(
          logFilePath,
          outputTemplate: FileOutputTemplate,
          rollingInterval: RollingInterval.Day,
          rollOnFileSizeLimit: true)
       .WriteTo.GodotSink()
       .CreateLogger();

    return stagingLogger;
  }

  private ILogger MakeProductionLogger() {
    string logFilePath = Path.Combine(LogSinkOutputPath, GetLogFileName());

    ILogger productionLogger =
      new LoggerConfiguration()
       .MinimumLevel.Error()
       .WriteTo.File(logFilePath, outputTemplate: FileOutputTemplate)
       .CreateLogger();

    return productionLogger;
  }
}
