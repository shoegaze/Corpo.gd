using Godot;

using TeamSports.Services;


namespace Corpo.Base.Nodes;


public interface INodeService : IService {

  Node RootNode { get; }


  void LoadRoot(Node rootNode);
}
