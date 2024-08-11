import { Command } from '@commander-js/extra-typings'
import * as path from 'node:path'
import appRoot from 'app-root-path'

import { E, ET, LT, W } from '@core/log'
import { buildAllJsonSchema } from '@json/convert_to_schema'
import { buildAllCSharpClasses } from '@csharp/convert_to_csharp'
import { buildJson, buildJsonCommand } from './build_json'
import { buildCSharp, buildCSharpCommand } from './build_csharp'


interface BuildAllParams {
  types: string,
  schema: string,
  csharp: string
}

const buildAll = async ({ types, schema, csharp }: BuildAllParams) => {
  LT('Building all')

  await buildJson({ src: types, out: schema })
  await buildCSharp({ src: schema, out: csharp })
}

export const buildAllCommand = new Command('build-all')
  // .option('-m, --mode [env_mode]', 'Environment mode (dev, prod, etc.)', process.env.ENV_MODE ?? 'all')
  .option(
    '--types <types_path>',
    'Typescript type definitions directory',
    process.env.JSON_SCHEMA_SRC
  )
  .option(
    '--schema <schema_path>',
    'Generated JSON schema directory',
    process.env.JSON_SCHEMA_OUT
  )
  .option(
    '--csharp <csharp_path>',
    'Generated C# class definitions directory',
    process.env.JSON_CSHARP_OUT
  )
  .action(buildAll)
