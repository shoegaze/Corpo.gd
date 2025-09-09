using Corpo.Adapters.TeamSports.Input.Concrete;


namespace Corpo.Adapters.TeamSports.Screens;


public interface ICorpoDebugScreen : ICorpoScreen {
  void DrawDebug(float dt, CorpoInput input);
}
