import { Command } from '@commander-js/extra-typings'

import { E, ET } from '@core/log'
import { RelativePath, resolve, root } from '@core/path'
import { clean, make } from '@core/file'
import { buildAllCSharpClasses } from '@csharp/convert_to_csharp'


interface BuildCSharpParams {
  src: string,
  out: string
}

export const buildCSharp = async ({ src: srcRelative, out: outRelative }: BuildCSharpParams) => {
  const src = resolve(root, srcRelative as RelativePath)
  const out = resolve(root, outRelative as RelativePath)

  await Promise.all([
    make(src),
    make(out)
  ])

  await clean(out)
    .catch(err => {
      const msg = `Failed to clean out dir: ${out}`

      ET(msg)
      E(err, 1)

      throw new Error(msg)
    })


  await buildAllCSharpClasses(src, out)
}

export const buildCSharpCommand = new Command('build-csharp')
  // .option('-m, --mode [env_mode]', 'Environment mode ()', process.env.ENV_MODE ?? 'all')
  .option(
    '-s, --src <src_path>',
    'Generated JSON schema out directory',
    process.env.JSON_SCHEMA_OUT
  )
  .option(
    '-o, --out <out_path>',
    'Generated C# class definitions out directory',
    process.env.JSON_CSHARP_OUT
  )
  .action(buildCSharp)
