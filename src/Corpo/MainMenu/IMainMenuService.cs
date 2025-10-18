using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.MainMenu;


public interface IMainMenuService {
  void BindScreen(ICorpoScreen corpoScreen);

  void ToggleSavesSubmenu(ICorpoScreen corpoScreen);
  void ToggleSettingsSubmenu(ICorpoScreen corpoScreen);
}
