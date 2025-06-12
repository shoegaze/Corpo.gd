namespace Corpo.Services.Loaders.Models;

public interface IResourceLoader {
  // TODO(shoegaze): Return IEnumerable<LoadResult>
  void LoadAssets(/* ResourceLoaderContext context */);
  void LoadAssets(string handle);

  string GetHandle(/* ResourceLoaderContext context */);
}
