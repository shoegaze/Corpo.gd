import { Command } from '@commander-js/extra-typings'
import fs from 'fs-extra'

import { isAbsolutePath, resolveTraversal } from '@corpo/common/path'
import logger from '@corpo/common/log'

import { generateAllCSharpClasses } from '../csharp'

import type { AbsolutePath, RelativePath } from '@corpo/common/path'
import type { GenerationContext } from '../csharp/context'


interface GenerateCSharpParams {
  dir: string
  src: string
  out: string
  namespace: string
}

interface GenerateCSharpImplParams {
  srcRoot: AbsolutePath
  outRoot: AbsolutePath
  namespace: string
}


async function prepare({
  srcRoot,
  outRoot
}: GenerationContext): Promise<void> {
  await Promise.all([
    fs.ensureDir(srcRoot),
    fs.emptyDir(outRoot)
  ])
}

export async function generateCSharpImpl({
  srcRoot,
  outRoot,
  namespace
}: GenerateCSharpImplParams): Promise<void> {
  const ctx: GenerationContext = {
    srcRoot,
    outRoot,
    namespace
  }

  await prepare(ctx)
  await generateAllCSharpClasses(ctx)
}

export async function generateCSharp({
  dir: root,
  src,
  out,
  namespace
}: GenerateCSharpParams): Promise<void> {
  logger.info('Generating C#')

  if (!isAbsolutePath(root)) {
    throw new Error('Working directory is not an absolute path')
  }

  const srcRoot = resolveTraversal(root, src as RelativePath)
  const outRoot = resolveTraversal(root, out as RelativePath)

  try {
    await generateCSharpImpl({
      srcRoot,
      outRoot,
      namespace
    })

    logger.info('Generation SUCCESS')
  } catch (err) {
    logger.error('Generation FAILED', err)
  } finally {
    logger.info('C# class generation finished')
  }
}

export const generateCSharpCommand = new Command('generate-csharp')
  .option(
    '--dir <working_directory>',
    'Working directory for commands',
    __dirname
  )
  .option(
    '--src <src_path>',
    'Generated JSON schema source directory',
    process.env.JSON_SCHEMA_OUT
  )
  .option(
    '--out <out_path>',
    'Generated C# class definitions out directory',
    process.env.JSON_CSHARP_OUT
  )
  .option(
    '--namespace <namespace_root>',
    'Generated C# class namespace root',
    process.env.OUT_CSHARP_NAMESPACE_ROOT
  )
  .action(generateCSharp)
