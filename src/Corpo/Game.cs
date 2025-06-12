using System;
using System.Linq;
using System.Reflection;

using Godot;

using Engine.Services;

using Corpo.Services;
using Corpo.Services.Environment;
using Corpo.Services.States;


namespace Corpo;


public partial class Game : Node {
  // Main entrypoint
  public override void _Ready() {
	// TODO(shoegaze): ServiceProvider.BuildLayer(layer); layer == 0 => Root Layer
	//  IEnumerable<bool> ServiceProvider.BuildServiceLayer(int layer >= 0)
	//    => ServiceProvider.SortServiceLayers() throws
	//    => while (!end) { ...; yield return; ... }
	//
	//  ServiceProvider.BuildService<S: Service>() -> ServiceBuildResult<:ok, ErrorContext>
	//
	//  Injector.Get<Type>() -> Type

	try {
	  // TODO(shoegaze): ServiceProvider.BuildServices() => & Services.Foreach(::OnBuild)
	  Assembly assembly =
		  AppDomain
			 .CurrentDomain
			 .GetAssemblies()
			 .ToList()
			 .Find(a => a.GetName().Name == "Corpo");

	  // var assembly = Assembly.GetAssembly();
	  ServiceProvider.BuildServices(assembly);

	  // TODO(shoegaze): Get<NodeService>().Register(this)

	  // TODO(shoegaze): Separate Godot/engine API with game
	  //  Get<SettingsService>().Register(
	  //    ProjectSettings.GlobalizePath("res://"))

	  // TODO(shoegaze): ServiceProvider.InitializeServices() => Services.ForEach(::OnInitialize)
	  InitializeServices();

	  // TODO(shoegaze): Service.IsSafe / Service.IsInitialized
	  //  We can safely use Service methods after services initialization
	}
	catch (Exception e) {
	  GD.PrintErr(e.Message);
	  GetTree().AutoAcceptQuit = true;

	  return;
	}

	// TODO(shoegaze): Use Get<LoggerService>().Info("...")
	GD.Print("Starting game ...");

	var stateService = ServiceProvider.Get<StateService>();
	stateService!.EnterState(GameState.Base);
  }


  // TODO(shoegaze): void Exit() { ServiceProvider.CloseServices(); }


  // TODO(shoegaze): Refactor out
  private void InitializeServices() {
	// TODO(shoegaze): ServiceProvider.Get<LoggerService>()
	GD.Print("Setting up services...");

	// Safe after ServiceProvider.BuildServices()
	var environmentService = ServiceProvider.Get<EnvironmentService>();

	environmentService!.Initialize(
		  ProjectSettings.GlobalizePath("res://")
		);

	var nodeService = ServiceProvider.Get<NodeService>();
	nodeService!.LoadNodes(this);

	// TODO(shoegaze): Attach view updater in rootNode process, etc.
  }
}
