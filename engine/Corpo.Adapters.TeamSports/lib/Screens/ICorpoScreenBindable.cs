using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Services;


namespace Corpo.Adapters.TeamSports.Screens;


public interface ICorpoScreenBindable<in TScreen>
  : IGodotScreenBindable<TScreen, CorpoInput>
where TScreen : ICorpoScreen;
