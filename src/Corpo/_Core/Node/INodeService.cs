namespace Corpo._Core.Node;


public interface INodeService {
  Godot.Node RootContainer { get; }
  Godot.Node Screens { get; }

  // TODO:
  //  RootNodeWrapper Root {
  //    GetNode() => Godot.Node
  //    Children: RootNodeChildren
  //  }
  //
  //  RootNodeChildren Children {
  //    Screens: ScreensNodeWrapper
  //  }
}
