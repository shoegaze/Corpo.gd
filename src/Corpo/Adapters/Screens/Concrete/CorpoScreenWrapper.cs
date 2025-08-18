using Corpo.Adapters.Input.Concrete;
using Corpo.Adapters.Screens;

using Godot;

using TeamSports.Adaptors.Godot.Screens.Bindings;


namespace Corpo.Adaptors.Screens.Concrete;


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
