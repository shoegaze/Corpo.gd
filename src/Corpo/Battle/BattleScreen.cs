using System;

using Corpo._Core;


namespace Corpo.Battle;


public interface IBattleScreen : IScreen;

// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class BattleScreen : IBattleScreen {
  public void Tick(double dt, GameInput gameInput) {
    throw new NotImplementedException();
  }

  public override string ToString() {
    return GetEntityName();
  }

  public string GetEntityName() {
    return nameof(BattleScreen);
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

  public void OnFocusIn(IScreen<GameInput>? from) {
    throw new NotImplementedException();
  }

  public void OnFocusOut(IScreen<GameInput>? to) {
    throw new NotImplementedException();
  }

  public void Pause() {
    throw new NotImplementedException();
  }

  public void Unpause() {
    throw new NotImplementedException();
  }
}
