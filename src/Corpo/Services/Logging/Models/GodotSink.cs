using System;

using Serilog.Core;
using Serilog.Events;

using Godot;


namespace Corpo.Services.Logging.Models;


public sealed class GodotSink(
  IFormatProvider formatProvider
) : ILogEventSink {

  // TODO(shoegaze);
  public void Emit(LogEvent logEvent) {
    string message = logEvent.RenderMessage(formatProvider);

    switch (logEvent.Level) {
      case LogEventLevel.Verbose:
        // TODO(shoegaze);
        GD.Print("Verbose: TODO");

        break;

      case LogEventLevel.Debug:
        // TODO(shoegaze);
        GD.Print("Debug: TODO");

        break;

      case LogEventLevel.Information:
        // TODO(shoegaze);
        GD.Print("Info: TODO");

        break;

      case LogEventLevel.Warning:
        // TODO(shoegaze);
        GD.PushWarning("Warn: TODO");

        break;

      case LogEventLevel.Error:
        // TODO(shoegaze);
        GD.PrintErr("Error: TODO");

        break;

      case LogEventLevel.Fatal:
        // TODO(shoegaze);
        GD.PrintErr("Fatal: TODO");

        break;

      default:
        throw new ArgumentOutOfRangeException(
              nameof(logEvent),
              $"Log level: {logEvent.Level} is not supported"
            );
    }
  }
}
