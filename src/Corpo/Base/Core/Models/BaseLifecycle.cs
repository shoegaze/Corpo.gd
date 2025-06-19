using Corpo.Adaptors.Godot;
using Corpo.Base.Environments;
using Corpo.Base.Screens;
using Corpo.Base.States;

using Godot;


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
