using System;

using Corpo.Adapters.Input.Concrete;

using TeamSports.Entities.Screens;


namespace Corpo.Overworld._Impl;


// ReSharper disable once UnusedType.Global
public sealed class OverworldScreen : IOverworldScreen {
  public override string ToString() {
    return GetName();
  }

  public string GetName() {
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

  public void OnFocusIn(IScreen<CorpoInput> from) {
    throw new NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) {
    throw new NotImplementedException();
  }
}
