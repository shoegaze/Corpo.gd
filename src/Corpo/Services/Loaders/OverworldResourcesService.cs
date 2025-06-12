using System;

using Engine.Services;

using Corpo.Services.Environment;
using Corpo.Services.Loaders.Models;


namespace Corpo.Services.Loaders;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class OverworldResourcesService(
  EnvironmentService environmentService
) : Service {
  private readonly EnvironmentService environmentService = environmentService;

  // TODO(shoegaze): Return IEnumerable<LoadResult> ?
  public void LoadAssets(LoadOverworldResourcesContext overworldResourcesContext) {
    // TODO(shoegaze);
    throw new NotImplementedException("TODO");
  }
}
