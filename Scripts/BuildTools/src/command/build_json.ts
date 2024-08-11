import { Command } from '@commander-js/extra-typings'

import { E, ET, LT } from '@core/log'
import { RelativePath, resolve, root } from '@core/path'
import { clean, make } from '@core/file'
import { buildAllJsonSchema } from '@json/convert_to_schema'


interface BuildJsonParams {
  src: string,
  out: string
}

export const buildJson = async ({ src: srcRelative, out: outRelative }: BuildJsonParams) => {
  const src = resolve(root, srcRelative as RelativePath)
  const out = resolve(root, outRelative as RelativePath)

  await Promise.all([
    make(src),
    make(out)
  ])
    .catch(err => {
      const msg = 'Failed to make src, out dirs'

      ET(msg)
      E(err, 1)

      throw new Error(msg)
    })

  await clean(out)
    .catch(err => {
      const msg = `Failed to clean out dir: ${out}`

      ET(msg)
      E(err, 1)

      throw new Error(msg)
    })


  await buildAllJsonSchema(src, out)
    .then(() => {
      LT('JSON schemas build SUCCESS')
    })
    .catch(err => {
      const msg = 'JSON schemas build FAILED'

      ET(msg)
      E(err, 1)

      throw new Error(msg)
    })
}


export const buildJsonCommand = new Command('build-json')
  // .option('-m, --mode [env_mode]', 'Environment mode (dev, prod, etc.)', process.env.ENV_MODE ?? 'all')
  .option(
    '-s, --src <types_path>',
    'Path (directory) to build from',
    process.env.JSON_SCHEMA_SRC
  )
  .option(
    '-o, --out <out_path>',
    'Path (directory) to emit to',
    process.env.JSON_SCHEMA_OUT
  )
  .action(buildJson)
