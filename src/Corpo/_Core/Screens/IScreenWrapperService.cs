using Corpo.Adapters.TeamSports.Input.Concrete;
using Corpo.Adapters.TeamSports.Screens;

using TeamSports.Adapters.Godot.Screens;


namespace Corpo._Core.Screens;


public interface IScreenWrapperService {
  ICorpoScreenWrapper Wrap(ICorpoScreen screen);

  void FreeWrapper(ICorpoScreen screen);

  // TODO:
  // IScreenWrapper GetWrapper(IScreen screen);
}
