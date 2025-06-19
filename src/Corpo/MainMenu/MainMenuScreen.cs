using Corpo.Adaptors.Godot;
using Corpo.Base.Environments;
using Corpo.Base.States;
using Corpo.Base.States.Implementations;
using Corpo.MainMenu.Core;

using Godot;

using TeamSports;

using Button = Godot.Button;
using Container = Lamar.Container;


namespace Corpo.MainMenu;


public partial class MainMenuScreen : GodotScreen {
  private Container mainMenuContainer;

  // Dependencies
  private ILogger logger;
  private IEnvironmentService environmentService;
  private IStateService stateService;
  private IMainMenuService mainMenuService;

  // UI components
  private Button buttonExit;
  private Button buttonLoadGame;
  private Button buttonNewGame;
  private Button buttonSettings;

  public override string ToString() {
    return nameof(MainMenuScreen);
  }


  public override Container Services => mainMenuContainer;


  public override void OnCreate() {
    mainMenuContainer = BuildContainer<MainMenuRegistry>(logger);
    logger = mainMenuContainer.GetInstance<ILogger>();

    environmentService = mainMenuContainer.GetInstance<IEnvironmentService>();
    stateService = mainMenuContainer.GetInstance<IStateService>();
    mainMenuService = mainMenuContainer.GetInstance<IMainMenuService>();


    Generated.Json.Environment.MainMenu mainMenuPath =
        environmentService.Environment.Path.Screen.MainMenu;

    buttonNewGame = GetNode(mainMenuPath.Button.NewGame) as Button;
    buttonLoadGame = GetNode(mainMenuPath.Button.LoadGame) as Button;
    buttonSettings = GetNode(mainMenuPath.Button.Settings) as Button;
    buttonExit = GetNode(mainMenuPath.Button.Exit) as Button;
  }

  public override void OnFocus() {
    buttonNewGame.Pressed += DoNewGame;
    // TODO: Disable `buttonLoadGame` if there is no save file
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

  public override void Tick(float dt, GameInput? input) { }

  // TODO: Rename to StartGame()
  private void DoNewGame() {
    logger.Info("Starting new game ...");

    // TODO: Create new empty save and load
    //  DEBUG:
    stateService.EnterState(StateService.GameState.Battle);
  }

  // TODO: Rename to LoadGame()
  private void DoLoadGame() {
    logger.Info("Opening saves submenu");

    mainMenuService.ToggleSavesSubmenu(this);
  }

  // TODO: Rename to OpenSettings()
  private void DoSettings() {
    mainMenuService.ToggleSettingsSubmenu(this);
  }

  // TODO: Rename to ExitGame()
  private void DoExit() {
    logger.Info("Exiting game...");

    // TODO: GameService#ExitGame() => ServiceProvider.CloseAll()
    SceneTree sceneTree = GetTree();

    // TODO: Run method from service
    sceneTree
       .Root
       .PropagateNotification((int)NotificationWMCloseRequest);

    sceneTree.Quit();
  }
}
