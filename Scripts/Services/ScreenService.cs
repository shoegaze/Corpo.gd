using System.Collections.Generic;
using System.Linq;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Services; 

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ScreenService : Service {
  private readonly NodeService nodeService;

  private readonly Stack<Screens.Core.Screen> screens = new();
  private ulong timePreviousMs = Time.GetTicksMsec();

  public Screens.Core.Screen CurrentScreen => screens.Any() ? screens.Peek() : null;

  public ScreenService(NodeService nodeService) {
    this.nodeService = nodeService;
  }
  
  private void Tick(float dt) {
    CurrentScreen?.Tick(dt, GameInput.FromGlobal());   
  }

  // TODO(spike): Call this in some _Update method 
  public void UpdateScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;
    
    Tick(dt);

    timePreviousMs = timeNowMs;
  }

  public void Enter(Screens.Core.Screen screen) {
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
    
    var previousScreen = screens.Pop();
    
    GD.Print($"* Exiting {previousScreen}");
    
    nodeService.RootNode.RemoveChild(previousScreen);
    previousScreen.OnDismiss();

    if (screens.Count == 0) {
      return;
    }
    
    var currentScreen = screens.Peek();
    
    GD.Print($"* Focusing on {currentScreen}");
    
    currentScreen.OnFocus();
  }
}
