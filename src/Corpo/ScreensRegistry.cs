using Corpo.Base;
using Corpo.Battle;
using Corpo.Loading;
using Corpo.MainMenu;
using Corpo.Overworld;

using Lamar;


namespace Corpo;


public class ScreensRegistry : ServiceRegistry {
  public ScreensRegistry() {
    IncludeRegistry<BaseRegistry>();

    // UI screens
    IncludeRegistry<LoadingRegistry>();
    IncludeRegistry<MainMenuRegistry>();

    // Game screens
    IncludeRegistry<OverworldRegistry>();
    IncludeRegistry<BattleRegistry>();
  }
}
