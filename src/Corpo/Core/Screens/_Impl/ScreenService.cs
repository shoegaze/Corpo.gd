using System;

using Corpo.Adapters.Input.Concrete;
using Corpo.Adapters.Input.Helpers;
using Corpo.Adapters.Screens;
using Corpo.Adapters.Screens.Concrete;

using Godot;

using TeamSports.Logging;


namespace Corpo.Core.Screens._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class ScreenService(
  ILogger logger,
  IScreenWrapperService screenWrapperService
) : IScreenService {

  private readonly CorpoScreenManager screensManager = new();
  private ulong timePreviousMs = Time.GetTicksMsec();

  public ICorpoScreen? CurrentScreen => screensManager.CurrentScreen;
  // TODO
  // public ICorpoBaseScreen BaseScreen => screenManager.BaseScreen;

  public void UpdateScreens() {
    UpdateBaseScreen();

    // TODO: Update screens from CurrentScreen down to origin
    UpdateCurrentScreen();
  }

  public void UpdateBaseScreen() {
    throw new NotImplementedException();
  }

  // TODO: Call this in some _Update method
  public void UpdateCurrentScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;

    if (CurrentScreen is not null) {
      logger.Debug("Updating screen");

      // TODO: Poll only in Node:_Input()
      // TODO: Create InputService:GetInput
      CorpoInput input = InputHelper.PollInput();
      screensManager.CurrentScreen?.Tick(dt, input);
    }

    timePreviousMs = timeNowMs;
  }

  public void EnterScreen<TScreen>(bool focusImmediately = true)
  where TScreen : ICorpoScreen {
    logger.Debug($"Loading scene type: {typeof(TScreen)}");

    var screen = Main.BaseContainer.GetInstance<TScreen>();
    ICorpoScreenWrapper wrapper = screenWrapperService.Wrap(screen);

    logger.Debug($"Instantiated wrapper: {wrapper}");

    screen.OnCreate();

    logger.Info($"Entering screen: {screen}");
    logger.Debug($"Focusing immediately?: {focusImmediately}");

    screensManager.Enter(screen, focusImmediately);
    screenWrapperService.Wrap(screen);
  }

  public void ExitScreen() {
    if (screensManager.CurrentScreen is null) {
      logger.Error("No screen to dismiss", new InvalidOperationException());

      return;
    }

    ICorpoScreen previousScreen = screensManager.CurrentScreen;

    logger.Info($"Exiting: {previousScreen}");

    screensManager.Exit();
    screenWrapperService.FreeWrapper(previousScreen);
  }
}
