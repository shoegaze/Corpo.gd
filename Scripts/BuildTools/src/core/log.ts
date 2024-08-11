import { format } from 'date-fns'
import { log, warn, error } from 'node:console'


function logPrefix(depth: number) {
  if (depth === 0) {
    return ''
  }

  const spacing = '  '.repeat(depth)

  const bullets = ['*', '-', '>']
  const i = (depth - 1) % bullets.length
  const bullet = bullets[i]

  return `${spacing}${bullet} `
}

function timestamp(): string {
  const now = Date.now()
  const timestamp = format(
    now,
    'yyyy.MM.dd-HH:mm:ss.SSS'
  )

  return timestamp
}

export function LT(message: string) {
  log(`[${timestamp()}] ${message}`)
}

export function ET(message: string) {
  error(`[${timestamp()}] ${message}`)
}

export function L(message: string, depth = 0) {
  const prefix = logPrefix(depth)
  log(`${prefix}${message}`)
}

export function W(message: string, depth = 0) {
  const prefix = logPrefix(depth)
  warn(`[WARN] ${prefix}${message}`)
}

export function E(message: string, depth = 0) {
  const prefix = logPrefix(depth)
  error(`[ERROR] ${prefix}${message}`)
}
