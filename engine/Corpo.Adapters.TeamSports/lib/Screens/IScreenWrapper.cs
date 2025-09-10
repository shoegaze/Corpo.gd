using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Screens;


namespace Corpo.Adapters.TeamSports.Screens;


public interface IScreenWrapper
  : IGodotScreenWrapper<IScreen, CorpoInput>;
