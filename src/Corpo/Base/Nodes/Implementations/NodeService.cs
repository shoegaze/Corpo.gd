using Godot;


namespace Corpo.Base.Nodes.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class NodeService : INodeService {

  public Node MainNode { get; private set; }


  public void AttachMain(Node rootNode) {
    MainNode = rootNode;
  }
}
