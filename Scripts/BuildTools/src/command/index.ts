import { Command } from '@commander-js/extra-typings'

import { buildAllCommand } from './build_all'
import { buildCSharpCommand } from './build_csharp'
import { buildJsonCommand } from './build_json'


type Commands = Command<[], Record<string, string>>[]

export const commands: Commands = [
  buildAllCommand,
  buildJsonCommand,
  buildCSharpCommand
] as const
