using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Screens.Bindings;


namespace Corpo.Adapters.TeamSports.Screens.Concrete;


public sealed partial class CorpoScreenWrapper(
  ICorpoScreen screen
) : GodotScreenWrapper<ICorpoScreen, CorpoUserInput>(screen), ICorpoScreenWrapper;
