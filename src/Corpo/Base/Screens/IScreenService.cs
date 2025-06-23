using Corpo.Core.Screens;

using TeamSports.Services;


namespace Corpo.Base.Screens;


public interface IScreenService : IService {

  ICorpoScreen CurrentScreen { get; }


  void UpdateScreen();

  void Enter(ICorpoScreen screen);

  void Dismiss();
}
