using TeamSports.Services;


namespace Corpo.Base.Core;


public interface IBaseService : IService {
  // TODO: Make async
  // TODO: Move to Loader/Repository def.
  public void LoadPackages();

  public void ShowMainMenu();
}
