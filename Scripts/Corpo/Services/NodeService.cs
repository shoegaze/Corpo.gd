using Corpo.Services.Core;

using Godot;

namespace Corpo.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class NodeService : Service {
  // private readonly EnvironmentService environmentService;

  public Node RootNode { get; private set; }

  // public NodeService(EnvironmentService environmentService) {
  //   this.environmentService = environmentService;
  // }

  public void LoadNodes(Node rootNode) {
    RootNode = rootNode;
  }
}
