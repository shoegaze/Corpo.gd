#nullable enable

using System;

using Corpo.Adaptors.Godot;
using Corpo.Base.Nodes;
using Corpo.Core;
using Corpo.Core.Screens;

using Godot;

using TeamSports;


namespace Corpo.Base.Screens.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ScreenService(
  ILogger logger,
  INodeService nodeService
) : IScreenService {

  private readonly CorpoScreenManager screenManager = new();
  private ulong timePreviousMs = Time.GetTicksMsec();


  public ICorpoScreen? CurrentScreen => screenManager.CurrentScreen;


  // TODO: Call this in some _Update method
  public void UpdateScreen() {
    ulong timeNowMs = timePreviousMs;
    float dt = (timeNowMs - timePreviousMs) / 1000.0f;

    if (CurrentScreen is not null) {
      logger.Debug("Updating screen");

      // TODO: Poll only in Node:_Input()
      // TODO: Create InputService:GetInput
      CorpoInput input = InputHelper.PollInput();
      screenManager.CurrentScreen?.Tick(dt, input);
    }

    timePreviousMs = timeNowMs;
  }

  public void Enter(ICorpoScreen screen) {
    logger.Info($"Entering: {screen}");

    screenManager.Enter(screen);
    nodeService.MainNode.AddChild(screen.ToNode());
  }

  public void Dismiss() {
    if (screenManager.CurrentScreen is null) {
      logger.Error("No screen to dismiss", new InvalidOperationException());

      return;
    }

    ICorpoScreen? previousScreen = screenManager.CurrentScreen;

    logger.Info($"Exiting: {previousScreen}");

    screenManager.Dismiss();
    nodeService.MainNode.RemoveChild(previousScreen.ToNode());
  }
}
