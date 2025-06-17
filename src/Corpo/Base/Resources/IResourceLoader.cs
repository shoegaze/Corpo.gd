namespace Corpo.Base.Resources;


public interface IResourceLoader {
  // TODO: Make async
  void LoadAssets( /* ResourceLoaderContext context */);
  void LoadAssets(string handle);

  string GetHandle( /* ResourceLoaderContext context */);
}
