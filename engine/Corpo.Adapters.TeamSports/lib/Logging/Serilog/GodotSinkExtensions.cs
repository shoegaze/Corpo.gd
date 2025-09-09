using Serilog;
using Serilog.Configuration;


namespace Corpo.Adapters.TeamSports.Logging.Serilog;


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
