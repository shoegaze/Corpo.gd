import {
  array,
  object,
  string,
  union
} from 'zod'


export const packages =
  array(
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
  )
    .describe('Resource packages')
