using System;

using Corpo.Services.Asset.Models;
using Corpo.Services.Core;
using Corpo.Services.Environment;

namespace Corpo.Services.Asset;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BattleResourcesService : Service {
  private readonly EnvironmentService environmentService;

  public BattleResourcesService(
    EnvironmentService environmentService
  ) {
    this.environmentService = environmentService;
  }

  public void LoadAssets(LoadBattleResourcesContext battleResourcesContext) {
    // TODO(shoegaze);
    throw new NotImplementedException("TODO");
  }
}
