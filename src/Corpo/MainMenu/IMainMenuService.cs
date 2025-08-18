using Corpo.Adapters.Services;


namespace Corpo.MainMenu;


public interface IMainMenuService : ICorpoScreenService<IMainMenuScreen> {
  void ToggleSavesSubmenu();
  void ToggleSettingsSubmenu();

  void DoNewGame();
  void DoLoadGame();
  void DoSettings();
  void DoExit();
}
