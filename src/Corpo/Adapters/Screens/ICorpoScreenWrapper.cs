using Corpo.Adapters.Input.Concrete;

using TeamSports.Adaptors.Godot.Screens;


namespace Corpo.Adapters.Screens;


public interface ICorpoScreenWrapper
  : IGodotScreenWrapper<ICorpoScreen, CorpoInput>;
