#nullable enable

using System;

using Serilog;
using Serilog.Configuration;


namespace Corpo.Adaptors.Godot.Logging;


public static class GodotSinkExtensions {
  // TODO:
  // private const string GodotSinkOutTemplate =
  //     "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}";

  public static LoggerConfiguration GodotSink(
    this LoggerSinkConfiguration loggerConfiguration,
    // TODO:
    // string outputTemplate = GodotSinkOutTemplate,
    IFormatProvider? formatProvider = null
  ) {
    return loggerConfiguration.Sink(new GodotSink(formatProvider));
  }
}
