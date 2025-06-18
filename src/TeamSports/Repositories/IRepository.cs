using TeamSports.Repositories.Handles;


namespace TeamSports.Repositories;


public interface IRepository<out TResource, THandle> : IDisposable
where TResource : IDisposable
where THandle : IResourceHandle {
  THandle GetHandle( /* ResourceLoaderContext context */);

  // TODO?: Return IEnumerable<LoadResult>
  void LoadResources( /* ResourceLoaderContext context */);
  void LoadResource(THandle handle);

  TResource Get(THandle handle);
}
