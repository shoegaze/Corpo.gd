import { promisify } from 'node:util'
import { posix } from 'node:path'
import * as childProcess from 'node:child_process'

import { make, walks } from '@core/file'
import { L, E, LT, W } from '@core/log'
import { AbsolutePath, base, join, relative, parent, RelativePath } from '@core/path'

const exec = promisify(childProcess.exec)


const csExtension = '.cs'
const csNamespaceSeparator = '.'


export async function buildAllCSharpClasses(
  src: AbsolutePath,
  out: AbsolutePath
): Promise<void> {
  LT(`Building all in: '${src}/**/*${csExtension}'`)

  const targets = await walks(src)

  if (targets.length === 0) {
    W(`Source directory '${src}' was empty; skipping build...`, 1)
    return
  }

  targets.forEach(path => {
    L(`Building: '${path}'`, 1)
  })

  const tasks = targets
    .map(path => generateCSharpFromDir(path, src, out))

  return Promise.allSettled(tasks)
    .then(results => {
      results.forEach(result => {
        const { status } = result

        if (status === 'fulfilled') {
          const { outPath } = result.value
          L(`Wrote ${csExtension} file to: '${outPath}'`, 1)

          return
        }

        const { reason } = result
        E(`Failed to write ${csExtension} file; reason: ${reason}`, 1)
      })
    })
}


type CSharpName = string & { __brand: 'CSharpName' }
type CSharpFileName = string & { __brand: 'CSharpFileName' }
type CSharpNamespace = string & { __brand: 'CSharpNamespace' }

const toCSharpName = async (name: string) => {
  const camelCase = (await import('camelcase')).default

  return camelCase(name, {
    pascalCase: true
  }) as CSharpName
}

const toCSharpFileName = async (name: string) =>
  `${await toCSharpName(name)}${csExtension}` as CSharpFileName

const toCSharpNamespace = async (root: AbsolutePath, path: AbsolutePath) =>
  await Promise.all(
    relative(root, path)
      .split(posix.sep)
      .map(async dir => await toCSharpName(dir))
  )
    .then(dirs =>
      dirs.join(csNamespaceSeparator) as CSharpNamespace
    )

const generateCSharpFromDir = async (
  path: AbsolutePath,
  src: AbsolutePath,
  out: AbsolutePath
) => {
  const name = base(path)
  const csFileName = await toCSharpFileName(name)

  const srcDir = path
  const outPath = join(
    out,
    relative(src, path),
    `${csFileName}` as RelativePath
  )
  const csNamespace = await toCSharpNamespace(src, path)

  const command = [
    'npx quicktype',
    `"${srcDir}"`,
    `--out "${outPath}"`,
    `--namespace "${csNamespace}"`,
    '--framework NewtonSoft',
    `--src-lang schema`,
    `--lang csharp`
  ].join(' ')


  const outDir = parent(outPath)
  await make(outDir)

  return exec(command)
    .then(() => ({ srcDir, outPath }))
}
