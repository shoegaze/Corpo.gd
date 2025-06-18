using Corpo.Base.States.Implementations;

using Engine.Services;


namespace Corpo.Base.States;


public interface IStateService : IService {
  void EnterState(StateService.GameState state);
  void ExitState();
}
