import { program } from '@commander-js/extra-typings'

import commands from './commands'
import manifest from '../package.json'


program
  .name(manifest.name)
  .description(manifest.description)
  .version(manifest.version)


commands.forEach((cmd) => {
  program.addCommand(cmd)
})


program.parse()
