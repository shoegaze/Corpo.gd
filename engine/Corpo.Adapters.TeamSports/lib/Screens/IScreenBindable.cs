using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Services;


namespace Corpo.Adapters.TeamSports.Screens;


public interface IScreenBindable<in TScreen>
  : IGodotScreenBindable<TScreen, CorpoInput>
where TScreen : IScreen;
