import winston from 'winston'

const { combine, printf, timestamp, align } = winston.format


const formatter = printf(({ level, timestamp, message }) =>
  // eslint-disable-next-line @typescript-eslint/restrict-template-expressions
  `${timestamp} [${level}]: ${message}`
)

const logger = winston.createLogger({
  level: 'info',
  format: combine(
    timestamp(),
    align(),
    formatter
  ),
  transports: [
    new winston.transports.Console()
  ]
})



export default logger
