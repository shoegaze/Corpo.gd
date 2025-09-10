import { object } from 'zod'

import { godotRelativePath, godotUrl } from '../godot'


const paths = () =>
  object({
    assets: object({
      vars: godotUrl()
    }),
    file: object({
      var: object({
        config: godotRelativePath()
      })
    })
  })


export const environment =
  object({
    path: paths()
  })
    .describe('Environment JSON')
