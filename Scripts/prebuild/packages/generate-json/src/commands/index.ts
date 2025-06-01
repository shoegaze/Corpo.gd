import { generateAllCommand } from './generate-all'
import { generateCSharpCommand } from './generate-csharp'
import { generateJsonCommand } from './generate-json'

import type { Command } from '@commander-js/extra-typings'


type Commands = Command<[], Record<string, string>>[]


const commands: Readonly<Commands> = [
  generateAllCommand,
  generateCSharpCommand,
  generateJsonCommand
] as const


export default commands
