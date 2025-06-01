import nodePath from 'node:path'

import camelcase from 'camelcase'

import type { RelativePath } from '@corpo/common/path'


export function toCSharpClassName(name: string): string {
  return camelcase(name, {
    pascalCase: true
  })
}

export function toCSharpFileName(name: string): string {
  return `${toCSharpClassName(name)}.cs`
}

export function convertPathToCSharpNamespace(
  path: RelativePath,
  namespaceRoot: string
): string {
  const splitPath = path.split(nodePath.posix.sep)
  const qualifiedNames = splitPath.map(toCSharpClassName)
  const namespaceFragments = [namespaceRoot, ...qualifiedNames]
  const fullyQualifiedNamespace = namespaceFragments.join('.')

  return fullyQualifiedNamespace
}
