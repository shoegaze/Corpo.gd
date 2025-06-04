import nodePath from 'node:path'

import camelcase from 'camelcase'

import type { RelativePath } from '@corpo/common/path'


export type CSharpClassName = string & { __brand: 'CSharpClassName' }
export type CSharpNamespace = string & { __brand: 'CSharpNamespace' }


const csharpNamespaceSeparator = '.'


export function toCSharpClassName(name: string): CSharpClassName {
  const className = camelcase(name, {
    pascalCase: true
  }) as CSharpClassName

  return className
}

export function toCSharpFileName(name: string): RelativePath {
  const fileName = `${toCSharpClassName(name)}.cs` as RelativePath

  return fileName
}


function toCSharpClassNames(names: string[]): CSharpClassName[] {
  const classNames = names
    // When name item is a namespace shape (e.g. 'Foo.Bar'),
    //  split by ns separator `.` and convert each fragment to PascalCase
    .flatMap(name => name
      .split(csharpNamespaceSeparator)
      .map(toCSharpClassName)
      .join(csharpNamespaceSeparator) as CSharpClassName
    )

  return classNames
}

function splitPathToCSharpClassNames(
  path: RelativePath,
  namespaceRoot: string | CSharpNamespace
): CSharpClassName[] {
  const splitPath = path.split(nodePath.posix.sep)
  const names = [namespaceRoot, ...splitPath]
  const classNames = toCSharpClassNames(names)

  return classNames
}

export function convertPathToCSharpNamespace(
  path: RelativePath,
  namespaceRoot: string | CSharpNamespace
): CSharpNamespace {
  const classNames = splitPathToCSharpClassNames(path, namespaceRoot)
  const namespace = classNames
    .join(csharpNamespaceSeparator) as CSharpNamespace

  return namespace
}

export function convertPathToCSharpPackages(
  path: RelativePath,
  namespaceRoot: string | CSharpNamespace
): RelativePath {
  const classNames = splitPathToCSharpClassNames(path, namespaceRoot)
  const classNamesPath = classNames
    .join(nodePath.posix.sep) as RelativePath

  return classNamesPath
}
