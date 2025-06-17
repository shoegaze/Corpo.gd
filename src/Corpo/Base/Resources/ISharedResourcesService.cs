using Corpo.Loading;

using Engine.Services;


namespace Corpo.Base.Resources;


public interface ISharedResourcesService : IService {
  // TODO: Make async
  // TODO: Return IEnumerable<LoadResult> ?
  public void LoadAssets(LoadSharedResourcesContext context);
}
