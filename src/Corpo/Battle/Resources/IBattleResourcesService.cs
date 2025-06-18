using Corpo.Loading.Core.Models;


namespace Corpo.Battle.Resources;


public interface IBattleResourcesService {
  // TODO: Make async
  void LoadAssets(LoadBattleResourcesContext context);
}
