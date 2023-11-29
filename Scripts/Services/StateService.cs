using System;
using System.Collections.Generic;
using System.Linq;
using Corpo.Scripts.Screens;
using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services.Core;
using Godot;
using BaseScreen = Corpo.Scripts.Screens.BaseScreen;

namespace Corpo.Scripts.Services; 

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class StateService : Service {
  private readonly ScreenService screenService;
      
  private readonly Stack<GameState> states = new();

  public StateService(ScreenService screenService) {
    this.screenService = screenService;
  }

  public void EnterState(GameState state) {
    states.Push(state);
    SetUp(state);
  }

  public void ExitState() {
    if (!states.Any()) {
      GD.PrintErr("No GameState to exit");
      throw new Exception("No GameState to exit");
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
    Screen screen = state switch {
                      GameState.Base => new BaseScreen(),
                      GameState.OverWorld => new OverworldScreen(),
                      GameState.Battle => new BattleScreen(),
                      _ => null
                    };

    if (screen == null) {
      GD.PrintErr($"Invalid GameState to set up: {state}");
      throw new ArgumentOutOfRangeException($"Invalid GameState to set up: {state}");
    }
    
    screenService.Enter(screen);
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
        GD.PrintErr($"Invalid GameState \"{state}\"");
        throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid GameState!");
    }
  }
}