using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.Core.Screens;


public interface IScreenService {

  IScreen? CurrentScreen { get; }

  void UpdateScreens();

  void EnterScreen<TScreen>(bool focusImmediately = true)
  where TScreen : IScreen;

  void ExitScreen();
}
