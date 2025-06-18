using Engine.Repositories;


namespace Corpo.Battle.Resources.Battle.Models;


public class BattleResourceHandle(
  string handle
) : ResourceHandle<BattleResourceHandleValidator>(handle);
