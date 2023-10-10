using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Godot;

namespace Corpo.Scripts; 

public class StateService : Service {
  private readonly Stack<GameState> states = new();

  public GameState ActiveState => states.Peek();

  public override void _Ready() {
    EnterState(GameState.Base);
  }

  public void EnterState(GameState state) {
    states.Push(state);
    SetUp(state);
  }

  public void ExitState() {
    Debug.Assert(states.Any());

    var state = states.Pop();
    TearDown(state);
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
    
    // TODO(spike): Isolate input and process for active game state
    //  IsolatorService.ActiveScreen += TODO_Screen;
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
    
    // TODO(spike): Isolate input and process for active game state
    //  IsolatorService.ActiveScreen -= TODO_Screen;
  }
}