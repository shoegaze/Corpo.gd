import { lstat } from 'node:fs/promises'
import * as path from 'node:path'

import { mkdirp } from 'mkdirp'
import { rimraf } from 'rimraf'
import touch = require('touch')

import { E, L } from './log'


export type Path = string


export async function isDirectory(path: Path): Promise<boolean> {
  return lstat(path)
    .then(stats => stats.isDirectory())
    .catch(() => false)
}

export async function makeDirs(srcPath: Path, outPath: Path, depth = 0): Promise<void> {
  return Promise.all([
    mkdirp(srcPath),
    mkdirp(outPath)
  ])
    .then(([src, out]) => {
      if (src) {
        L(`Created src directory:`, depth + 1)
        L(src, depth + 2)
      }

      if (out) {
        L(`Created out directory:`, depth + 1)
        L(out, depth + 2)
      }
    })
    .catch(err => Promise.reject(err))
}

export async function cleanAll(outPath: Path, depth = 0): Promise<void> {
  return rimraf(outPath, {
    glob: true,
    preserveRoot: true
  })
    .then(success => {
      if (success) {
        L(`Cleaned ${outPath}`, depth + 1)
        return
      }

      L(`Ignored cleaning ${outPath}`, depth + 1)
    })
}

export async function prepare(srcPath: Path, outPath: Path, depth = 0): Promise<void> {
  L("Preparing src, out directories:", depth)
  L(`Creating ${srcPath}, ${outPath} if they don't exist`, depth + 1)

  await makeDirs(srcPath, outPath, depth + 1)
    .catch(err => {
      E(`Directory creation FAILED:`, depth + 2)
      E(err, depth + 3)
    })

  const cleanPath = path.join(
    outPath,
    '*'
  )

  L(`Cleaning ${cleanPath}`, depth + 1)

  await cleanAll(cleanPath, depth + 1)
    .catch(err => {
      E(`Cleaning FAILED:`, depth + 2)
      E(err, depth + 3)
    })

  L("Preparation complete")
}

export async function writeFile(outFile: Path, data: string, depth = 0): Promise<void> {
  L(`Writing to ${outFile}`, depth)

  await touch(outFile)

  return writeFile(outFile, data)
    .then(() => {
      L(`Write SUCCESS: ${outFile}`, depth + 1)
    })
    .catch(err => {
      E(`Write FAILED: ${outFile}`, depth + 1)
      E(`${err}`, depth + 2)

      return Promise.reject()
    })
}
