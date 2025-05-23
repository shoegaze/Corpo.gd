import { Command } from '@commander-js/extra-typings'

import { generateAllCommand } from './generate-all'
import { generateCSharpCommand } from './generate-csharp'
import { generateJsonCommand } from './generate-json'


type Commands = Command<[], Record<string, string>>[]


const commands: Readonly<Commands> = [
  generateAllCommand,
  generateCSharpCommand,
  generateJsonCommand
] as const


export default commands
