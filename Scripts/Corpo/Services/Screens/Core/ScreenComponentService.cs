using System;
using System.Collections.Generic;

using Corpo.Screens.Core;
using Corpo.Services.Core;

using Godot;


namespace Corpo.Services.Screens.Core;

public sealed class ScreenComponentService : Service {
  // Assert Component ID == index
  private readonly List<ScreenComponent> components = new();
  private int cursor = -1;

  public ScreenComponent CurrentComponent => cursor >= 0 ? components[cursor] : null;

  // TODO(shoegaze): Inject services

  public int Add(ScreenComponent component) {
    ScreenComponent previousComponent = CurrentComponent;
    previousComponent?.OnUnfocus();

    components.Add(component);
    component.OnFocus();

    return components.Count - 1;
  }

  public void RemoveAll() {
    for (int i = components.Count - 1; i >= 0; i--) {
      ScreenComponent component = components[i];
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
    foreach (ScreenComponent component in components) {
      component.Update(dt);
    }

    CurrentComponent.Tick(dt, GameInput.FromGlobal());
  }
}
