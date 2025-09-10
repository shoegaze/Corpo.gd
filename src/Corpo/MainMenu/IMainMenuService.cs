using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.MainMenu;


public interface IMainMenuService {
  void BindScreen(IScreen screen);

  void ToggleSavesSubmenu(IScreen screen);
  void ToggleSettingsSubmenu(IScreen screen);
}
