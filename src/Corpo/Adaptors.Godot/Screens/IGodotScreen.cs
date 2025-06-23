using Godot;

using TeamSports.Screens;


namespace Corpo.Adaptors.Godot.Screens;


public interface IGodotScreen<in TInput> : IScreen<TInput>
where TInput : struct {
  Node ToNode();
}
