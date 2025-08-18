using Corpo.Adapters.Input.Concrete;


namespace Corpo.Adapters.Screens;


public interface ICorpoDebugScreen : ICorpoScreen {
  void DrawDebug(float dt, CorpoInput input);
}
