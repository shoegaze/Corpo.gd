using Engine.Services;


namespace Corpo.Base.Resources;


public interface IResourcesLoaderService : IService {
  // TODO: Make async
  void LoadAll();
}
