using Corpo.Adapters.TeamSports.Input.Concrete;


namespace Corpo.Adapters.TeamSports.Screens.Debug;


public interface IDebugScreen : IScreen {
  void DrawDebug(float dt, CorpoInput input);
}
