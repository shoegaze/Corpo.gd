import * as childProcess from 'node:child_process'
import { promisify } from 'node:util'

import fs from 'fs-extra'
import { glob } from 'glob'

import {
  detach,
  getNodeStrippedName,
  joinPaths
} from '@corpo/common/path'
import logger from '@corpo/common/log'

import {
  convertPathToCSharpNamespace,
  convertPathToCSharpPackages,
  toCSharpFileName
} from './util'

import type { AbsolutePath } from '@corpo/common/path'
import type { GenerationContext } from './context'

const exec = promisify(childProcess.exec)


interface QuickTypeCsharpGenerationContext {
  namespace: string
  framework: 'NewtonSoft' | 'SystemTextJson'
  density: 'normal' | 'dense'
  csharpVersion: 5 | 6
  features: 'attributes-only' | 'complete'
  baseClass: 'Object'
}

async function execQuickTypeCSharpGeneration(
  jsonFileSourcePaths: AbsolutePath[],
  csharpFileOutPath: AbsolutePath,
  ctx: QuickTypeCsharpGenerationContext
): Promise<void> {
  // BUG(Quicktype):
  //  We have to pass in the joined schema paths instead of the directory path
  const escapedJsonPaths = jsonFileSourcePaths
    .map(path => `"${path}"`)
    .join(' ')

  logger.info(`Generating QuickType: ${escapedJsonPaths}`)

  const command = [
    'npx quicktype',
    escapedJsonPaths,
    `--out "${csharpFileOutPath}"`,
    '--lang csharp',
    '--src-lang schema',
    `--namespace "${ctx.namespace}"`,
    `--framework "${ctx.framework}"`,
    `--density "${ctx.density}"`,
    `--csharp-version "${ctx.csharpVersion}"`,
    `--features "${ctx.features}"`,
    `--base-class "${ctx.baseClass}"`
  ].join(' ')

  await exec(command)
    .catch((err) => {
      logger.error('Failed to execute QuickType', err)
      throw err
    })

  logger.info(
    'Executed QuickType, wrote to: ' +
    csharpFileOutPath
  )
}


async function generateCSharpFromDir(
  targetDir: AbsolutePath,
  ctx: GenerationContext
): Promise<AbsolutePath | null> {
  const { srcRoot, outRoot } = ctx
  const jsonSearchGlob = `${targetDir}/**/*.json`

  logger.info(`Searching: '${jsonSearchGlob}'`)


  const jsonFileSourcePaths =
    await glob(jsonSearchGlob) as AbsolutePath[]

  if (jsonFileSourcePaths.length === 0) {
    logger.warn(
      `Search '${jsonSearchGlob}' was empty;` +
      ' skipping generation...'
    )

    return null
  }

  for (const path of jsonFileSourcePaths) {
    logger.info(`Found: ${path}`)
  }


  const csharpOutDirDetached = detach(targetDir, srcRoot)
  const csharpOutDirAsPackages = convertPathToCSharpPackages(
    csharpOutDirDetached,
    ctx.namespace
  )

  const csharpOutDir = joinPaths(
    outRoot,
    csharpOutDirAsPackages
  )

  const targetDirName = getNodeStrippedName(targetDir)
  const csharpOutFileName = toCSharpFileName(targetDirName)
  const csharpOutFilePathFull = joinPaths(
    csharpOutDir,
    csharpOutFileName
  )

  // Calculate full namespace to avoid method collisions
  const namespace = convertPathToCSharpNamespace(
    csharpOutDirDetached,
    ctx.namespace
  )

  const quickTypeCtx: QuickTypeCsharpGenerationContext = {
    namespace,
    // TODO: Switch to 'SystemTextJson'
    framework: 'NewtonSoft',
    // TODO: Switch to 'dense' when env='prod'
    density: 'normal',
    csharpVersion: 6,
    features: 'complete', // TODO: 'attributes-only'
    baseClass: 'Object'
  }

  await fs.ensureDir(csharpOutDir)
  await execQuickTypeCSharpGeneration(
    jsonFileSourcePaths,
    csharpOutFilePathFull,
    quickTypeCtx
  )

  return csharpOutFilePathFull
}


export async function makeGenerationTask(
  targetDir: AbsolutePath,
  ctx: GenerationContext
): Promise<void> {
  logger.info(`Generating: ${targetDir}`)

  await generateCSharpFromDir(targetDir, ctx)
    .then((outPath) => {
      if (!outPath) {
        return
      }

      logger.info(
        `Generated: ${targetDir} ...\n` +
        ` Wrote to '${outPath}'`
      )
    })
    .catch((err) => {
      logger.error(`Failed to generate: ${targetDir}`, err)
    })
}
