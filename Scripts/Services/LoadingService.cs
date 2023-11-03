namespace Corpo.Scripts.Services;

public class LoadingService : Service {
  public bool IsLoading { get; private set; }

  public LoadingService() {
    // TODO(spike)
    IsLoading = false;
  }
  
  // TODO(spike): SetLoading(bool state)
}
