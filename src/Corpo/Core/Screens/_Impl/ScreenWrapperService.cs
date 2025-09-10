using System;
using System.Collections.Generic;
using System.Linq;

using Corpo.Adapters.TeamSports.Logging;
using Corpo.Adapters.TeamSports.Screens;
using Corpo.Adapters.TeamSports.Screens.Concrete;
using Corpo.Core.Config;
using Corpo.Core.Node;


namespace Corpo.Core.Screens._Impl;


// ReSharper disable once UnusedType.Global
public class ScreenWrapperService(
  ILogger logger,
  IConfigService configService,
  INodeService nodeService
) : IScreenWrapperService {

  public IScreenWrapper Wrap(IScreen screen) {
    logger.Debug($"Creating screen wrapper for: {screen}");

    if (HasWrapper(screen)) {
      logger.Error(
        $"Duplicate screen wrapper found for: {screen}",
        new InvalidOperationException());

      return null!;
    }

    string screensGroup = configService.ConfigVars.Paths.Screens.Group;

    return ScreenWrapper.Build(
      screen,
      screensGroup,
      parent: nodeService.Screens);
  }

  private bool HasWrapper(IScreen screen) {
    return GetScreenWrappers()
     .ToList()
     .Any(wrapper => wrapper.Screen == screen);
  }

  public IScreenWrapper GetWrapper(IScreen screen) {
    var wrapper =
      GetScreenWrappers()
       .ToList()
       .Find(wrapper => wrapper.Screen == screen);


    if (wrapper is null) {
      logger.Error(
        $"Screen wrapper node of screen {screen} not found",
        new InvalidOperationException());
    }

    return wrapper!;
  }

  public void FreeWrapper(IScreen screen) {
    logger.Debug($"Freeing wrapper for screen: {screen}");

    GetWrapper(screen)
     .GetNode()
     .QueueFree();
  }

  private IEnumerable<IScreenWrapper> GetScreenWrappers() {
    string screensGroup =
      configService.ConfigVars.Paths.Screens.Group;

    // TODO?: Cache nodes and only validate when retrieving
    return nodeService.RootContainer
     .GetTree()
     .GetNodesInGroup(screensGroup)
     .OfType<IScreenWrapper>();
  }
}
