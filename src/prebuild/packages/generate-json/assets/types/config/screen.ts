import {
  object,
  record,
  string
} from 'zod'

import { godotRelativePath, godotUniqueName } from '../godot'


const sceneFilePath = () =>
  godotRelativePath()
    .endsWith('.tscn')
    .describe('Relative file path to the Godot scene file')

const screenName = () =>
  string()
    .nonempty()
    .describe('Registered name of screen service')


const screenViewKey = () =>
  string()
    .nonempty()
    .describe('Unique key for screen subview')

const screenViewName = () =>
  godotUniqueName()
    .nonempty()
    .describe('Godot Node name for screen subview')


const screenItem = () =>
  object({
    // Allow automatic calculation from screen name
    file: sceneFilePath().optional(),
    views: record(screenViewKey(), screenViewName())
  })

export const screenItems = () =>
  record(screenName(), screenItem())
