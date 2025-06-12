using System;

using Engine.Services;

using Corpo.Services.Environment;
using Corpo.Services.Loaders.Models;


namespace Corpo.Services.Loaders;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BattleResourcesService(
  EnvironmentService environmentService
) : Service {
  private readonly EnvironmentService environmentService = environmentService;

  public void LoadAssets(LoadBattleResourcesContext battleResourcesContext) {
    // TODO(shoegaze);
    throw new NotImplementedException("TODO");
  }
}
