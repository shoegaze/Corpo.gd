import { Command } from '@commander-js/extra-typings'

import { isAbsolutePath, resolveTraversal } from '@corpo/common/path'
import logger from '@corpo/common/log'

import { generateCSharpImpl } from './generate-csharp'
import { generateJsonImpl } from './generate-json'

import type { AbsolutePath, RelativePath } from '@corpo/common/path'


interface GenerateAllParams {
  dir: string
  types: string
  schema: string
  csharp: string
  namespace: string
}

interface GenerateAllImplParams {
  typesSrcRoot: AbsolutePath
  schemaSrcRoot: AbsolutePath
  csharpOutRoot: AbsolutePath
  csharpNamespace: string
}


async function generateAllImpl({
  typesSrcRoot,
  schemaSrcRoot,
  csharpOutRoot,
  csharpNamespace
}: GenerateAllImplParams): Promise<void> {
  await generateJsonImpl({
    srcRoot: typesSrcRoot,
    outRoot: schemaSrcRoot
  })

  await generateCSharpImpl({
    srcRoot: schemaSrcRoot,
    outRoot: csharpOutRoot,
    namespace: csharpNamespace
  })
}

async function generateAll({
  dir: root,
  types,
  schema,
  csharp,
  namespace
}: GenerateAllParams): Promise<void> {
  logger.info('Generating all')

  if (!isAbsolutePath(root)) {
    throw new Error('Working directory is not an absolute path')
  }

  const typesSrcRoot = resolveTraversal(root, types as RelativePath)
  const schemaSrcRoot = resolveTraversal(root, schema as RelativePath)
  const csharpOutRoot = resolveTraversal(root, csharp as RelativePath)
  const csharpNamespace = namespace

  try {
    await generateAllImpl({
      typesSrcRoot,
      schemaSrcRoot,
      csharpOutRoot,
      csharpNamespace
    })

    logger.info('Generation SUCCESS')
  } catch (err) {
    logger.error('Generation FAILED', err)
  } finally {
    logger.info('All generations finished')
  }
}

export const generateAllCommand = new Command('generate-all')
  .option(
    '--dir <working_directory>',
    'The working directory this command will use',
    __dirname
  )
  .option(
    '--types <types_directory>',
    'Source directory of typedef files',
    process.env.JSON_SCHEMA_SRC
  )
  .option(
    '--schema <schema_directory>',
    'Out directory for emitted JSON schema',
    process.env.JSON_SCHEMA_OUT
  )
  .option(
    '--csharp <csharp_path>',
    'Generated C# class definitions out directory',
    process.env.JSON_CSHARP_OUT
  )
  .option(
    '--namespace <namespace_root>',
    'Generated C# class namespace root',
    process.env.OUT_CSHARP_NAMESPACE_ROOT
  )
  .action(generateAll)
