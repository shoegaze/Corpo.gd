using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.Core.Screens;


public interface IScreenService {

  ICorpoScreen? CurrentScreen { get; }

  void UpdateScreens();

  void EnterScreen<TScreen>(bool focusImmediately = true)
  where TScreen : ICorpoScreen;

  void ExitScreen();
}
