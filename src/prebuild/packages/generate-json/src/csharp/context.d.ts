import { AbsolutePath } from '@corpo/common/path'


export interface GenerationContext {
  srcRoot: AbsolutePath
  outRoot: AbsolutePath
  namespace: string
}
