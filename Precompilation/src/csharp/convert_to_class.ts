import { promisify } from 'node:util'
import * as path from 'node:path'
import * as childProcess from 'node:child_process'
import { writeFile } from 'node:fs/promises'

import { watch } from 'chokidar'
import { glob } from 'glob'
const camelCase = (async () => await import('camelcase'))()

import { L, E, LT } from '@core/log'
import { Path, prepare } from "@core/file"


const exec = promisify(childProcess.exec)


async function buildCSharpClass(fileName: string, dirPath: Path, outPath: Path, depth = 0): Promise<void> {
  const { default: camelCase } = await import('camelcase')

  const fullSourceFileName = `${fileName}.json`
  const fullSourcePath: Path = path.join(dirPath, fullSourceFileName)

  const topLevel = camelCase(`${fileName}Json`, {
    pascalCase: true
  })

  L(`Building C# class for ${fullSourcePath}`, depth)

  const cmd = [
    'npx',
    'quicktype',
    '--src-lang schema',
    '--lang cs',
    `--src ${fullSourcePath}`,
    `--top-level ${topLevel}`
  ].join(' ')

  L(`$ ${cmd}`, depth + 1)

  return exec(cmd)
    .then(result => {
      L(`Build complete: ${fullSourcePath}`, depth + 1)

      const fullOutFileName = `${topLevel}.cs`
      const fullOutPath = path.join(
        outPath,
        fullOutFileName
      )

      return writeFile(fullOutPath, result.stdout)
    })
    .catch(err => {
      E(`Build failed: ${dirPath}`, depth + 1)
      E(`${err}`, depth + 2)

      return Promise.reject()
    })
}

export async function buildAllCSharpClasses(srcPath: Path, outPath: Path, depth = 0): Promise<void> {
  await prepare(srcPath, outPath)

  const buildGlob = path.join(
    srcPath,
    '**',
    '*.json'
  )

  LT(`Building all: ${buildGlob}`)

  const buildPaths: Path[] = await glob(buildGlob)

  const buildPromises: Promise<void>[] = buildPaths
    .map(schemaPath => {
      const {
        name: fileName,
        dir: dirPath
      } = path.parse(schemaPath)

      return buildCSharpClass(fileName, dirPath, outPath, depth + 1)
    })

  await Promise.allSettled(buildPromises)
}

export async function buildWatchAllCSharpClasses(srcPath: Path, outPath: Path, depth = 0): Promise<void> {
  await prepare(srcPath, outPath)

  const watchGlob = path.join(
    srcPath,
    '**',
    '*.json'
  )

  LT(`Watching files in ${watchGlob}:`)

  watch(watchGlob, {
    persistent: true
  }).on('all', (event, filePath) => {
    L(`Change: [${event}] ${filePath}`, depth + 1)

    const {
      name: fileName,
      dir: dirPath
    } = path.parse(filePath)

    buildCSharpClass(fileName, dirPath, outPath, depth + 1)
  })
}
