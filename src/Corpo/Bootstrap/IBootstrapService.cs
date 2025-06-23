using Godot;

using CorpoBaseScreen = Corpo.Core.Screens.CorpoBaseScreen;


namespace Corpo.Bootstrap;


public interface IBootstrapService {
  CorpoBaseScreen BaseScreen { get; }


  void AttachBaseScreen(Node mainNode, PackedScene baseScreen);
}
