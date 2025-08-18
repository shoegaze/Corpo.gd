import { object } from 'zod'

import { godotUrl, godotRelativePath } from '../godot'


const path = () =>
  object({
    assets: object({
      screens: godotUrl(),
      vars: godotUrl()
    }),
    file: object({
      var: object({
        config: godotRelativePath(),
        settings: object({
          default: godotRelativePath(),
          user: godotUrl()
        })
      })
    })
  })


export const environment =
  object({
    path: path()
  })
    .describe('Environment JSON')
