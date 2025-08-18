using System.IO;


namespace Corpo.Loading.Models;


public record LoaderContext(
  string Root
) {
  public virtual string GetPathFromRoot() {
    return Path.Combine(Root);
  }
}

public record LoadAuthorContext(
  string Root,
  string Author
) : LoaderContext(Root) {
  public override string GetPathFromRoot() {
    return Path.Combine(base.GetPathFromRoot(), Author);
  }
}

public record LoadPackageContext(
  string Root,
  string Author,
  string Package
) : LoadAuthorContext(Root, Author) {
  public override string GetPathFromRoot() {
    return Path.Combine(base.GetPathFromRoot(), Package);
  }
}

public record LoadSharedResourcesContext(
  string Root,
  string Author,
  string Package,
  string SharedRoot
) : LoadPackageContext(Root, Author, Package) {
  public static LoadSharedResourcesContext From(
    LoadPackageContext packageContext,
    string sharedRoot
  ) {
    return new LoadSharedResourcesContext(
        packageContext.Root,
        packageContext.Author,
        packageContext.Package,
        sharedRoot
      );
  }

  public override string GetPathFromRoot() {
    return Path.Combine(base.GetPathFromRoot(), SharedRoot);
  }
}

public record LoadOverworldResourcesContext(
  string Root,
  string Author,
  string Package,
  string OverworldRoot
) : LoadPackageContext(Root, Author, Package) {
  public static LoadOverworldResourcesContext From(
    LoadPackageContext packageContext,
    string overworldRoot
  ) {
    return new LoadOverworldResourcesContext(
        packageContext.Root,
        packageContext.Author,
        packageContext.Package,
        overworldRoot
      );
  }

  public override string GetPathFromRoot() {
    return Path.Combine(base.GetPathFromRoot(), OverworldRoot);
  }
}

public record LoadBattleResourcesContext(
  string Root,
  string Author,
  string Package,
  string BattleRoot
) : LoadPackageContext(Root, Author, Package) {
  public static LoadBattleResourcesContext From(
    LoadPackageContext packageContext,
    string battleRoot
  ) {
    return new LoadBattleResourcesContext(
        packageContext.Root,
        packageContext.Author,
        packageContext.Package,
        battleRoot
      );
  }

  public override string GetPathFromRoot() {
    return Path.Combine(base.GetPathFromRoot(), BattleRoot);
  }
}
