using Serilog.Events;
using Serilog.Formatting;


namespace Corpo.Adapters.TeamSports.Logging.Serilog;


// TODO: Use https://gist.github.com/paulloz/a0a01539ed96298682005ce61ba33a90
public sealed class GodotTextFormatter : ITextFormatter {
  public void Format(LogEvent logEvent, TextWriter output) {
    string message = logEvent.RenderMessage();

    output.Write($"{logEvent.Timestamp:O} [{logEvent.Level}] {message}");
  }
}
