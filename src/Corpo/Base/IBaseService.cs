using Engine.Services;


namespace Corpo.Base;


public interface IBaseService : IService {
  // TODO: Make async
  public void LoadPackages();
  public void ShowMainMenu();
}
