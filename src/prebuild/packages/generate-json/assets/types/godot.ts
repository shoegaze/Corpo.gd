import {
  string,
  union
} from 'zod'


export const godotUrl = () => union([
  string().startsWith('res://'),
  string().startsWith('user://')
])

// Negation of Godot URL (does not start with '://')
export const godotRelativePath = () =>
  string().regex(/^\w(?!\w+:\/\/).*$/)

export const godotUniqueName = () =>
  string().startsWith('%')
