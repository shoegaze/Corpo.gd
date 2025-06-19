using System;
using System.Collections.Generic;

using Corpo.Adaptors.Godot;

using TeamSports;


namespace Corpo.Base.Screens.Implementations;


public sealed class ScreenComponentService(
  ILogger logger
) : IScreenComponentService {
  // Assert Component ID == index
  private readonly List<GodotScreenComponent> components = [];
  private int cursor = -1;


  public GodotScreenComponent CurrentComponent =>
      cursor >= 0 ? components[cursor] : null;


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
      logger.Error(
        $"Cannot seek to the GodotScreenComponent at index={index:?}",
        new IndexOutOfRangeException());

      return;
    }

    CurrentComponent.OnUnfocus();

    cursor = index;
    CurrentComponent.OnFocus();
  }

  public void Tick(float dt) {
    foreach (GodotScreenComponent component in components) {
      component.Update(dt);
    }

    CorpoInput input = InputExtensions.PollInput();

    CurrentComponent.Tick(dt, input);
  }
}
