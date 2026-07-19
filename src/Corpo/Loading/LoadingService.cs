namespace Corpo.Loading;


public interface ILoadingService {
  bool IsLoading { get; }


  // TODO
  // async Task RunTask(Action action);
}

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class LoadingService : ILoadingService {
  // TODO
  public bool IsLoading => false;
}
