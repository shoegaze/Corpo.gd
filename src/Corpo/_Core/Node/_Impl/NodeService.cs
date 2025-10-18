namespace Corpo._Core.Node._Impl;


public sealed class NodeService : INodeService {
  public Godot.Node RootContainer { get; } = null!;
  public Godot.Node Screens { get; } = null!;
}
