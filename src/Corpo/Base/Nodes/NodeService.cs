using Godot;


namespace Corpo.Base.Nodes;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class NodeService : INodeService {

  public Node RootNode { get; private set; }


  public void LoadRoot(Node rootNode) {
    RootNode = rootNode;
  }
}
