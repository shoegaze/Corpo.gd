using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Corpo.Scripts.Services.State;
using Godot;

namespace Corpo.Scripts; 

public partial class MainMenuScreen : Screen {
  private EnvironmentService environmentService;
  private StateService stateService;

  private Button buttonNewGame;
  private Button buttonLoadGame;
  private Button buttonSettings;
  private Button buttonExit;
  
  public override void OnCreate() {
    environmentService = ServiceProvider.Get<EnvironmentService>();
    stateService = ServiceProvider.Get<StateService>();
    
    // TODO(spike): Get paths from environmentService
    var uiRoot = GetNode("UiRoot");
    var buttonsRoot = uiRoot.GetNode(
      "TitleCard_Margin/TitleCard_Layout/" + 
      "Buttons_Margin/Buttons_Layout"
    );
    
    buttonNewGame = buttonsRoot.GetNode("NewGame_Button") as Button;
    buttonLoadGame = buttonsRoot.GetNode("LoadGame_Button") as Button;
    buttonSettings = buttonsRoot.GetNode("Settings_Button") as Button;
    buttonExit = buttonsRoot.GetNode("Exit_Button") as Button;
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
    // TODO(spike): Open the `SavesList` sub-menu
    GD.Print("TODO(spike): Open the `SavesList` sub-menu");
  }

  private void DoSettings() {
    // TODO(spike): Open the `Settings` sub-menu
    GD.Print("TODO(spike): Open the `Settings` sub-menu");
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