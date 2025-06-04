import * as nodePath from 'node:path'
import assert from 'node:assert'


export type AbsolutePath = string & { __brand: 'AbsolutePath' }
export type RelativePath = string & { __brand: 'RelativePath' }
export type Path = AbsolutePath | RelativePath

export type NodeName = RelativePath & { __base: 'NodeName' }


export function isAbsolutePath(path: string): path is AbsolutePath {
  return nodePath.isAbsolute(path)
}

export function toPosixPath<P extends Path>(path: P) {
  return path
    .split(nodePath.sep)
    .join(nodePath.posix.sep) as P
}

/**
 * Gets the absolute path resolved from the root,
 *  where traveral paths are relative
 *
 * Ex.
 * root='/foo/bar/src/aaa'
 * paths=['../../', 'dest/', './bbb']
 *  Returns path '/foo/bar/dest/bbb'
 *
 * @param from Root path to resolve from
 * @param paths The relative paths to traverse from root path
 * @returns AbsolutePath
 */
export function resolveTraversal(
  from: AbsolutePath,
  ...paths: RelativePath[]
): AbsolutePath {
  const resolvedPath = nodePath
    .resolve(from, ...paths) as AbsolutePath

  return toPosixPath(resolvedPath)
}

/**
 * Gets the relative path, or `walk`
 *  s.t. join(from, walk) == to
 *
 * Ex.
 * root='/foo/bar/src/aaa'
 * path='/foo/bar/dest/bbb'
 *  Returns path '../../dest/bbb'
 *
 * @param from Root path to walk from
 * @param to Path to walk to
 * @returns RelativePath
 */
export function resolveWalk(
  from: AbsolutePath,
  to: AbsolutePath
): RelativePath {
  const relativePath = nodePath
    .relative(from, to) as RelativePath

  return toPosixPath(relativePath)
}

/**
 * Detach root path from given path
 *
 * @param path
 * @param root
 */
export function detach(
  path: AbsolutePath,
  root: AbsolutePath
): RelativePath {
  assert(path.startsWith(root))

  const detachedPath = path.replace(root, '')

  if (isAbsolutePath(detachedPath)) {
    return detachedPath
      .replace(nodePath.posix.sep, '') as RelativePath
  }

  return detachedPath as RelativePath
}

/**
 *
 *
 * @param path
 * @param oldRoot Old root path in `path`
 * @param newRoot New root path to replace `oldRoot`
 */
export function rebase(
  path: AbsolutePath,
  oldRoot: AbsolutePath,
  newRoot: AbsolutePath
): AbsolutePath {
  const detachedPath = detach(path, oldRoot)
  const newPath = joinPaths(newRoot, detachedPath)

  return newPath
}

/**
 * Join paths
 *
 * @param root
 * @param paths
 * @returns Joined path
 */
export function joinPaths<P extends Path>(
  root: P,
  ...paths: RelativePath[]
) {
  const joinedPath = nodePath.join(root, ...paths) as P

  return toPosixPath(joinedPath)
}

/**
 * Create a glob path from base path
 *
 * @param path Absolute path to glob from
 * @param filter Globbable filter for searched nodes
 * @returns Glob absolute path
 */
export function toDeepGlobPath(path: AbsolutePath, filter = '*'): AbsolutePath {
  const glob = `**/${filter}` as RelativePath
  const globPath = joinPaths(path, glob)

  return toPosixPath(globPath)
}

/**
 * Get the first parent directory from the leaf node
 *
 * @param path Path
 * @returns Path
 */
export function getParentDir<P extends Path>(path: P): P {
  const parentName = nodePath.dirname(path) as P

  return toPosixPath(parentName)
}

/**
 * Get the full name of the leaf node
 *
 * @param path Path
 * @returns NodeName
 */
export function getNodeFullName(path: Path): NodeName {
  return nodePath.basename(path) as NodeName
}

/**
 * Get the stripped name, without the extension, of the leaf node
 *
 * @param path Path
 * @returns NodeName
 */
export function getNodeStrippedName(path: Path): NodeName {
  return nodePath.parse(path).name as NodeName
}

/**
 * Get the stripped name of the leaf node while preserving the path before it
 *
 * @param path Path
 * @returns Path
 */
export function stripExtension<P extends Path>(path: P): P {
  const parentPath = getParentDir(path)
  const strippedName = getNodeStrippedName(path)

  return joinPaths(parentPath, strippedName)
}
