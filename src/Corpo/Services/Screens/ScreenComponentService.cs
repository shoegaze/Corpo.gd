using System;
using System.Collections.Generic;

using Godot;

using Engine.Services;

using Corpo.Screens;


namespace Corpo.Services.Screens;


public sealed class ScreenComponentService : Service {
  // Assert Component ID == index
  private readonly List<GodotScreenComponent> components = [];
  private int cursor = -1;


  public GodotScreenComponent CurrentComponent => cursor >= 0 ? components[cursor] : null;


  // TODO(shoegaze): Inject services

  public int Add(GodotScreenComponent component) {
    GodotScreenComponent previousComponent = CurrentComponent;
    previousComponent?.OnUnfocus();

    components.Add(component);
    component.OnFocus();

    return components.Count - 1;
  }

  public void RemoveAll() {
    for (int i = components.Count - 1; i >= 0; i--) {
      GodotScreenComponent component = components[i];
      component.OnUnfocus();
      component.OnDestroy();

      components.RemoveAt(components.Count - 1);
    }

    cursor = -1;
  }

  public void Seek(int index) {
    if (index < 0 || index >= components.Count) {
      GD.PrintErr($"Cannot seek to the GodotScreenComponent at index ({index})");

      throw new IndexOutOfRangeException();
    }

    CurrentComponent.OnUnfocus();

    cursor = index;
    CurrentComponent.OnFocus();
  }

  public void Tick(float dt) {
    foreach (GodotScreenComponent component in components) {
      component.Update(dt);
    }

    CurrentComponent.Tick(dt, GameInput.FromGlobal());
  }
}
