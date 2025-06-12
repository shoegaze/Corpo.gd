import {
  array,
  object,
  string,
  union
} from 'zod'


export const about =
  object({
    name: string(),
    author: string(),
    license: string(),
    contact: union([
      string(),
      array(string())
    ]),
    description: string()
  })
    .describe('Package metadata')
