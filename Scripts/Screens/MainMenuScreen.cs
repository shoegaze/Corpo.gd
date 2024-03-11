using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Corpo.Scripts.Services.Screen;
using Corpo.Scripts.Services.State;
using Godot;

namespace Corpo.Scripts.Screens; 

public partial class MainMenuScreen : Screen {
  private EnvironmentService environmentService;
  private StateService stateService;
  private MainMenuService mainMenuService;

  private Button buttonNewGame;
  private Button buttonLoadGame;
  private Button buttonSettings;
  private Button buttonExit;
  
  public override void OnCreate() {
    environmentService = ServiceProvider.Get<EnvironmentService>();
    stateService = ServiceProvider.Get<StateService>();
    mainMenuService = ServiceProvider.Get<MainMenuService>();

    var mainMenuPaths = environmentService.Environment.Paths.Screens.MainMenu;
    
    buttonNewGame = GetNode(mainMenuPaths.Buttons.NewGame) as Button;
    buttonLoadGame = GetNode(mainMenuPaths.Buttons.LoadGame) as Button;
    buttonSettings = GetNode(mainMenuPaths.Buttons.Settings) as Button;
    buttonExit = GetNode(mainMenuPaths.Buttons.Exit) as Button;
  }

  public override void OnFocus() {
    buttonNewGame.Pressed += DoNewGame;
    // TODO(spike): Disable `buttonLoadGame` if there is no save file
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

  private void DoNewGame() {
    GD.Print("Starting new game ...");
    
    // TODO(spike): Create new empty save and load
    //  DEBUG:
    stateService.EnterState(GameState.Battle);
  }

  private void DoLoadGame() {
    mainMenuService.ToggleSavesSubmenu(this);
  }

  private void DoSettings() {
    mainMenuService.ToggleSettingsSubmenu(this);
  }

  private void DoExit() {
    GD.Print("Exiting game ...");

    var sceneTree = GetTree();
    
    // TODO(spike): Run method from service
    sceneTree
       .Root
       .PropagateNotification((int)NotificationWMCloseRequest);
    
    sceneTree.Quit();
  }
}