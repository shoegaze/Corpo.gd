using Corpo.Adapters.Input.Concrete;
using Corpo.Adapters.Screens;

using TeamSports.Adaptors.Godot.Services;


namespace Corpo.Adapters.Services;


public interface ICorpoScreenBindable<TScreen>
  : IGodotScreenBindable<TScreen, CorpoInput>
where TScreen : ICorpoScreen;
