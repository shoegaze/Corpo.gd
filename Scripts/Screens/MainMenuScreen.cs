using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts; 

public partial class MainMenuScreen : Screen {
  private EnvironmentService environmentService;

  private Button buttonNewGame;
  private Button buttonLoadGame;
  private Button buttonSettings;
  private Button buttonExit;
  
  public override void OnCreate() {
    environmentService = ServiceProvider.Get<EnvironmentService>();
    
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
    buttonNewGame.Pressed += NewGame;
    buttonLoadGame.Pressed += LoadGame;
    buttonSettings.Pressed += Settings;
    buttonExit.Pressed += Exit;
  }

  public override void OnDismiss() {
    buttonNewGame.Pressed -= NewGame;
    buttonLoadGame.Pressed -= LoadGame;
    buttonSettings.Pressed -= Settings;
    buttonExit.Pressed -= Exit;
  }
  
  public override void Tick(float dt, GameInput? input) { }

  private void NewGame() {
    GD.Print("Starting new game ...");
    
    // TODO(spike)
  }

  private void LoadGame() {
    // TODO(spike)
  }

  private void Settings() {
    // TODO(spike)
  }

  private void Exit() {
    GD.Print("Exiting game ...");

    var sceneTree = GetTree();
    
    // TODO(spike): Run method from service
    sceneTree
       .Root
       .PropagateNotification((int)NotificationWMCloseRequest);
    
    sceneTree.Quit();
  }
}