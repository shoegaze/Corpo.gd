#nullable enable

using System.IO;

using Godot;

using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;


namespace Corpo.Adaptors.Godot.Logging;


public sealed class GodotSink(
  ITextFormatter? textFormatter = null
  // IFormatProvider? formatProvider = null
) : ILogEventSink {
  private readonly ITextFormatter textFormatter =
      textFormatter ??
      new GodotTextFormatter();

  public void Emit(LogEvent logEvent) {
    var output = new StringWriter();

    textFormatter.Format(logEvent, output);
    output.Flush();

    string[] lines = output.ToString().Split('\n');

    foreach (string line in lines) {
      string colorCode = GetColor(logEvent.Level).ToHtml();

      GD.PrintRich($"[color=#{colorCode}]{line}[/color]");
    }

    if (logEvent.Exception is null) {
      return;
    }

    if (logEvent.Level >= LogEventLevel.Error) {
      GD.PushError(logEvent.Exception);

      return;
    }

    GD.PushWarning(logEvent.Exception);
  }

  private static Color GetColor(LogEventLevel eventLevel) {
    return eventLevel switch {
      LogEventLevel.Verbose => Colors.DarkSlateGray,
      LogEventLevel.Debug => Colors.LightSlateGray,
      LogEventLevel.Information => Colors.LightBlue,
      LogEventLevel.Warning => Colors.Yellow,
      LogEventLevel.Error => Colors.Red,
      LogEventLevel.Fatal => Colors.Magenta,
      _ => Colors.LightPink
    };
  }
}
