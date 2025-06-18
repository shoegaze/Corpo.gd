using Corpo.Loading.Core.Models;

using Engine.Services;


namespace Corpo.Overworld.Resources;


public interface IOverworldResourcesService : IService {
  // TODO: Make async
  // TODO: Return IEnumerable<LoadResult>
  void LoadAssets(LoadOverworldResourcesContext context);
}
