using System;

using Corpo.Services.Asset.Models;
using Corpo.Services.Core;
using Corpo.Services.Environment;

namespace Corpo.Services.Asset;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class OverworldResourcesService : Service {
  private readonly EnvironmentService environmentService;

  public OverworldResourcesService(
    EnvironmentService environmentService
  ) {
    this.environmentService = environmentService;
  }

  // TODO(shoegaze): Return IEnumerable<LoadResult> ?
  public void LoadAssets(LoadOverworldResourcesContext overworldResourcesContext) {
    // TODO(shoegaze);
    throw new NotImplementedException("TODO");
  }
}
