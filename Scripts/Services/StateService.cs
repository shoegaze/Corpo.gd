using System;
using System.Collections.Generic;
using System.Linq;
using Corpo.Scripts.Screens;

namespace Corpo.Scripts.Services; 

public sealed class StateService : Service {
  private readonly ScreenService screenService;
      
  private readonly Stack<GameState> states = new();

  public StateService() {
    screenService = ServiceProvider.Get<ScreenService>();
    
    EnterState(GameState.Base);
  }

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
        screenService.Create(new BaseScreen());
        return;
      
      case GameState.OverWorld:
        screenService.Create(new OverworldScreen());
        return;
      
      case GameState.Battle:
        screenService.Create(new BattleScreen());
        return;
      
      default:
        throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid GameState!");
    }
  }

  private void TearDown(GameState state) {
    screenService.Dismiss();
    
    switch (state) {
      case GameState.Base:
        // TODO(spike)
        return;
      
      case GameState.OverWorld:
        // TODO(spike)
        return;
      
      case GameState.Battle:
        // TODO(spike)
        return;
      
      default:
        throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid GameState!");
    }
  }
}