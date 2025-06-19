using Corpo.Adaptors.Godot;

using Godot;


namespace Corpo.Bootstrap;


public interface IBootstrapService {
  GodotBaseScreen BaseScreen { get; }


  void AttachBaseScreen(Node mainNode, PackedScene baseScreen);
}
