using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Screens.Concrete;


namespace Corpo.Adapters.TeamSports.Screens.Concrete;


public class CorpoScreenManager
  : DefaultGodotScreenManager<
    ICorpoScreen,
    CorpoUserInput
  >;
