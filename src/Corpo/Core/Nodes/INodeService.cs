using Godot;

using TeamSports.Adaptors.Godot.Services;


namespace Corpo.Core.Nodes;


public interface INodeService : IGodotStartable {
  Node RootContainer { get; }
  Node Screens { get; }

  void RegisterGameRoot(Node root);
  void InitializeContainers(Node root);
}
