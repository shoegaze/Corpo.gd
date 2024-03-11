export type Environment = {
  paths: {
    screens: {
      base: string,
      loading: string,
      overworld: string,
      battle: string,
      mainMenu: {
        path: string,
        buttons: {
          root: string,
          newGame: string,
          loadGame: string,
          settings: string,
          exit: string
        },
        submenus: {
          root: string,
          saves: string,
          settings: string
        }
      }
    }
  }
};