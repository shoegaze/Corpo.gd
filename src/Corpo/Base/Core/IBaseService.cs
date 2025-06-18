using TeamSports.Services;


namespace Corpo.Base.Core;


public interface IBaseService : IService {
  // TODO: Make async
  public void LoadPackages();
  public void ShowMainMenu();
}
