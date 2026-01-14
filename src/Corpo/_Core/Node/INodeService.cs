using Corpo._App;
using Corpo._Core.Node.Models;

using TeamSports.Adapters.Godot.Services;


namespace Corpo._Core.Node;


public interface INodeService : IGodotStartable<CorpoApp> {
  NodeTree Nodes { get; }
}
