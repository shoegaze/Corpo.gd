using Godot;

using TeamSports.Services;


namespace Corpo.Base.Nodes;


public interface INodeService : IService {
  Node MainNode { get; }


  void AttachMain(Node rootNode);
}
