using Corpo.Adapters.Input.Concrete;

using TeamSports.Entities.Screens;


namespace Corpo.Battle._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class BattleScreen : IBattleScreen {
  public override string ToString() {
    return GetName();
  }

  public string GetName() {
    return nameof(BattleScreen);
  }

  public void OnCreate() {
    throw new System.NotImplementedException();
  }

  public void OnDestroy() {
    throw new System.NotImplementedException();
  }

  public void OnMount() {
    throw new System.NotImplementedException();
  }

  public void OnUnmount() {
    throw new System.NotImplementedException();
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    throw new System.NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) {
    throw new System.NotImplementedException();
  }
}
