#nullable enable

using System;

using Godot;

using Serilog.Core;
using Serilog.Events;


namespace Corpo.Adaptors.Godot.Logging;


public sealed class GodotSink(
  // TODO:
  // ITextFormatter? textFormatter,
  IFormatProvider? formatProvider
) : ILogEventSink {

  public void Emit(LogEvent logEvent) {
    string message = logEvent.RenderMessage(formatProvider);
    string color = GetColor(logEvent.Level).ToHtml();

    GD.PrintRich($"[color=#{color}]{message}[/color]");

    if (logEvent.Exception is null) {
      return;
    }

    switch (logEvent.Level) {
      case LogEventLevel.Warning: {
        GD.PushWarning(logEvent.Exception);

        return;
      }

      case >= LogEventLevel.Error: {
        GD.PushError(logEvent.Exception);

        return;
      }
    }
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
