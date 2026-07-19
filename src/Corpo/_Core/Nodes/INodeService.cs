using Corpo._Core.Nodes.Models;


namespace Corpo._Core.Nodes;


public interface INodeService : IGodotStartable<CorpoApp> {
  NodeTree Nodes { get; }
}
