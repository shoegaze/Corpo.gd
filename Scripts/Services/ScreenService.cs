using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Corpo.Scripts.Services; 

public sealed class ScreenService : Service {
  private Stack<Screen> Screens = new();

  public Screen CurrentScreen => Screens.Any() ? Screens.Peek() : null;

  public ScreenService() { }

  public void Tick(float dt) {
    CurrentScreen?.Tick(dt, GameInput.FromGlobal());   
  }

  public void Create(Screen screen) {
    Screens.Push(screen);
    screen.OnCreate();
  }

  public void Dismiss() {
    if (Screens.Count == 0) {
      GD.PrintErr("No screen to dismiss!");
    }
    
    var previousScreen = Screens.Pop();
    previousScreen.OnDismiss();

    if (Screens.Count == 0) {
      return;
    }
    
    var currentScreen = Screens.Peek();
    currentScreen.OnFocus();
  }
}
