using TeamSports.Services;


namespace Corpo.Loading;


public interface ILoadingService : IService {

  bool IsLoading { get; }

  // TODO
  // async Task RunTask(Action action);
}
