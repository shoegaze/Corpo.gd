#nullable enable

using System;

using Serilog;
using Serilog.Configuration;


namespace Corpo.Adaptors.Godot.Logging;


public static class GodotSinkExtensions {
  public static LoggerConfiguration GodotSink(
    this LoggerSinkConfiguration loggerConfiguration,
    IFormatProvider? formatProvider = null
  ) {
    var textFormatter = new GodotTextFormatter();
    var sink = new GodotSink(textFormatter, formatProvider);

    return loggerConfiguration.Sink(sink);
  }
}
