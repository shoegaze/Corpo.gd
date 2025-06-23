using Corpo.Core.Screens;

using TeamSports.Services;


namespace Corpo.MainMenu.Core;


public interface IMainMenuService : IService {
  void ToggleSavesSubmenu(ICorpoScreen root);
  void ToggleSettingsSubmenu(ICorpoScreen root);
}
