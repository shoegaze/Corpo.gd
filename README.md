# Corpo

## Build Instructions

### Godot Requirements

- Godot Version: `Godot_v4.2.1-stable_mono_*` 

Currently only tested on `windows`

### .NET Requirements

- Godot SDK Version: `Godot.NET.Sdk/4.2.1`
- Target Framework: `net6.0`

### Node.js Requirements

Install the following here: https://nodejs.org

(You can optionally install using a version manager such as `nvm`: https://github.com/nvm-sh/nvm)

- `node 20.10.0 (LTS)`
- `npm 10.3.0`

### Building

The following assume you are in the project root (`Corpo/`)

#### Initial Setup

```bash
$ cd Precompilation
$ npm i
```

This installs the necessary npm packages for the precompilation phase.

#### Precompilation Phase

```bash
$ cd Precompilation
$ npm start
```

This (re)generates JSON object definitions.

So far only needed for initial setup or the type definitions under `Precompilation/Sources` are changed.

#### Godot Build+Run

```bash
$ PATH_TO_GODOT_EXECUTABLE --path PATH_TO_PROJECT_ROOT
```

- Replace `PATH_TO_GODOT_EXECUTABLE` with the path to the Godot executable file (e.g. to `Godot_v4.2.1-stable_mono_win64.exe`)
- Replace `PATH_TO_PROJECT_ROOT` with the path to the `Corpo` project root

This will run the project via the commandline.

The equivalent may also be done through the Godot Editor.

## Contributing

### Branching Strategy

- `main` - Release milestone branch
  - Linear history
- `dev` - Development branch
  - Merged into commit when the milestone is reached
  - Feature branches should branch off of this and merged back into `dev`
