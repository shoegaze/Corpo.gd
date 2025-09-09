using Corpo.Adapters.TeamSports.Screens;

using TeamSports.Services;


namespace Corpo.MainMenu;


public interface IMainMenuService : IService {
  void BindScreen(ICorpoScreen screen);

  void ToggleSavesSubmenu(ICorpoScreen screen);
  void ToggleSettingsSubmenu(ICorpoScreen screen);
}
