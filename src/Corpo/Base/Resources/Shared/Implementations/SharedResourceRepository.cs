using System;

using Corpo.Base.Resources.Shared.Models;


namespace Corpo.Base.Resources.Shared.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public class SharedResourceRepository : ISharedResourceRepository {
  public void Dispose() {
    throw new NotImplementedException();
  }

  public SharedResourceHandle GetHandle() {
    throw new NotImplementedException();
  }

  public void LoadResources() {
    throw new NotImplementedException();
  }

  public void LoadResource(SharedResourceHandle handle) {
    throw new NotImplementedException();
  }

  public ISharedResource Get(SharedResourceHandle handle) {
    throw new NotImplementedException();
  }
}
