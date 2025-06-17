using System;
using System.Collections.Generic;

using Corpo.Adaptors.Godot;
using Corpo.Base.Nodes;

using Engine;

using Godot;


namespace Corpo.Base.Screens;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ScreenService(
  ILogger logger,
  INodeService nodeService
) : IScreenService {

  private readonly Stack<GodotScreen> screens = new();
  private ulong timePreviousMs = Time.GetTicksMsec();


  public GodotScreen CurrentScreen => screens.Count > 0 ? screens.Peek() : null;


  // TODO: Call this in some _Update method
  public void UpdateScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;

    Tick(dt);

    timePreviousMs = timeNowMs;
  }

  public void Enter(GodotScreen screen) {
    logger.Info($"Entering: {screen}");

    nodeService.RootNode.AddChild(screen);

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

    GodotScreen previousScreen = screens.Pop();

    logger.Info($"Exiting: {previousScreen}");

    nodeService.RootNode.RemoveChild(previousScreen);
    previousScreen.OnDismiss();

    if (screens.Count == 0) {
      return;
    }

    GodotScreen currentScreen = screens.Peek();

    logger.Debug($"Focus on: {currentScreen}");

    currentScreen.OnFocus();
  }

  private void Tick(float dt) {
    CurrentScreen?.Tick(dt, GameInput.FromGlobal());
  }
}
