using Corpo.Loading.Models;

using TeamSports.Services;


namespace Corpo.Overworld;


public interface IOverworldResourcesService : IService {
  // TODO: Make async
  // TODO: Return IEnumerable<LoadResult>
  void LoadAssets(LoadOverworldResourcesContext context);
}
