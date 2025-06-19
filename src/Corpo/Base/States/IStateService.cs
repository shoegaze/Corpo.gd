using Corpo.Base.States.Implementations;

using TeamSports.Services;


namespace Corpo.Base.States;


public interface IStateService : IService, IStartable {
  void EnterState(StateService.GameState state);
  void ExitState();
}
