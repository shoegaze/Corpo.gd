using Corpo.Base.Screens;
using Corpo.Base.States;


namespace Corpo.Base.Core.Models;


public class BaseLifecycle(
  IScreenService screenService
) : IStateLifecycle {
  public void OnSetUp() { }

  public void OnTearDown() {
    screenService.Dismiss();

    // TODO: Exit game
  }
}
