using Corpo.Adapters.TeamSports.Input.Concrete;

using Godot;

using TeamSports.Adapters.Godot.Screens.Bindings;


namespace Corpo.Adapters.TeamSports.Screens.Concrete;


public sealed partial class ScreenWrapper
  : GodotScreenWrapper<IScreen, CorpoInput>,
    IScreenWrapper {
  public static ScreenWrapper Build(
    IScreen screen,
    string? group = null,
    Node? parent = null
  ) {
    return GodotScreenWrapper<IScreen, CorpoInput>
     .Build<ScreenWrapper>(screen, group, parent);
  }
}
