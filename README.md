<div align="center">

# Supernova

### A space-themed arcade game built with the Unity engine

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Unity](https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=unity&logoColor=white)
[![Repo](https://img.shields.io/badge/GitHub-jackinf%2FSupernovaUnity-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/jackinf/SupernovaUnity)

</div>

## Overview

Supernova is a space arcade game made with Unity. The player picks a ship in a
selection screen, then flies it through a playable level orbiting a central
point, shooting and avoiding hazards while managing a limited number of lives.
The game flows through dedicated start, ship-selection, gameplay, win, and lose
scenes, with a score and lives manager tracking progress along the way.

## Features

- Ship selection screen that cycles through multiple ship models and remembers the chosen ship across scenes
- Orbit-based player movement and weapon firing in the main level
- Score and lives tracking with respawn, invincibility blinking, and game-over handling
- Multiple game scenes wired together: start menu, ship selection, level, win, and lose
- Sound management, pause support, and timed object cleanup
- Built on Unity Standard Assets (cross-platform input, utility helpers) and a Planet Earth / skybox visual pack

## Tech Stack

| Area | Technology |
| --- | --- |
| Language | C# |
| Engine | Unity 5.1.2f1 |
| Frameworks/Assets | Unity Standard Assets, Cross-Platform Input |
| Project files | Visual Studio solution (`.sln`) and `.csproj` projects |

## Getting Started

### Prerequisites

- [Unity](https://unity.com/) (project was authored with Unity **5.1.2f1**; a matching or compatible legacy version is recommended)
- Optional: Visual Studio for editing the C# scripts via the included `.sln`

### Installation

```bash
git clone https://github.com/jackinf/SupernovaUnity.git
```

### Running

This is a Unity project, not a CLI/build-script project, so there are no
`make`/`npm` commands to run. To play or develop it:

1. Open the Unity Hub (or the Unity Editor directly).
2. Add / open the cloned `SupernovaUnity` folder as a project.
3. In the Project window open `Assets/Scenes/start.unity`.
4. Press **Play** in the editor, or use **File > Build Settings** to build a standalone player.

To edit the scripts, open `UnityVS.Supernova2.sln` in Visual Studio.

## Project Structure

```
SupernovaUnity/
├── Assets/
│   ├── Scenes/        # start, spaceship_select, level1, you_win, you_lose
│   ├── Scripts/       # Common, ShipSelectionScene, Level1 gameplay logic
│   ├── Prefabs/       # Ship and object prefabs
│   ├── Materials/     # Materials and shaders
│   ├── Models/        # 3D models
│   ├── Textures/      # Textures and skyboxes
│   ├── Sounds/        # Audio clips
│   └── Standard Assets/  # Unity cross-platform input & utilities
├── ProjectSettings/   # Unity project configuration
└── UnityVS.Supernova2.sln  # Visual Studio solution
```
