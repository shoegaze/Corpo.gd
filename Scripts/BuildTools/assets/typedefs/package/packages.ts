import { array, lazy, literal, object, string, union, ZodType } from 'zod'


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


type Group = {
  metadata?: string,
  assetHolders: Zod.infer<typeof assetHolder>[],
  subgroups: Group[]
}

export const group: ZodType<Group> =
  lazy(() =>
    object({
      metadata: string().optional(),
      assetHolders: array(assetHolder),
      subgroups: group.array()
    })
  )

export const packageRoot =
  object({
    metadata: string(),
    shared: assetHolder.array(),
    groups: group.array()
  })

export const author =
  object({
    packages: packageRoot.array()
  })

export const root =
  object({
    authors: author.array()
  })
