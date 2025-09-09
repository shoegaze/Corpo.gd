using System;

using Corpo.Adapters.TeamSports.Input.Concrete;
using Corpo.Adapters.TeamSports.Logging;
using Corpo.Adapters.TeamSports.Screens;
using Corpo.Adapters.TeamSports.Screens.Concrete;

using Godot;


namespace Corpo.Core.Screens._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class ScreenService(
  ICorpoLogger logger,
  IScreenWrapperService screenWrapperService
) : IScreenService {

  private readonly CorpoScreenManager screensManager = new();
  private ulong timePreviousMs = Time.GetTicksMsec();

  public ICorpoScreen? CurrentScreen => screensManager.ActiveScreen;

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

      // TODO: Poll only in Node:_Input()
      // TODO: Create InputService:GetInput
      CorpoInput input = CorpoInputHelper.PollInput();
      screensManager.ActiveScreen?.Tick(dt, input);
    }

    timePreviousMs = timeNowMs;
  }

  public void EnterScreen<TScreen>(bool focusImmediately = true)
  where TScreen : ICorpoScreen {
    logger.Debug($"Loading scene type: {typeof(TScreen)}");

    var screen = Main.ServicesContainer.GetInstance<TScreen>();
    var wrapper = screenWrapperService.Wrap(screen);

    logger.Debug($"Instantiated wrapper: {wrapper}");

    screen.OnCreate();

    logger.Info($"Entering screen: {screen}");
    logger.Debug($"Focusing immediately?: {focusImmediately}");

    screensManager.Enter(screen, focusImmediately);
    screenWrapperService.Wrap(screen);
  }

  public void ExitScreen() {
    if (screensManager.ActiveScreen is null) {
      logger.Error("No screen to dismiss", new InvalidOperationException());

      return;
    }

    ICorpoScreen previousScreen = screensManager.ActiveScreen;

    logger.Info($"Exiting: {previousScreen}");

    screensManager.Exit();
    screenWrapperService.FreeWrapper(previousScreen);
  }
}
