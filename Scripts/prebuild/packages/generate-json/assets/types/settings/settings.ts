import { literal, object } from 'zod'


export const settings =
  object({
    value: literal('TODO')
  })
    .describe('Game settings')
