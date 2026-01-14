using Corpo._App;
using Corpo._Core.App;
using Corpo._Core.Node.Models;

using TeamSports.Adapters.Godot.App.Models;


namespace Corpo._Core.Node._Impl;


public sealed class NodeService(
  ICorpoAppService appService
) : INodeService {
  public NodeTree Nodes { get; private set; }

  public void GodotStart(GodotStartContext<CorpoApp> ctx) {
    var root = appService.GetApp().RootNode;
    Nodes = new NodeTree(root);
  }
}
