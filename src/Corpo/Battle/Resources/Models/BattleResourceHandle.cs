using TeamSports.Repositories.Handles;


namespace Corpo.Battle.Resources.Models;


public class BattleResourceHandle(
  string handle
) : ResourceHandle<BattleResourceHandleValidator>(handle);
