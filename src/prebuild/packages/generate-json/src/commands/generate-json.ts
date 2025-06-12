import { Command } from '@commander-js/extra-typings'
import fs from 'fs-extra'

import { isAbsolutePath, resolveTraversal } from '@corpo/common/path'
import logger from '@corpo/common/log'

import { generateAllJsonSchema } from '../json'

import type { AbsolutePath, RelativePath } from '@corpo/common/path'
import type { GenerationContext } from '../json/context'


interface GenerateJsonCommandParams {
  dir: string
  src: string
  out: string
}

interface GenerateJsonImplParams {
  srcRoot: AbsolutePath
  outRoot: AbsolutePath
}


async function prepare({
  srcRoot,
  outRoot
}: GenerationContext) {
  await Promise.all([
    fs.ensureDir(srcRoot),
    fs.emptyDir(outRoot)
  ])
}

export async function generateJsonImpl({
  srcRoot,
  outRoot
}: GenerateJsonImplParams): Promise<void> {
  const ctx: GenerationContext = { srcRoot, outRoot }

  await prepare(ctx)
  await generateAllJsonSchema(ctx)
}


export async function generateJson({
  dir: root,
  src,
  out
}: GenerateJsonCommandParams): Promise<void> {
  logger.info('Generating JSON')

  if (!isAbsolutePath(root)) {
    throw new Error('Working directory is not an absolute path')
  }

  const srcRoot = resolveTraversal(root, src as RelativePath)
  const outRoot = resolveTraversal(root, out as RelativePath)

  try {
    await generateJsonImpl({
      srcRoot,
      outRoot
    })

    logger.info('Generation SUCCESS')
  } catch (err) {
    logger.error('Generation FAILED', err)
  } finally {
    logger.info('JSON schema generation finished')
  }
}

export const generateJsonCommand = new Command('generate-json')
  .option(
    '--dir <working_directory>',
    'The working directory this command will use',
    __dirname
  )
  .option(
    '--src <types_directory>',
    'Source directory of typedef files',
    process.env.JSON_SCHEMA_SRC
  )
  .option(
    '--out <out_directory>',
    'Out directory for emitted JSON schema',
    process.env.JSON_SCHEMA_OUT
  )
  // .option(
  //   '--temp <temp_directory>',
  //   'Out directory for temporarily files',
  //   process.env.TEMP_ROOT
  // )
  .action(generateJson)
