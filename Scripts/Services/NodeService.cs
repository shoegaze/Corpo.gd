using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public class NodeService : Service {
  private readonly EnvironmentService environmentService;

  public Node RootNode { get; private set; }

  public NodeService(EnvironmentService environmentService) {
    this.environmentService = environmentService;
  }

  public void LoadNodes(Node rootNode) {
    RootNode = rootNode;
  }
}
