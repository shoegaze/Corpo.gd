using Corpo.Adapters.TeamSports.Input.Concrete;

using Godot;

using TeamSports.Adapters.Godot.Screens.Bindings;


namespace Corpo.Adapters.TeamSports.Screens.Concrete;


public sealed partial class CorpoScreenWrapper
  : GodotScreenWrapper<ICorpoScreen, CorpoInput>,
    ICorpoScreenWrapper {
  public static CorpoScreenWrapper Build(
    ICorpoScreen screen,
    string? group = null,
    Node? parent = null
  ) {
    return GodotScreenWrapper<ICorpoScreen, CorpoInput>
     .Build<CorpoScreenWrapper>(screen, group, parent);
  }
}
