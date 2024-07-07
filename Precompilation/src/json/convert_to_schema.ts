import { promisify } from 'node:util'
import * as path from 'node:path'
import * as childProcess from 'node:child_process'
import { writeFile } from 'node:fs/promises'

import { watch } from 'chokidar'
import { glob } from 'glob'

import { L, E, LT } from '@core/log'
import { Path, prepare } from '@core/file'


const exec = promisify(childProcess.exec)


async function buildJsonSchema(fileName: string, dirPath: Path, outPath: Path, depth = 0): Promise<void> {
  const fullSourceFileName = `${fileName}.ts`
  const fullSourcePath: Path = path.join(dirPath, fullSourceFileName)

  L(`Building JSON schema for ${fullSourcePath}`, depth)

  const cmd = [
    'npx',
    'ts-json-schema-generator',
    `--path ${fullSourcePath}`
  ].join(' ')

  L(`$ ${cmd}`, depth + 1)

  return exec(cmd)
    .then(result => {
      L(`Build complete: ${fullSourcePath}`, depth + 1)

      const fullOutFileName = `${fileName}.json`
      const fullOutPath = path.join(
        outPath,
        fullOutFileName
      )

      return writeFile(fullOutPath, result.stdout)
    })
    .catch(err => {
      E(`Build failed: ${dirPath}`, depth + 1)
      E(`${err}`, depth + 2)
      L('Ignoring ...', depth + 1)
    })
}

export async function buildAllJsonSchema(srcPath: Path, outPath: Path): Promise<void> {
  await prepare(srcPath, outPath)

  const buildGlob = path.join(
    srcPath,
    '**',
    '*.ts'
  )

  LT(`Building all: ${buildGlob}`)

  const buildPaths: Path[] = await glob(buildGlob)
  const buildPromises: Promise<void>[] = buildPaths
    .map(schemaPath => {
      const {
        name: fileName,
        dir: dirPath
      } = path.parse(schemaPath)

      return buildJsonSchema(fileName, dirPath, outPath, 1)
    })

  await Promise.allSettled(buildPromises)
}

export async function buildWatchAllJsonSchema(srcPath: Path, outPath: Path, depth = 0): Promise<void> {
  await prepare(srcPath, outPath)

  const watchGlob = path.join(
    srcPath,
    '**',
    '*.ts'
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

    buildJsonSchema(fileName, dirPath, outPath, depth + 1)
  })
}
