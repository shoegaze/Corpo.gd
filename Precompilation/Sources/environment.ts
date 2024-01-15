export type Environment = {
  paths: {
    screens: {
      base: string,
      loading: string,
      overworld: string,
      battle: string,
      mainMenu: {
        root: string,
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