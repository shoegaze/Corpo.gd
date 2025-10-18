using Corpo.Adapters.TeamSports.Screens;


namespace Corpo._Core.Screens;


public interface IScreensService {

  public void UpdateScreens();

  public void EnterScreen<TScreen>()
  where TScreen : ICorpoScreen;

  public void ExitScreen();
}
