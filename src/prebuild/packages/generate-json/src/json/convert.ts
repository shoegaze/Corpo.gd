import { pathToFileURL } from 'node:url'


import { ensureDir, writeFile } from 'fs-extra'

import { ZodSchema, ZodTypeDef } from 'zod'
import zodToJsonSchema from 'zod-to-json-schema'

import { getParentDir, joinPaths } from '@corpo/common/path'
import logger from '@corpo/common/log'

import type { AbsolutePath, RelativePath } from '@corpo/common/path'
import type { GenerationContext } from './context'


type Import = Record<string, unknown>

function validateImport(
  imported: unknown,
  path: AbsolutePath
): Import {
  if (!imported || typeof imported !== 'object') {
    const msg = `Import error: File '${path}' is not well-formed`

    logger.error(msg)
    throw new Error(msg)
  }

  return imported as Import
}


type ImportEntry = [string, unknown]
type ImportEntries = ImportEntry[]

function toSchemaEntries(imported: Import): ImportEntries {
  return Object.entries(imported)
}


type Schema = ZodSchema<unknown, ZodTypeDef, unknown>
type SchemaEntry = readonly [string, Schema]
type SchemaEntries = SchemaEntry[]

function validateSchemaEntries(
  entries: ImportEntries
): SchemaEntries {
  const validateSchema = (schema: unknown, name = 'unknown') => {
    if (!(schema instanceof ZodSchema)) {
      logger.warn(
        `Imported zod schema '${name}' is invalid;\n` +
        ' it is not a Zod schema'
      )

      return null
    }

    return schema as Schema
  }

  const validatedEntries = entries
    .map(([name, schema]) => [
      name,
      validateSchema(schema, name)
    ] as const)
    .filter(([_, schema]) => schema !== null)

  return validatedEntries as SchemaEntries
}


type JsonEntry = readonly [string, ReturnType<typeof zodToJsonSchema>]
type JsonEntries = JsonEntry[]

function toJsonEntries(entries: SchemaEntries): JsonEntries {
  return entries.map(([name, schema]): JsonEntry => [
    name,
    zodToJsonSchema(schema, { errorMessages: true })
  ])
}


type JsonStringEntry = [string, string]
type JsonStringEntries = JsonStringEntry[]

function toJsonData(jsons: JsonEntries): JsonStringEntries {
  return jsons.map(([name, json]): JsonStringEntry => [
    name,
    JSON.stringify(json, undefined, 2)
  ])
}

function writeJsonData(
  jsonStringEntries: JsonStringEntries,
  targetPath: RelativePath,
  outRoot: AbsolutePath
): Promise<AbsolutePath>[] {
  return jsonStringEntries.map(
    async ([name, jsonData]): Promise<AbsolutePath> => {
      const outPath = joinPaths(outRoot, targetPath)
      const outDir = getParentDir(outPath)

      await ensureDir(outDir)

      const outFileName = `${name}.json` as RelativePath
      const outFilePath = joinPaths(outDir, outFileName)

      await writeFile(outFilePath, jsonData)

      logger.info(`Wrote to: ${outFilePath}`)

      return outFilePath
    }
  )
}

export async function makeConversionTask(
  targetPath: RelativePath,
  ctx: GenerationContext
): Promise<ReturnType<typeof writeJsonData>> {
  const { srcRoot, outRoot } = ctx

  const srcPath = joinPaths(srcRoot, targetPath)
  const tsUrl = pathToFileURL(srcPath).href

  const importedTs: unknown = await import(tsUrl)
  const validatedImport = validateImport(importedTs, srcPath)

  const schemaEntries = toSchemaEntries(validatedImport)

  const validatedSchemaEntries = validateSchemaEntries(schemaEntries)
  const jsonEntries = toJsonEntries(validatedSchemaEntries)
  const jsonData = toJsonData(jsonEntries)

  return writeJsonData(jsonData, targetPath, outRoot)
}
