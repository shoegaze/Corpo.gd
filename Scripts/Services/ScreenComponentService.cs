using System;
using System.Collections.Generic;
using Godot;

namespace Corpo.Scripts.Services;

public class ScreenComponentService : Service {
  // Assert Component ID == index
  private readonly List<ScreenComponent> Components = new();
  private int Cursor = -1;

  public ScreenComponent CurrentComponent => Cursor >= 0 ? Components[Cursor] : null;

  public ScreenComponentService() { }

  public int Add(ScreenComponent component) {
    var previousComponent = CurrentComponent;
    previousComponent?.OnUnfocus();

    Components.Add(component);
    component.OnFocus();

    return Components.Count - 1;
  }

  public void RemoveAll() {
    for (int i = Components.Count - 1; i >= 0; i--) {
      var component = Components[i];
      component.OnUnfocus();
      component.OnDestroy();

      Components.RemoveAt(Components.Count - 1);
    }

    Cursor = -1;
  }

  public void Seek(int index) {
    if (index < 0 || index >= Components.Count) {
      GD.PrintErr($"Cannot seek to the ScreenComponent at index ({index})");
      throw new IndexOutOfRangeException();
    }

    CurrentComponent.OnUnfocus();
    
    Cursor = index;
    CurrentComponent.OnFocus();
  }

  public void Tick(float dt) {
    foreach (ScreenComponent component in Components) {
      component.Update(dt);
    }
    
    CurrentComponent.Tick(dt, GameInput.FromGlobal());
  }
}
