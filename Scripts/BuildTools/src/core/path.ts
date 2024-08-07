import * as path_ from 'node:path'

import appRootPath from 'app-root-path'


export type AbsolutePath = string & { __brand: 'AbsolutePath' }
export type RelativePath = string & { __brand: 'RelativePath' }
export type Path = AbsolutePath | RelativePath

export type Extension = '.ts' | '.json' | '.cs'


export const toPosix = <P extends Path>(path: P) =>
  path
    .split(path_.sep)
    .join(path_.posix.sep) as P

export const resolve = (root: AbsolutePath, ...paths: RelativePath[]) =>
  toPosix(
    path_.resolve(root, ...paths) as AbsolutePath
  )

export const relative = (root: AbsolutePath, path: AbsolutePath) =>
  toPosix(
    path_.relative(root, path) as RelativePath
  )

export const join = <P extends Path>(root: P, ...paths: RelativePath[]) =>
  toPosix(
    path_.join(root, ...paths) as P
  )

export const glob = (path: AbsolutePath, extension?: Extension) =>
  toPosix(
    join(path, `**/*${extension ?? ''}` as RelativePath) as AbsolutePath
  )


export const parent = <P extends Path>(path: P) =>
  toPosix(
    path_.dirname(path) as P
  )

export const base = (path: Path) =>
  path_.basename(path)


export const toDirectory = (path: AbsolutePath) => {
  const parentPath = parent(path)
  const name = path_.parse(path).name as RelativePath

  return join(parentPath, name)
}


export const root = resolve(appRootPath.path as AbsolutePath)
