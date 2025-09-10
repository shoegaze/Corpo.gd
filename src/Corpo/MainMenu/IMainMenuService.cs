using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.MainMenu;


public interface IMainMenuService {
  void BindScreen(ICorpoScreen screen);

  void ToggleSavesSubmenu(ICorpoScreen screen);
  void ToggleSettingsSubmenu(ICorpoScreen screen);
}
