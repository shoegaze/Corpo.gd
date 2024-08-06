import * as path_ from 'node:path'

import appRootPath from 'app-root-path'


export type AbsolutePath = string & { __brand: 'Absolute' }
export type RelativePath = string & { __brand: 'Relative' }
export type Path = AbsolutePath | RelativePath

export type Extension = '.ts' | '.json' | '.cs'


const toPosix = <P extends Path>(path: P) =>
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

  
const parent = <P extends Path>(path: P) =>
  toPosix(
    path_.normalize(
      join(path, '../' as RelativePath)
    ) as P
  )

export const strip = (path: AbsolutePath) => {
  const parentPath = parent(path)
  const name = path_.parse(path).name

  return join(parentPath, name as RelativePath)
}


export const root = resolve(appRootPath.path as AbsolutePath)
