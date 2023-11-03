using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Corpo.Scripts; 

public sealed class StateService : Service {
  private readonly Stack<GameState> states = new();

  // TODO(spike):
  // public override void _Ready() {
  //   EnterState(GameState.Base);
  // }

  public void EnterState(GameState state) {
    states.Push(state);
    SetUp(state);
  }

  public void ExitState() {
    if (!states.Any()) {
      throw new Exception("No GameState to exit!");
    }

    var state = states.Pop();
    TearDown(state);
  }

  public void ReplaceState(GameState state) {
    if (states.Any()) {
      ExitState();
    }
    
    EnterState(state);
  }

  private void SetUp(GameState state) {
    switch (state) {
      case GameState.Base: 
        GD.PrintErr("TODO(spike): Implement `Base` setup");
        return;
      
      case GameState.OverWorld:
        GD.PrintErr("TODO(spike): Implement `Overworld` setup");
        return;
      
      case GameState.Battle:
        GD.PrintErr("TODO(spike): Implement `Battle` setup");
        return;
      
      default:
        throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid GameState!");
    }
  }

  private void TearDown(GameState state) {
    switch (state) {
      case GameState.Base:
        GD.PrintErr("TODO(spike): Implement `Base` teardown");
        return;
      
      case GameState.OverWorld:
        GD.PrintErr("TODO(spike): Implement `Overworld` teardown");
        return;
      
      case GameState.Battle:
        GD.PrintErr("TODO(spike): Implement `Battle` teardown");
        return;
      
      default:
        throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid GameState!");
    }
  }
}