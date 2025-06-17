using Corpo.Loading;

using Engine.Services;


namespace Corpo.Overworld;


public interface IOverworldResourcesService : IService {
  // TODO: Make async
  // TODO: Return IEnumerable<LoadResult>
  void LoadAssets(LoadOverworldResourcesContext context);
}
