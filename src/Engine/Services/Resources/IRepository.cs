namespace Engine.Services.Resources;


public interface IRepository : IDisposable {
  string GetHandle( /* ResourceLoaderContext context */);

  void LoadAssets( /* ResourceLoaderContext context */);
  void LoadAssets(string handle);
}
