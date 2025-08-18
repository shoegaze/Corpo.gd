using Corpo.Base;
using Corpo.Battle;
using Corpo.Loading;
using Corpo.MainMenu;
using Corpo.Overworld;

using Lamar;


namespace Corpo;


public class ScreensRegistry : ServiceRegistry {
  public ScreensRegistry() {
    // Base Functions
    IncludeRegistry<BaseRegistry>();

    // Interface
    IncludeRegistry<LoadingRegistry>();
    IncludeRegistry<MainMenuRegistry>();

    // Gameplay
    IncludeRegistry<BattleRegistry>();
    IncludeRegistry<OverworldRegistry>();
  }
}
