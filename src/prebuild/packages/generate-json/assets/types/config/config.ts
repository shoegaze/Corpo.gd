import { object, string } from 'zod'

import { screenItems } from './screen'


const screens = () =>
  object({
    group: string().nonempty(),
    items: screenItems()
  })

const paths = () =>
  object({
    screens: screens()
  })


export const config =
  object({
    paths: paths()
  })
    .describe('Configuration JSON')
