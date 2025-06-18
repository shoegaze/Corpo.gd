using TeamSports.Services;


namespace Corpo.Loading.Core;


public interface ILoadingService : IService {

  bool IsLoading { get; }


  // TODO
  // async Task RunTask(Action action);
}
