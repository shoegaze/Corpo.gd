using Corpo.Adaptors.Godot;
using Corpo.Base;
using Corpo.Base.Nodes;
using Corpo.Base.Screens;

using Godot;


namespace Corpo.Bootstrap.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BootstrapService : IBootstrapService {
  public GodotBaseScreen BaseScreen { get; private set; }


  public void AttachBaseScreen(Node mainNode, PackedScene baseScreen) {
    BaseScreen = baseScreen.Instantiate<BaseScreen>();

    BaseScreen.SetupRoot();

    BaseScreen.Services.GetInstance<INodeService>()
       .AttachMain(mainNode);

    BaseScreen.Services.GetInstance<IScreenService>()
       .Enter(BaseScreen);
  }
}
