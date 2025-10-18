using Corpo.Adapters.TeamSports.Logging;

using TeamSports.Adapters.Godot.App.Concrete;


namespace Corpo._App;


public sealed class CorpoApp : DefaultGodotApp {
  public ILogger Logger => ServiceProvider.GetService<ILogger>();
}
