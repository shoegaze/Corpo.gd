import 'dotenv/config'
import { program } from '@commander-js/extra-typings'
import appRoot from 'app-root-path'

import * as path from 'node:path'

import { isDirectory } from '@core/file'
import { E, ET, LT } from '@core/log'
import { buildAllJsonSchema, buildWatchAllJsonSchema } from '@json/convert_to_schema'
import { buildAllCSharpClasses, buildWatchAllCSharpClasses } from '@csharp/convert_to_class'


program
  .name('Corpo Precompilation Tool')
  .description('CLI to execute Corpo precompilation actions')
  .version('0.0.1')

program.command('build-json')
  .description('Build JSON schemas from TypeScript types')
  .option(
    '-m, --mode [env_mode]',
    'Environment mode to generate',
    process.env.ENV_MODE ?? 'full'
  )
  .option(
    '-s, --src [types_src]',
    'TypeScript type definitions source directory',
    process.env.JSON_SCHEMA_SRC ?? ''
  )
  .option(
    '-o, --out [schema_out]',
    'Generated JSON schema out directory',
    process.env.JSON_SCHEMA_OUT ?? ''
  )
  .option('-w, --watch', 'Watch for changes', false)
  .action(async ({ src, out, watch }) => {
    if (typeof src === 'boolean') {
      E('Please specify a valid src path')
      return
    }

    if (typeof out === 'boolean') {
      E('Please specify a valid out path')
      return
    }

    const root = appRoot.path
    const srcPath = path.join(root, src)
    const outPath = path.join(root, out)

    const srcIsDir = isDirectory(srcPath)
    const outIsDir = isDirectory(outPath)

    if (!srcIsDir) {
      E(`src path is not a directory: ${src}`)
      return
    }

    if (!outIsDir) {
      E(`out path is not a directory: ${out}`)
      return
    }

    if (watch) {
      await buildWatchAllJsonSchema(srcPath, outPath)
        .then(() => {
          LT(`JSON schemas build SUCCESS`)
        })
        .catch(err => {
          ET(`JSON schemas build FAILED`)
          E(err)
        })

      LT('Exiting program ...')
      return
    }

    await buildAllJsonSchema(srcPath, outPath)
      .then(() => {
        LT('JSON schemas build SUCCESS')
      })
      .catch(err => {
        ET(`JSON schemas build FAILED`)
        E(err)
      })

    LT('Exiting program ...')
  })

program.command('build-csharp')
  .description('Build C# objects from JSON schemas')
  .option(
    '-m, --mode [env_mode]',
    'Environment mode to generate',
    process.env.ENV_MODE ?? 'full'
  )
  .option(
    '-s, --src [schema_src]',
    'JSON schema src directory',
    process.env.JSON_SCHEMA_OUT ?? ''
  )
  .option(
    '-o, --out [csharp_out]',
    'Generated C# class definitions out directory',
    process.env.JSON_CSHARP_OUT ?? ''
  )
  .option('-w, --watch', 'Watch for changes', false)
  .action(async ({ src, out, watch }) => {
    if (typeof src === 'boolean') {
      E('Please specify a valid src path')
      return
    }

    if (typeof out === 'boolean') {
      E('Please specify a valid out path')
      return
    }

    const root = appRoot.path
    const srcPath = path.join(root, src)
    const outPath = path.join(root, out)

    const srcIsDir = isDirectory(srcPath)
    const outIsDir = isDirectory(outPath)

    if (!srcIsDir) {
      E(`src path is not a directory: ${src}`)
      return
    }

    if (!outIsDir) {
      E(`out path is not a directory: ${out}`)
      return
    }

    if (watch) {
      await buildWatchAllCSharpClasses(srcPath, outPath)
        .then(() => {
          LT(`C# classes build SUCCESS`)
        })
        .catch(err => {
          ET(`C# classes build FAILED`)
          E(err)
        })

      LT('Exiting program ...')
      return
    }

    await buildAllCSharpClasses(srcPath, outPath)
      .then(() => {
        LT('C# classes build SUCCESS')
      })
      .catch(err => {
        ET(`C# classes build FAILED`)
        E(err)
      })

    LT('Exiting program ...')
  })

program.command('build-all')
  .option(
    '-m, --mode [env_mode]',
    'Environment mode to generate',
    process.env.ENV_MODE ?? 'full'
  )
  .option(
    '--types-src [types_src]',
    'TypeScript type definitions source directory',
    process.env.JSON_SCHEMA_SRC ?? ''
  )
  .option(
    '--schema-out [schema_out]',
    'Generated JSON schema out directory',
    process.env.JSON_SCHEMA_OUT ?? ''
  )
  .option(
    '--csharp-out [csharp_out]',
    'Generated C# class definitions out directory',
    process.env.JSON_CSHARP_OUT ?? ''
  )
  .option('-w, --watch', 'Watch for changes', false)
  .action(async ({ typesSrc, schemaOut, csharpOut, watch }) => {
    if (typeof typesSrc === 'boolean') {
      E('Please specify a valid types source path')
      return
    }

    if (typeof schemaOut === 'boolean') {
      E('Please specify a valid schema out path')
      return
    }

    if (typeof csharpOut === 'boolean') {
      E('Please specify a valid C# out path')
      return
    }

    const root = appRoot.path
    const typesSrcPath = path.join(root, typesSrc)
    const schemaOutPath = path.join(root, schemaOut)
    const csharpOutPath = path.join(root, csharpOut)

    const typesSrcIsDir = isDirectory(typesSrcPath)
    const schemaOutIsDir = isDirectory(schemaOutPath)
    const csharpOutIsDir = isDirectory(csharpOutPath)

    if (!typesSrcIsDir) {
      E(`Types source path is not a directory: ${typesSrcPath}`)
      return
    }

    if (!schemaOutIsDir) {
      E(`Schema out path is not a directory: ${schemaOutPath}`)
      return
    }

    if (!csharpOutIsDir) {
      E(`C# out path is not a directory: ${csharpOutPath}`)
      return
    }

    if (watch) {
      await buildAllJsonSchema(typesSrcPath, schemaOutPath)
        .then()
        .catch()

      await Promise.all([
        buildWatchAllJsonSchema(typesSrcPath, schemaOutPath),
        buildWatchAllCSharpClasses(schemaOutPath, csharpOutPath)
      ])
        .catch(err => {
          // TODO: Better error messages (return Promise<BuildResult>)
          ET(`All build FAILED`)
          E(err)
        })

      LT('Exiting program ...')
      return
    }

    await buildAllJsonSchema(typesSrcPath, schemaOutPath)
      .then(() => {
        LT('JSON schemas build SUCCESS')
      })
      .catch(err => {
        ET(`JSON schemas build FAILED`)
        E(err)
      })

    await buildAllCSharpClasses(schemaOutPath, csharpOutPath)
      .then(() => {
        LT('C# classes build SUCCESS')
      })
      .catch(err => {
        ET(`C# classes build FAILED`)
        E(err)
      })

    LT('Exiting program ...')
  })


program.parse()
