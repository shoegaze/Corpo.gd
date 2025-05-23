import { Command } from '@commander-js/extra-typings'

import logger from '@corpo/common/log'

import { generateCSharp } from './generate-csharp'
import { generateJson } from './generate-json'


interface GenerateAllParams {
  dir: string
  types: string
  schema: string
  csharp: string
  temp: string
}


const generateAll = async ({
  dir, types, schema, csharp, temp
}: GenerateAllParams) => {
  logger.info('Generating all')

  await generateJson({
    dir,
    src: types,
    out: schema,
    temp
  })

  await generateCSharp({
    dir,
    src: schema,
    out: csharp
  })
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
    '--temp <temp_directory>',
    'Out directory for temporarily files',
    process.env.TEMP_ROOT
  )
  .action(generateAll)
