namespace Corpo.Base;


public interface IBaseService {
  // TODO: Make async
  // TODO: Move to Loader/Repository def.
  public void LoadPackages();
  public void DisposePackages();

  public void ShowMainMenu();
}
