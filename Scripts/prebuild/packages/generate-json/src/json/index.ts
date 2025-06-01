import { glob } from 'glob'

import { detach } from '@corpo/common/path'
import logger from '@corpo/common/log'

import { makeConversionTask } from './convert'

import type { AbsolutePath } from '@corpo/common/path'
import type { GenerationContext } from './context'


export async function generateAllJsonSchema(
  ctx: GenerationContext
): Promise<void> {
  const { srcRoot } = ctx
  const tsSearchGlob = `${srcRoot}/**/*.ts`

  logger.info(`Searching: ${tsSearchGlob}`)


  const tsFileSourcePaths = await glob(tsSearchGlob) as AbsolutePath[]

  if (tsFileSourcePaths.length === 0) {
    logger.warn(
      `Search '${tsSearchGlob}' was empty;` +
      ' skipping generation...'
    )

    return
  }

  for (const path of tsFileSourcePaths) {
    logger.info(`Found: ${path}`)
  }


  const conversionTasks = tsFileSourcePaths
    .map(path => detach(path, srcRoot))
    .map(path => makeConversionTask(path, ctx))


  return Promise.allSettled(conversionTasks)
    .then((results) => {
      for (const result of results) {
        const { status } = result

        if (status === 'rejected') {
          logger.warn('Failed to generate and write schema', result.reason)
          return
        }
      }
    })
}

