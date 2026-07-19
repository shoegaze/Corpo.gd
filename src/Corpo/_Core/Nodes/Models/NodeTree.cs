namespace Corpo._Core.Nodes.Models;


public readonly record struct NodeTree(
  Godot.Node Root
) {
  public readonly Godot.Node Screens = Root.GetNode("Screens");

  // TODO:
  // public NodeTree(Godot.Node root, string screenQuery) : this(root) {
  //   Screens = Root.GetNode(screenQuery);
  // }
}
