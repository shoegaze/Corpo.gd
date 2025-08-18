using Corpo.Core.Screens;
using Corpo.MainMenu;

using TeamSports.Logging;


namespace Corpo.Base._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BaseService(
  ILogger logger,
  IScreenService screenService
) : IBaseService {
  public void LoadPackages() {
    logger.Info("Loading packages...");

    // DEBUG:
    // throw new NotImplementedException();
  }

  public void DisposePackages() {
    logger.Info("Disposing packages...");

    // DEBUG:
    // throw new NotImplementedException();
  }

  public void ShowMainMenu() {
    logger.Info("Showing main menu screen...");

    // DEBUG: Enter LoadingScreen
    screenService.EnterScreen<IMainMenuScreen>();
  }
}
