using System;

using TeamSports.Entities.Views.Button;
using TeamSports.Entities.Views.TabContainer;
using TeamSports.Logging;
using TeamSports.Services.Game;


namespace Corpo.MainMenu._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class MainMenuService(
  ILogger logger,
  IGameService gameService
) : IMainMenuService {

  public IMainMenuScreen ScreenModel { get; private set; } = null!;

  // UI components
  private IViewButton buttonExit = null!;
  private IViewButton buttonLoadGame = null!;
  private IViewButton buttonNewGame = null!;
  private IViewButton buttonSettings = null!;
  private IViewTabContainer submenus = null!;

  public void BindScreenModel(IMainMenuScreen screen) {
    ScreenModel = screen;
  }

  public void SetupViews() {
    // buttonNewGame = ;
    // buttonLoadGame = ;
    // buttonSettings = ;
    // buttonExit = ;
    // submenus = ;

    // TODO: Set up saves UI
    // Foo subMenuSave = view("submenu.save") as Foo;
  }

  public void CleanUpViews() {
    buttonNewGame.Clear();
    buttonLoadGame.Clear();
    buttonSettings.Clear();
    buttonExit.Clear();
  }

  public void ToggleSavesSubmenu() {
    if (submenus.IsVisible) {
      // TODO: Fade out animation
      submenus.SetVisibility(false);

      return;
    }

    submenus.SetVisibility(true);
    submenus.SetTab(0);
  }

  public void ToggleSettingsSubmenu() {
    if (submenus.IsVisible) {
      // TODO: Fade out animation
      submenus.SetVisibility(false);

      return;
    }

    submenus.SetVisibility(true);
    submenus.SetTab(1);

    // TODO: Set up settings UI
    // Node subMenuSettings = view(submenusPaths.Settings);
  }

  public void DoNewGame() {
    // TODO: Create new empty save and load
    logger.Info("[User Action]: Starting new game ...");


    //  DEBUG:
    // stateService.EnterState(GameState.Battle);
  }

  public void DoLoadGame() {
    logger.Info("[User Action]: Toggling saves submenu");

    ToggleSavesSubmenu();
  }

  public void DoSettings() {
    logger.Info("[User Action]: Toggling settings submenu");

    ToggleSettingsSubmenu();
  }

  public void DoExit() {
    logger.Info("[User Action]: Exiting game");

    gameService.ExitGame();
  }

  public void BindScreen(IMainMenuScreen screen) {
    throw new NotImplementedException();
  }
}
