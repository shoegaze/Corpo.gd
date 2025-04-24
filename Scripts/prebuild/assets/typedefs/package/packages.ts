import { array, lazy, literal, object, string, union } from 'zod'

import type { infer, ZodLazy, ZodType } from 'zod'


export const assetName =
  string()

export const assetType =
  union([
    literal('meta'),
    literal('text'),
    literal('texture'),
    literal('script')
  ])

export const assetContent =
  string()

export const asset =
  object({
    name: assetName,
    type: assetType,
    content: assetContent
  })

export const assetHolder =
  object({
    assets: asset.array()
  })


// TODO;

// type Group = object({
//   // metadata: string().optional(),
//   // assetHolders: infer<typeof assetHolder>[],
//   // subgroups: Group[]
//   metadata: string().optional(),
//   assetHolders: array(assetHolder),
//   subgroups: group.array()
// })

// export const group: ZodLazy<ZodType<Group>> =
//   lazy(() =>
//     object({
//       metadata: string().optional(),
//       assetHolders: array(assetHolder),
//       subgroups: group.array()
//     })
//   )

// export const packageRoot =
//   object({
//     metadata: string(),
//     shared: assetHolder.array(),
//     groups: group.array()
//   })

// export const author =
//   object({
//     packages: packageRoot.array()
//   })

// export const root =
//   object({
//     authors: author.array()
//   })
