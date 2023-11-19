using System;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class LoadingService : Service {
  public bool IsLoading { get; private set; }

  // TODO(spike): Inject services
  public LoadingService() {
    IsLoading = false;
  }
  
  public void RunProcess(Action action, Action onComplete) {
    if (IsLoading) {
      GD.PrintErr("Cannot do process: LoadingService is busy");
      return;
    }
    
    IsLoading = true;
    
    // TODO(spike): Run action in another thread/coroutine

    IsLoading = false;
  }
}
