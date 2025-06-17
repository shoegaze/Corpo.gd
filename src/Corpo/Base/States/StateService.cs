using System.Collections.Generic;

using Corpo.Base.Environments;
using Corpo.Base.Screens;
using Corpo.Battle;
using Corpo.Overworld;

using Engine;


namespace Corpo.Base.States;


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
      logger.Error("No GameState to exit");

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
        $"Invalid game state setup: {state} ; Did you register {state}?");

      return;
    }

    activeLifecycle.OnSetUp();
  }

  private void TearDownLifecycle() {
    activeLifecycle?.OnTearDown();
  }
}
