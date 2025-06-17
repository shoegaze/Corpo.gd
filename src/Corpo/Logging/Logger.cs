#nullable enable

using System;
using System.IO;

using Corpo.Adaptors.Godot.Logging;

using Serilog;

using ILogger = Engine.ILogger;
using Environment = Corpo.Base.Environments.Models.Environment;
using EnvironmentMode =
    Corpo.Base.Environments.Models.Environment.EnvironmentMode;


namespace Corpo.Logging;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class Logger : ILogger {
  private const string LogSinkOutputPath = "logs";

  private const string FileOutputTemplate =
      "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}";

  private readonly Serilog.ILogger logger;

  public Logger() {
    logger = GetLogger();
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

  public void Error(string message) {
    logger.Error("{Message}", message);
  }

  public void Fatal(string message) {
    logger.Fatal("{Message}", message);
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
      return "log-.txt";
    }

    string envName = Environment.GetEnvironmentModeAsName();

    return $"log.{envName}-.txt";
  }

  private Serilog.ILogger MakeDevelopmentLogger() {
    string logFilePath = Path.Combine(LogSinkOutputPath, GetLogFileName());

    // TODO: Add log formatting (timestamp etc.)
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

  private Serilog.ILogger MakeStagingLogger() {
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

  private Serilog.ILogger MakeProductionLogger() {
    string logFilePath = Path.Combine(LogSinkOutputPath, GetLogFileName());

    Serilog.ILogger productionLogger =
        new LoggerConfiguration()
           .MinimumLevel.Error()
           .WriteTo.File(logFilePath, outputTemplate: FileOutputTemplate)
           .CreateLogger();

    return productionLogger;
  }
}
