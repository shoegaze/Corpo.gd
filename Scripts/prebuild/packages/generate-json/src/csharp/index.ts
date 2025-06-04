import { glob } from 'glob'

import { getParentDir } from '@corpo/common/path'
import logger from '@corpo/common/log'

import { makeGenerationTask } from './convert'

import type { AbsolutePath } from '@corpo/common/path'
import type { GenerationContext } from './context'


export async function generateAllCSharpClasses(
  ctx: GenerationContext
): Promise<void> {
  const { srcRoot } = ctx
  const jsonSearchGlob = `${srcRoot}/**/*.json`

  logger.info(`Searching: ${jsonSearchGlob}`)


  const jsonCandidatePaths =
    await glob(jsonSearchGlob) as AbsolutePath[]

  if (jsonCandidatePaths.length === 0) {
    logger.warn(
      `Search '${jsonSearchGlob}' was empty;` +
      ' skipping generation...'
    )

    return
  }

  for (const path of jsonCandidatePaths) {
    logger.info(`Found: ${path}`)
  }


  const candidateUniqueDirs = new Set<AbsolutePath>(
    jsonCandidatePaths.map(getParentDir)
  )

  const generationTasks = Array.from(candidateUniqueDirs)
    .map(path => makeGenerationTask(path, ctx))


  await Promise.allSettled(generationTasks)
    .then((results) => {
      for (const result of results) {
        const { status } = result

        if (status === 'rejected') {
          logger.warn('Failed to generate and write C# class', result.reason)
          return
        }
      }
    })
}

