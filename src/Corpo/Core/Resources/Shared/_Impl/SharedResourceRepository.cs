using System;

using Corpo.Core.Resources.Shared.Models;


namespace Corpo.Core.Resources.Shared._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
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
