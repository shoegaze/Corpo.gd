using System;
using System.Collections.Generic;
using System.Linq;

using Corpo._Core.Config;
using Corpo._Core.Node;
using Corpo.Adapters.TeamSports.Logging;
using Corpo.Adapters.TeamSports.Screens;
using Corpo.Adapters.TeamSports.Screens.Concrete;

using TeamSports.Adapters.Godot.Screens.Bindings.Helpers;


namespace Corpo._Core.Screens._Impl;


// ReSharper disable once UnusedType.Global
public class ScreenWrapperService(
  ILogger logger,
  IConfigService configService,
  INodeService nodeService
) : IScreenWrapperService {
  private string ScreensGroup => configService.ConfigVars.Paths.Screens.Group;

  public ICorpoScreenWrapper Wrap(ICorpoScreen screen) {
    logger.Debug($"Creating screen wrapper for: {screen}");

    if (HasWrapper(screen)) {
      logger.Error(
        $"Duplicate screen wrapper found for: {screen}",
        new InvalidOperationException());

      return null!;
    }

    var wrapper = new CorpoScreenWrapper(screen);

    ScreenWrapperHelper.ConfigureGodotNode(
      wrapper,
      group: ScreensGroup,
      parent: nodeService.Nodes.Screens);

    return wrapper;
  }

  private bool HasWrapper(ICorpoScreen screen) {
    return GetScreenWrappers()
     .ToList()
     .Any(wrapper => wrapper.InnerScreen == screen);
  }

  private ICorpoScreenWrapper GetWrapper(ICorpoScreen screen) {
    var wrapper =
      GetScreenWrappers()
       .ToList()
       .Find(wrapper => wrapper.InnerScreen == screen);


    if (wrapper is null) {
      logger.Error(
        $"Screen wrapper node of screen {screen} not found",
        new InvalidOperationException());
    }

    return wrapper!;
  }

  public void FreeWrapper(ICorpoScreen screen) {
    logger.Debug($"Freeing wrapper for screen: {screen}");

    GetWrapper(screen)
     .GetNode()
     .QueueFree();
  }

  private IEnumerable<ICorpoScreenWrapper> GetScreenWrappers() {
    // TODO?: Cache nodes and only validate when retrieving
    return nodeService.Nodes.Root
     .GetTree()
     .GetNodesInGroup(ScreensGroup)
     .OfType<ICorpoScreenWrapper>();
  }
}
