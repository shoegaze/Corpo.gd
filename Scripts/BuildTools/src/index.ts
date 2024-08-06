import { program } from '@commander-js/extra-typings'

import { L } from '@core/log'
import { commands } from './command'


program
  .name('Corpo Build Tool')
  .description('CLI to execute Corpo precompilation actions')
  .version('0.0.1')

commands.forEach(cmd => {
  L(`Adding command: '${cmd.name()}'`, 1)
  program.addCommand(cmd)
})


program.parse()
