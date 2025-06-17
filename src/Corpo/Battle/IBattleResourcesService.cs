using Corpo.Loading;


namespace Corpo.Battle;


public interface IBattleResourcesService {
  // TODO: Make async
  void LoadAssets(LoadBattleResourcesContext context);
}
