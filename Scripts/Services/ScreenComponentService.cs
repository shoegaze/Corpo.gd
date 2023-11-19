using System;
using System.Collections.Generic;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Services;

public sealed class ScreenComponentService : Service {
  // Assert Component ID == index
  private readonly List<Screens.Core.ScreenComponent> components = new();
  private int cursor = -1;

  public Screens.Core.ScreenComponent CurrentComponent => cursor >= 0 ? components[cursor] : null;

  // TODO(spike): Inject services
  public ScreenComponentService() { }

  public int Add(Screens.Core.ScreenComponent component) {
    var previousComponent = CurrentComponent;
    previousComponent?.OnUnfocus();

    components.Add(component);
    component.OnFocus();

    return components.Count - 1;
  }

  public void RemoveAll() {
    for (int i = components.Count - 1; i >= 0; i--) {
      var component = components[i];
      component.OnUnfocus();
      component.OnDestroy();

      components.RemoveAt(components.Count - 1);
    }

    cursor = -1;
  }

  public void Seek(int index) {
    if (index < 0 || index >= components.Count) {
      GD.PrintErr($"Cannot seek to the ScreenComponent at index ({index})");
      throw new IndexOutOfRangeException();
    }

    CurrentComponent.OnUnfocus();
    
    cursor = index;
    CurrentComponent.OnFocus();
  }

  public void Tick(float dt) {
    foreach (Screens.Core.ScreenComponent component in components) {
      component.Update(dt);
    }
    
    CurrentComponent.Tick(dt, GameInput.FromGlobal());
  }
}
