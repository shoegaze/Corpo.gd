#nullable enable

using System;
using System.IO;

using Serilog;

using ILogger = Engine.ILogger;
using Environment = Corpo.Base.Environments.Models.Environment;
using EnvironmentMode =
    Corpo.Base.Environments.Models.Environment.EnvironmentMode;


namespace Corpo.Logging;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class Logger : ILogger {
  // TODO
  // private record LogInfo(
  //   LogEventLevel Level,
  //   string Message,
  //   Exception? Exception
  // );

  private const string LogOutPath = "logs";

  private const string FileOutTemplate =
      "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}";

  private readonly Serilog.ILogger logger;

  public Logger() {
    logger = GetLogger();
  }

  public void Debug(string message) {
    logger.Debug("{}", message);
  }

  public void Info(string message) {
    logger.Information("{}", message);
  }

  public void Warn(string message) {
    logger.Warning("{}", message);
  }

  public void Error(string message) {
    logger.Error("{}", message);
  }

  public void Fatal(string message) {
    logger.Fatal("{}", message);
  }

  private Serilog.ILogger GetLogger() {
    EnvironmentMode mode = Environment.GetEnvironmentMode();

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
    EnvironmentMode mode = Environment.GetEnvironmentMode();

    if (mode == EnvironmentMode.Production) {
      return "log.txt";
    }

    string envName = Environment.GetEnvironmentModeAsName();

    return $"log.{envName}.txt";
  }

  private Serilog.ILogger MakeDevelopmentLogger() {
    string logFilePath = Path.Combine(LogOutPath, GetLogFileName());
    // TODO
    // var godotSink = new GodotLoggerSink();

    // TODO: Add log formatting (timestamp etc.)
    Serilog.Core.Logger developmentLogger =
        new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.File(logFilePath, outputTemplate: FileOutTemplate)
            // .WriteTo.Sink(godotSink)
           .CreateLogger();

    return developmentLogger;
  }

  private Serilog.ILogger MakeStagingLogger() {
    string logFilePath = Path.Combine(LogOutPath, GetLogFileName());
    // TODO
    // var godotSink = new GodotLoggerSink();

    Serilog.Core.Logger stagingLogger =
        new LoggerConfiguration()
           .MinimumLevel.Warning()
           .WriteTo.File(logFilePath, outputTemplate: FileOutTemplate)
            // .WriteTo.Sink(godotSink)
           .CreateLogger();

    return stagingLogger;
  }

  private Serilog.ILogger MakeProductionLogger() {
    string logFilePath = Path.Combine(LogOutPath, GetLogFileName());

    Serilog.ILogger productionLogger =
        new LoggerConfiguration()
           .MinimumLevel.Error()
           .WriteTo.File(logFilePath, outputTemplate: FileOutTemplate)
           .CreateLogger();

    return productionLogger;
  }
}
