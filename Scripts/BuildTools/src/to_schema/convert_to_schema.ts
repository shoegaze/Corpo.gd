import { pathToFileURL } from 'node:url'

import { ZodSchema } from 'zod'
import zodToJsonSchema from 'zod-to-json-schema'

import { jsonExtension, make, search, tsExtension, write } from '@core/file'
import { E, L, LT, W } from '@core/log'
import { AbsolutePath, RelativePath, join, relative, toDirectory } from '@core/path'


export async function buildAllJsonSchema(
  src: AbsolutePath,
  out: AbsolutePath
): Promise<void> {
  LT(`Building: '${src}/**/*${tsExtension}'`)

  const targets: AbsolutePath[] = await search(src, tsExtension)

  if (targets.length === 0) {
    W(`Source directory '${src}' was empty; skipping build...`, 1)
    return
  }

  targets.forEach(path => {
    L(`Building: '${path}'`, 1)
  })

  const tasks = targets
    .map(path => [path, pathToFileURL(path).href] as [AbsolutePath, string])
    .map(([path, url]) =>
      import(url)
        .then(imported => validateImport(imported, path))
        .then(imported => toSchemaEntries(imported))
        .then(schemas => validateSchemaEntries(schemas))
        .then(schemas => toJsons(schemas))
        .then(jsons => toJsonStrings(jsons))
        // .then(/* jsonStrings => jsonStrings.forEach(([_, s]) => s !== undefined) */)
        .then(jsonStrings => writeJsonStrings(jsonStrings, path, src, out))
    )

  return Promise.allSettled(tasks)
    .then(results => {
      results.forEach(result => {
        const { status } = result

        if (status === 'fulfilled') {
          result.value.forEach(async path => {
            const p = await path
            L(`Wrote to: '${p}'`, 1)
          })

          return
        }

        const { reason } = result
        E(`Failed to write schema; reason: ${reason}`, 1)
      })
    })
}


type Import = Record<string, unknown>

const validateImport = (imported: unknown, path: AbsolutePath): Import => {
  if (!imported || typeof imported !== 'object') {
    const msg = `Import error: File '${path}' is not well-formed`

    E(msg)
    throw new Error(msg)
  }

  return imported as Import
}


type ImportEntry = [string, unknown]
type ImportEntries = ImportEntry[]

const toSchemaEntries = (imported: Import): ImportEntries =>
  Object.entries(imported)


type Schema = ZodSchema<unknown, any, unknown>
type SchemaEntries = [string, Schema][]

const validateSchemaEntries = (entries: ImportEntries): SchemaEntries => {
  const validateSchema = (schema: unknown, name: string) => {
    if (!(schema instanceof ZodSchema)) {
      W(`Imported zod schema '${name}' is invalid`)
      return null
    }

    return schema as Schema
  }

  return entries
    .map(([name, schema]) =>
      [name, validateSchema(schema, name)] as const)
    .filter(([_, schema]) => schema !== null) as SchemaEntries
}


type JsonEntry = [string, ReturnType<typeof zodToJsonSchema>]
type JsonEntries = JsonEntry[]

const toJsons = (entries: SchemaEntries): JsonEntries =>
  entries.map(([name, schema]) =>
    [
      name,
      zodToJsonSchema(schema, {
        errorMessages: true
      })
    ] as JsonEntry
  )


type JsonStringEntry = [string, string]
type JsonStringEntries = JsonStringEntry[]

const toJsonStrings = (jsons: JsonEntries): JsonStringEntries =>
  jsons.map(([name, json]) =>
    [
      name,
      JSON.stringify(json, undefined, 2)
    ] as JsonStringEntry
  )

const writeJsonStrings = (
  jsonStringEntries: JsonStringEntries,
  path: AbsolutePath,
  src: AbsolutePath,
  out: AbsolutePath
): Promise<AbsolutePath>[] =>
  jsonStringEntries.map(async ([name, jsonStr]): Promise<AbsolutePath> => {
    const srcTrail = toDirectory(path)
    const trail = relative(src, srcTrail)
    const outDir = join(out, trail)

    await make(outDir)

    const outFile = `${name}${jsonExtension}` as RelativePath
    const outPath = join(outDir, outFile)

    return write(outPath, jsonStr)
      .then(() => outPath)
  })
