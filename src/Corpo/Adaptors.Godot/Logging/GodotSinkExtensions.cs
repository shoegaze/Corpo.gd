#nullable enable

using Serilog;
using Serilog.Configuration;


namespace Corpo.Adaptors.Godot.Logging;


public static class GodotSinkExtensions {
  public static LoggerConfiguration GodotSink(
    this LoggerSinkConfiguration loggerConfiguration
    // IFormatProvider? _formatProvider = null
  ) {
    var textFormatter = new GodotTextFormatter();
    var sink = new GodotSink(textFormatter);

    return loggerConfiguration.Sink(sink);
  }
}
