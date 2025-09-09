using System;

using Corpo.Adapters.TeamSports.Game;
using Corpo.Adapters.TeamSports.Screens;

using Godot;

using TeamSports.Logging;


namespace Corpo.MainMenu._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class MainMenuService(
  ILogger logger,
  ICorpoGameService gameService
) : IMainMenuService {

  public IMainMenuScreen ScreenModel { get; private set; } = null!;

  // UI components
  private Node buttonExit = null!;
  private Node buttonLoadGame = null!;
  private Node buttonNewGame = null!;
  private Node buttonSettings = null!;
  private Node submenus = null!;

  public void BindScreenModel(IMainMenuScreen screen) {
    ScreenModel = screen;
  }

  public void SetupViews() {
    throw new NotImplementedException();
  }

  public void CleanUpViews() {
    throw new NotImplementedException();
  }

  public void ToggleSavesSubmenu() {
    throw new NotImplementedException();
  }

  public void ToggleSettingsSubmenu() {
    throw new NotImplementedException();
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

  public void BindScreen(ICorpoScreen screen) {
    throw new NotImplementedException();
  }

  public void ToggleSavesSubmenu(ICorpoScreen screen) {
    throw new NotImplementedException();
  }

  public void ToggleSettingsSubmenu(ICorpoScreen screen) {
    throw new NotImplementedException();
  }
}
