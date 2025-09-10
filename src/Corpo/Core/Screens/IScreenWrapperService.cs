using Corpo.Adapters.TeamSports.Screens;


namespace Corpo.Core.Screens;


public interface IScreenWrapperService {
  IScreenWrapper Wrap(IScreen screen);
  IScreenWrapper GetWrapper(IScreen screen);
  void FreeWrapper(IScreen screen);
}
