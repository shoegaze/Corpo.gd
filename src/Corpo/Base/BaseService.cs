using Corpo.MainMenu;


namespace Corpo.Base;


public interface IBaseService {
  // TODO: Make async
  public void LoadPackages();
  public void ShowMainMenu();
}

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BaseService(
  ILogger logger,
  IScreensService screensService
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
    screensService.EnterScreen<IMainMenuScreen>();
  }
}
