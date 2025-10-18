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

  public ICorpoScreenWrapper Wrap(ICorpoScreen screen) {
    logger.Debug($"Creating screen wrapper for: {screen}");

    if (HasWrapper(screen)) {
      logger.Error(
        $"Duplicate screen wrapper found for: {screen}",
        new InvalidOperationException());

      return null!;
    }

    string screensGroup = configService.ConfigVars.Paths.Screens.Group;

    var wrapper = new CorpoScreenWrapper(screen);

    ScreenWrapperHelper.ConfigureGodotNode(
      wrapper,
      screensGroup,
      parent: nodeService.Screens);

    return wrapper;
  }

  private bool HasWrapper(ICorpoScreen corpoScreen) {
    return GetScreenWrappers()
     .ToList()
     .Any(wrapper => wrapper.InnerScreen == corpoScreen);
  }

  private ICorpoScreenWrapper GetWrapper(ICorpoScreen corpoScreen) {
    var wrapper =
      GetScreenWrappers()
       .ToList()
       .Find(wrapper => wrapper.InnerScreen == corpoScreen);


    if (wrapper is null) {
      logger.Error(
        $"Screen wrapper node of screen {corpoScreen} not found",
        new InvalidOperationException());
    }

    return wrapper!;
  }

  public void FreeWrapper(ICorpoScreen corpoScreen) {
    logger.Debug($"Freeing wrapper for screen: {corpoScreen}");

    GetWrapper(corpoScreen)
     .GetNode()
     .QueueFree();
  }

  private IEnumerable<ICorpoScreenWrapper> GetScreenWrappers() {
    string screensGroup =
      configService.ConfigVars.Paths.Screens.Group;

    // TODO?: Cache nodes and only validate when retrieving
    return nodeService.RootContainer
     .GetTree()
     .GetNodesInGroup(screensGroup)
     .OfType<ICorpoScreenWrapper>();
  }
}
