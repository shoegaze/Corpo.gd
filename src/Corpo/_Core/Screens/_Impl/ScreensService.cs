using System;

using Corpo._Core.App;
using Corpo.Adapters.TeamSports.Logging;
using Corpo.Adapters.TeamSports.Screens;
using Corpo.Adapters.TeamSports.Screens.Concrete;

using Godot;

using Main = Corpo._Core.Runtime.Main;


namespace Corpo._Core.Screens._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class ScreensService(
  ILogger logger,
  ICorpoAppService appService,
  IScreenWrapperService screenWrapperService
) : IScreensService {
  private readonly CorpoScreenManager screenManager = new();
  private ulong timePreviousMs = Time.GetTicksMsec();

  private ICorpoScreen? CurrentScreen => screenManager.CurrentScreen;

  public void UpdateScreens() {
    // TODO: Update screens from CurrentScreen down to origin
    UpdateActiveScreen();
  }

  // TODO: Call this in some _Update method
  private void UpdateActiveScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;

    if (CurrentScreen is not null) {
      logger.Debug("Updating screen");

      var input = appService.Providers.InputProvider.PollInput();
      screenManager.Tick(dt, input);
    }

    timePreviousMs = timeNowMs;
  }

  public void EnterScreen<TScreen>()
  where TScreen : ICorpoScreen {
    logger.Debug($"Loading scene type: {typeof(TScreen)}");

    var screen = Main.ServicesContainer.GetInstance<TScreen>();
    var wrapper = screenWrapperService.Wrap(screen);

    logger.Debug($"Instantiated wrapper: {wrapper}");

    screen.OnCreate();

    logger.Info($"Entering screen: {screen}");

    screenManager.Enter(screen);
    screenWrapperService.Wrap(screen);
  }

  public void ExitScreen() {
    if (screenManager.CurrentScreen is null) {
      logger.Error("No screen to dismiss", new InvalidOperationException());

      return;
    }

    var previousScreen = screenManager.CurrentScreen;

    logger.Info($"Exiting: {previousScreen}");

    screenManager.Exit();
    screenWrapperService.FreeWrapper(previousScreen);
  }
}
