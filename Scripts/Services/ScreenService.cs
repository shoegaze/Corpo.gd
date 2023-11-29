using System.Collections.Generic;
using System.Linq;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Services; 

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ScreenService : Service {
  private readonly NodeService nodeService;
  
  private readonly Stack<Screens.Core.Screen> screens = new();

  public Screens.Core.Screen CurrentScreen => screens.Any() ? screens.Peek() : null;

  public ScreenService(NodeService nodeService) {
    this.nodeService = nodeService;
  }

  // TODO(spike): Run this in the UI thread/coroutine?
  public void Tick(float dt) {
    CurrentScreen?.Tick(dt, GameInput.FromGlobal());   
  }

  public void Enter(Screens.Core.Screen screen) {
    GD.Print($"* Entering {screen}");
    
    nodeService.RootNode.AddChild(screen);
    
    screens.Push(screen);
    screen.OnCreate();
  }

  public void Dismiss() {
    if (screens.Count == 0) {
      GD.PrintErr("* No screen to dismiss!");
    }
    
    var previousScreen = screens.Pop();
    
    GD.Print($"* Exiting {previousScreen}");
    
    nodeService.RootNode.RemoveChild(previousScreen);
    previousScreen.OnDismiss();

    if (screens.Count == 0) {
      return;
    }
    
    var currentScreen = screens.Peek();
    currentScreen.OnFocus();
  }
}
