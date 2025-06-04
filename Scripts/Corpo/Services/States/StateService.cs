using System;
using System.Collections.Generic;
using System.Linq;

using Corpo.Services.Core;
using Corpo.Services.Environment;
using Corpo.Services.Screens.Core;
using Corpo.Services.States.Lifecycle;

using Godot;


namespace Corpo.Services.States;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class StateService : Service {
  private readonly EnvironmentService environmentService;
  private readonly ScreenService screenService;

  private readonly Stack<GameState> states = new();
  private IStateLifecycle activeLifecycle;

  public StateService(
    EnvironmentService environmentService,
    ScreenService screenService
  ) {
    this.environmentService = environmentService;
    this.screenService = screenService;
  }

  public void EnterState(GameState state) {
    states.Push(state);
    SetUpLifecycle(state);
  }

  public void ExitState() {
    if (!states.Any()) {
      GD.PrintErr("No GameState to exit");

      throw new Exception("No GameState to exit");
    }

    states.Pop();
    TearDownLifecycle();

    if (!states.Any()) {
      return;
    }

    GameState stateNext = states.Peek();
    SetUpLifecycle(stateNext);
  }

  private void SetUpLifecycle(GameState state) {
    activeLifecycle = state switch {
      GameState.Base => new BaseLifecycle(environmentService,
                                          screenService),
      GameState.OverWorld => new OverworldLifecycle( /* TODO(shoegaze) */),
      GameState.Battle => new BattleLifecycle(environmentService,
                                              screenService),
      _ => null
    };

    if (activeLifecycle == null) {
      GD.PrintErr(
        $"Invalid GameState to setup: {state}. Did you forget to register {state}?");

      throw new ArgumentOutOfRangeException($"Invalid GameState to set up: {state}");
    }

    activeLifecycle.OnSetUp();
  }

  private void TearDownLifecycle() {
    activeLifecycle?.OnTearDown();
  }
}
