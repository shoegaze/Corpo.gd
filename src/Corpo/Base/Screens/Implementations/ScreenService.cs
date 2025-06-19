using System;
using System.Collections.Generic;

using Corpo.Adaptors.Godot;
using Corpo.Base.Nodes;

using Godot;

using Lamar;

using TeamSports;


namespace Corpo.Base.Screens.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ScreenService(
  ILogger logger,
  INodeService nodeService
) : IScreenService {

  private readonly Stack<IGodotScreen> screens = new();
  private ulong timePreviousMs = Time.GetTicksMsec();


  public IGodotScreen CurrentScreen =>
      screens.Count > 0 ? screens.Peek() : null;


  public void AttachRoot(IGodotScreen screen) {
    screens.Push(screen);

    screen.OnFocus();
  }

  // TODO: Call this in some _Update method
  public void UpdateScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;

    Tick(dt);

    timePreviousMs = timeNowMs;
  }

  public void Enter<T>(GodotScreen<T> screen)
  where T : ServiceRegistry, new() {
    logger.Info($"Entering: {screen}");

    nodeService.MainNode.AddChild(screen);

    screens.Push(screen);
    screen.OnCreate();

    if (screen == CurrentScreen) {
      screen.OnFocus();
    }
  }

  public void Dismiss() {
    if (screens.Count == 0) {
      logger.Error("No screen to dismiss", new InvalidOperationException());

      return;
    }

    IGodotScreen previousScreen = screens.Pop();

    logger.Info($"Exiting: {previousScreen}");

    nodeService.MainNode.RemoveChild(previousScreen.ToNode());
    previousScreen.OnDismiss();

    if (screens.Count == 0) {
      return;
    }

    IGodotScreen currentScreen = screens.Peek();

    logger.Debug($"Focus on: {currentScreen}");

    currentScreen.OnFocus();
  }

  private void Tick(float dt) {
    CorpoInput input = InputExtensions.PollInput();

    CurrentScreen?.Tick(dt, input);
  }
}
