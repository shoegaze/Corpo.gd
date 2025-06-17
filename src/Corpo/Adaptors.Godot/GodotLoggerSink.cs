#nullable enable

using System;

using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;


namespace Corpo.Adaptors.Godot;


public sealed class GodotLoggerSink : ILogEventSink {
  private readonly ITextFormatter formatter;

  public GodotLoggerSink(
    string outputTemplate,
    IFormatProvider? formatProvider
  ) {
    // formatter = new TemplateRenderer(outputTemplate, formatProvider);
  }

  public void Emit(LogEvent logEvent) {
    // string message = logEvent.RenderMessage(formatProvider);
    // 
    // switch (logEvent.Level) {
    //   case LogEventLevel.Verbose:
    //     // TODO(shoegaze);
    //     GD.Print("Verbose: TODO");
    // 
    //     break;
    // 
    //   case LogEventLevel.Debug:
    //     // TODO(shoegaze);
    //     GD.Print("Debug: TODO");
    // 
    //     break;
    // 
    //   case LogEventLevel.Information:
    //     // TODO(shoegaze);
    //     GD.Print("Info: TODO");
    // 
    //     break;
    // 
    //   case LogEventLevel.Warning:
    //     // TODO(shoegaze);
    //     GD.PushWarning("Warn: TODO");
    // 
    //     break;
    // 
    //   case LogEventLevel.Error:
    //     // TODO(shoegaze);
    //     GD.PrintErr("Error: TODO");
    // 
    //     break;
    // 
    //   case LogEventLevel.Fatal:
    //     // TODO(shoegaze);
    //     GD.PrintErr("Fatal: TODO");
    // 
    //     break;
    // 
    //   default:
    //     throw new ArgumentOutOfRangeException(
    //       nameof(logEvent),
    //       $"Log level: {logEvent.Level} is not supported");
    // }
  }
}
