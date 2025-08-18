using System;

using Godot;

using TeamSports.Logging;


namespace Corpo.Core.Nodes._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class NodeService(
  ILogger logger
) : INodeService {
  private const string ScreensRootName = "Screens";

  public Node RootContainer { get; private set; } = null!;
  public Node Screens { get; private set; } = null!;

  public void GodotStart(Node rootNode) {
    RegisterGameRoot(rootNode);
  }

  public void RegisterGameRoot(Node node) {
    logger.Debug($"Attaching root node: {node}");

    // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
    if (RootContainer is not null) {
      logger.Error("Root node is already set", new InvalidOperationException());

      return;
    }

    RootContainer = node;
    InitializeContainers(RootContainer);
  }

  public void InitializeContainers(Node root) {
    AttachScreensRoot(root);
  }

  private void AttachScreensRoot(Node root) {
    Screens = new Node();
    Screens.SetName(ScreensRootName);

    root.AddChild(Screens);
  }
}
