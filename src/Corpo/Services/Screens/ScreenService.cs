using System.Collections.Generic;

using Godot;

using Engine.Services;

using Corpo.Screens;


namespace Corpo.Services.Screens;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ScreenService(
  NodeService nodeService
) : Service {

  private readonly Stack<GodotScreen> screens = new();
  private ulong timePreviousMs = Time.GetTicksMsec();


  public GodotScreen CurrentScreen => screens.Count > 0 ? screens.Peek() : null;


  private void Tick(float dt) {
    CurrentScreen?.Tick(dt, GameInput.FromGlobal());
  }

  // TODO(shoegaze): Call this in some _Update method
  public void UpdateScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;

    Tick(dt);

    timePreviousMs = timeNowMs;
  }

  public void Enter(GodotScreen screen) {
    GD.Print($"* Entering {screen}");

    nodeService.RootNode.AddChild(screen);

    screens.Push(screen);
    screen.OnCreate();

    if (screen == CurrentScreen) {
      screen.OnFocus();
    }
  }

  public void Dismiss() {
    if (screens.Count == 0) {
      GD.PrintErr("* No screen to dismiss!");

      return;
    }

    GodotScreen previousScreen = screens.Pop();

    GD.Print($"* Exiting {previousScreen}");

    nodeService.RootNode.RemoveChild(previousScreen);
    previousScreen.OnDismiss();

    if (screens.Count == 0) {
      return;
    }

    GodotScreen currentScreen = screens.Peek();

    GD.Print($"* Focusing on {currentScreen}");

    currentScreen.OnFocus();
  }
}
