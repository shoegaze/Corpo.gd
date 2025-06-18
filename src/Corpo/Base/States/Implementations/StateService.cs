using System;
using System.Collections.Generic;

using Corpo.Base.Core.Models;
using Corpo.Base.Environments;
using Corpo.Base.Screens;
using Corpo.Battle;
using Corpo.Battle.Core.Models;
using Corpo.Overworld;
using Corpo.Overworld.Core.Models;

using TeamSports;
using TeamSports.Repositories.Handles;


namespace Corpo.Base.States.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class StateService(
  ILogger logger,
  IEnvironmentService environmentService,
  IScreenService screenService
) : IStateService {
  public enum GameState {
    Base,
    Overworld,
    Battle
  }

  private readonly Stack<GameState> states = new();
  private IStateLifecycle activeLifecycle;

  public void ExitState() {
    if (states.Count == 0) {
      logger.Error("No GameState to exit", new InvalidOperationException());

      return;
    }

    states.Pop();
    TearDownLifecycle();

    if (states.Count == 0) {
      return;
    }

    GameState stateNext = states.Peek();
    SetUpLifecycle(stateNext);
  }

  public void EnterState(GameState state) {
    states.Push(state);
    SetUpLifecycle(state);
  }

  private void SetUpLifecycle(GameState state) {
    activeLifecycle =
        state switch {
          GameState.Base => new BaseLifecycle(
                environmentService,
                screenService
              ),
          GameState.Overworld => new OverworldLifecycle( /* TODO */),
          GameState.Battle => new BattleLifecycle(
                environmentService,
                screenService
              ),
          _ => null
        };

    if (activeLifecycle == null) {
      logger.Error(
        $"Invalid game state setup: {state} ; Did you register {state}?",
        new InvalidOperationException());

      return;
    }

    activeLifecycle.OnSetUp();
  }

  private void TearDownLifecycle() {
    activeLifecycle?.OnTearDown();
  }
}
