using Corpo.Adapters.TeamSports.Input.Concrete;


namespace Corpo.Adapters.TeamSports.Screens.Debug;


public interface IDebugScreen : ICorpoScreen {
  void DrawDebug(float dt, CorpoUserInput userInput);
}
