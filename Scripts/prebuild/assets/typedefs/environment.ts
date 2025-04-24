import { object, string } from 'zod'

// TODO: Add string.refine(validatePath(...))
//  const path = (root, path) => validatePath(root, path) ?? throw Error()
//  const objRef = (screen, ref) => validateRef(screen, ref)
export const environment =
  object({
    // TODO: Move paths def. under packages
    path: object({
      log: string(),
      package: object({
        root: string(),
        shared: string(),
        overworld: string(),
        battle: string()
      }),
      screen: object({
        base: string(),
        loading: string(),
        overworld: string(),
        battle: string(),
        mainMenu: object({
          path: string(),
          button: object({
            root: string(),
            newGame: string(),
            loadGame: string(),
            settings: string(),
            exit: string()
          }),
          submenu: object({
            root: string(),
            saves: string(),
            settings: string()
          })
        })
      })
    }),
    handle: object({
      resource: object({
        package: string(),
        shared: string(),
        // TODO: Merge into generic resource-group ID
        overworld: string(),
        battle: string()
      })
    })
  })
