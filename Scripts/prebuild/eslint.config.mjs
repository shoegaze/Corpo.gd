import globals from 'globals'

import eslint from '@eslint/js'
import tseslint from 'typescript-eslint'

import stylistic from '@stylistic/eslint-plugin'
import stylisticTs from '@stylistic/eslint-plugin-ts'
import parserTs from '@typescript-eslint/parser'

export default [
  {
    languageOptions: {
      parserOptions: {
        projectService: {
          allowDefaultProject: ['*.js'],
          defaultProject: 'tsconfig.json'
        },
        tsconfigRootDir: import.meta.dirname,
      },
      globals: {
        ...globals.node
      }
    }
  },

  {
    ignores: [
      'eslint.config.mjs',
      'node_modules',
      '**/node_modules',
      '**/.build'
    ]
  },

  {
    files: ['packages/**/*.{js,mjs,cjs,ts,mts,jsx,tsx}'],
    languageOptions: {
      parser: parserTs,
      parserOptions: {
        sourceType: 'module'
      }
    },
  },


  eslint.configs.recommended,
  ...tseslint.configs.recommendedTypeChecked,
  ...tseslint.configs.stylisticTypeChecked,

  stylistic.configs.recommended,
  stylistic.configs['disable-legacy'],

  {
    files: ['packages/**/*.{js,mjs,cjs,ts,mts,jsx,tsx}'],
    plugins: {
      '@stylistic': stylistic,
      '@stylistic/ts': stylisticTs
    },
    rules: {
      // linting
      'no-unused-vars': ['error', {
        'argsIgnorePattern': '^_'
      }],
      'no-useless-rename': ['error'],
      'sort-imports': ['error', { 'allowSeparatedGroups': true }],

      '@typescript-eslint/no-unused-vars': ['error', {
        'argsIgnorePattern': '^_'
      }],

      // styling
      '@stylistic/arrow-parens': ['error', 'as-needed', {
        'requireForBlockBody': true
      }],
      '@stylistic/brace-style': ['error', '1tbs'],
      '@stylistic/comma-dangle': ['error', 'never'],
      '@stylistic/indent': ['error', 2],
      '@stylistic/max-len': ['error', {
        'code': 70,
        'comments': 80,
        'ignoreStrings': true,
        'ignoreUrls': true,
        'ignoreTrailingComments': true
      }],
      '@stylistic/max-statements-per-line': ['error', { 'max': 1 }],
      '@stylistic/no-multiple-empty-lines': ['error', { 'max': 2, 'maxEOF': 1 }],
      '@stylistic/object-curly-newline': ['error', {
        'consistent': true,
        'minProperties': 3,
        'multiline': true
      }],
      '@stylistic/operator-linebreak': ['error', 'after'],
      '@stylistic/quote-props': ['error', 'consistent-as-needed'],
      '@stylistic/quotes': ['error', 'single'],
      '@stylistic/semi': ['error', 'never']
    }
  }
]
