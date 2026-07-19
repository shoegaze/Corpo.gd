using System;

using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Core.Entities.Screens;


namespace Corpo.Overworld;


public interface IOverworldScreen : IScreen;

// ReSharper disable once UnusedType.Global
public sealed class OverworldScreen : IOverworldScreen {
  public void Tick(double dt, UserInput input) {
    throw new NotImplementedException();
  }

  public override string ToString() {
    return GetEntityName();
  }

  public string GetEntityName() {
    return nameof(OverworldScreen);
  }

  public void OnCreate() {
    throw new NotImplementedException();
  }

  public void OnDestroy() {
    throw new NotImplementedException();
  }

  public void OnMount() {
    throw new NotImplementedException();
  }

  public void OnUnmount() {
    throw new NotImplementedException();
  }

  public void OnFocusIn(IScreen<UserInput>? from) {
    throw new NotImplementedException();
  }

  public void OnFocusOut(IScreen<UserInput>? to) {
    throw new NotImplementedException();
  }

  public void Pause() {
    throw new NotImplementedException();
  }

  public void Unpause() {
    throw new NotImplementedException();
  }
}
