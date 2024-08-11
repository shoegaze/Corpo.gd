import { writeFile } from 'node:fs/promises'

import { mkdirp } from 'mkdirp'
import { rimraf } from 'rimraf'
import { globby } from 'globby'
import touch = require('touch')

import { AbsolutePath, Extension, glob, parent, toPosix } from './path'


export const jsonExtension = '.json'
export const tsExtension = '.ts'
export const csExtension = '.cs'
export const csNamespaceSeparator = '.'


export const make = async (dir: AbsolutePath): Promise<void> =>
  mkdirp(dir)
    .then()

export const clean = async (dir: AbsolutePath): Promise<void> => {
  const dirGlob = glob(dir)

  return rimraf(dirGlob, {
    glob: true
  })
    .then(success => {
      if (!success) {
        throw new Error(`Couldn't clean directory '${dir}'`)
      }
    })
}

export const write = async (file: AbsolutePath, data: string): Promise<void> => {
  await touch(file)
  return writeFile(file, data)
}

export const search = async (root: AbsolutePath, extension?: Extension): Promise<AbsolutePath[]> =>
  globby(
    glob(root, extension)
  )
    .then(paths =>
      paths.map(path =>
        toPosix(path as AbsolutePath)
      ) as AbsolutePath[]
    )

export const walks = async (root: AbsolutePath): Promise<AbsolutePath[]> =>
  search(root)
    .then(paths => {
      const dirs = new Set<AbsolutePath>()

      paths.forEach(path => {
        const dir = parent(path)
        dirs.add(dir)
      })

      return Array.from(dirs.values())
    })
