// import { writeFile } from 'node:fs/promises'

// import { globby } from 'globby'
// import { mkdirp } from 'mkdirp'
// import { rimraf } from 'rimraf'
// import touch from 'touch'

// import {
//   AbsolutePath,
//   getParentDir,
//   toDeepGlobPath,
//   toPosixPath
// } from './path'


// export const names = {
//   json: {
//     extension: '.json'
//   },
//   ts: {
//     extension: '.ts'
//   },
//   cs: {
//     extension: '.cs',
//     nsSeparator: '.'
//   }
// } as const


// export async function makeDir(dir: AbsolutePath): Promise<void> {
//   await mkdirp(dir)
// }

// export async function cleanDir(dir: AbsolutePath): Promise<void> {
//   const dirGlob = toDeepGlobPath(dir, '')
//   const success = await rimraf(dirGlob, { glob: true })

//   if (!success) {
//     throw new Error(`Couldn't clean directory '${dir}'`)
//   }
// }

// export async function write(
//   file: AbsolutePath,
//   data: string
// ): Promise<void> {
//   await touch(file)
//   await writeFile(file, data)
// }

// export async function search(
//   root: AbsolutePath,
//   filter = '*'
// ): Promise<AbsolutePath[]> {
//   const globPath = toDeepGlobPath(root, filter)
//   const paths = await globby(globPath)

//   return paths.map(path =>
//     toPosixPath(path as AbsolutePath)
//   )
// }

// /**
//  * Gets unique paths to
//  *
//  * @param root
//  * @returns
//  */
// export async function walks(
//   root: AbsolutePath
// ): Promise<AbsolutePath[]> {
//   const paths = await search(root)
//   const dirs = new Set<AbsolutePath>()

//   for (const path of paths) {
//     const dir = getParentDir(path)
//     dirs.add(dir)
//   }

//   return Array.from(dirs.values())
// }
