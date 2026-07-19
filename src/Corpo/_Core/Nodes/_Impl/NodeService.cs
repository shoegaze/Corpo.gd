using Corpo._Core.Nodes.Models;


namespace Corpo._Core.Nodes._Impl;


public sealed class NodeService(
  ICorpoAppService appService
) : INodeService {
  public NodeTree Nodes { get; private set; }

  public void GodotStart(GodotStartContext<CorpoApp> ctx) {
    var root = appService.GetApp().RootNode;
    Nodes = new NodeTree(root);
  }
}
