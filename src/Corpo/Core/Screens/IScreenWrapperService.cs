using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.Core.Screens;


public interface IScreenWrapperService {
  ICorpoScreenWrapper Wrap(ICorpoScreen screen);
  ICorpoScreenWrapper GetWrapper(ICorpoScreen screen);
  void FreeWrapper(ICorpoScreen screen);
}
