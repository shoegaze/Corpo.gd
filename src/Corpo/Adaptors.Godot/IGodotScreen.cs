using Godot;

using TeamSports.Screens;


namespace Corpo.Adaptors.Godot;


public interface IGodotScreen : IScreen<CorpoInput> {
  Node ToNode();
}
