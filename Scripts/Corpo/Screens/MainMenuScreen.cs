using Corpo.Screens.Core;
using Corpo.Services.Core;
using Corpo.Services.Environment;
using Corpo.Services.Screen;
using Corpo.Services.State;

using Godot;

using QuickType;

namespace Corpo.Screens;

public partial class MainMenuScreen : Screen {
  private Button buttonExit;
  private Button buttonLoadGame;

  private Button buttonNewGame;
  private Button buttonSettings;
  private EnvironmentService environmentService;
  private MainMenuService mainMenuService;
  private StateService stateService;

  public override void OnCreate() {
    environmentService = ServiceProvider.Get<EnvironmentService>();
    stateService = ServiceProvider.Get<StateService>();
    mainMenuService = ServiceProvider.Get<MainMenuService>();

    MainMenu mainMenuPaths = environmentService.Environment.Paths.Screens.MainMenu;

    buttonNewGame = GetNode(mainMenuPaths.Buttons.NewGame) as Button;
    buttonLoadGame = GetNode(mainMenuPaths.Buttons.LoadGame) as Button;
    buttonSettings = GetNode(mainMenuPaths.Buttons.Settings) as Button;
    buttonExit = GetNode(mainMenuPaths.Buttons.Exit) as Button;
  }

  public override void OnFocus() {
    buttonNewGame.Pressed += DoNewGame;
    // TODO(shoegaze): Disable `buttonLoadGame` if there is no save file
    buttonLoadGame.Pressed += DoLoadGame;
    buttonSettings.Pressed += DoSettings;
    buttonExit.Pressed += DoExit;
  }

  public override void OnDismiss() {
    buttonNewGame.Pressed -= DoNewGame;
    buttonLoadGame.Pressed -= DoLoadGame;
    buttonSettings.Pressed -= DoSettings;
    buttonExit.Pressed -= DoExit;
  }

  public override void Tick(float dt, GameInput? input) {}

  // TODO(shoegaze): Rename to StartGame()
  private void DoNewGame() {
    GD.Print("Starting new game ...");

    // TODO(shoegaze): Create new empty save and load
    //  DEBUG:
    stateService.EnterState(GameState.Battle);
  }

  // TODO(shoegaze): Rename to LoadGame()
  private void DoLoadGame() {
    mainMenuService.ToggleSavesSubmenu(this);
  }

  // TODO(shoegaze): Rename to OpenSettings()
  private void DoSettings() {
    mainMenuService.ToggleSettingsSubmenu(this);
  }

  // TODO(shoegaze): Rename to ExitGame()
  private void DoExit() {
    GD.Print("Exiting game ...");

    // TODO(shoegaze): GameService#ExitGame() => ServiceProvider.CloseAll()
    SceneTree sceneTree = GetTree();

    // TODO(shoegaze): Run method from service
    sceneTree
       .Root
       .PropagateNotification((int)NotificationWMCloseRequest);

    sceneTree.Quit();
  }
}
