# Sand and Flame

## Project Overview
Project consists of three scenes:
- 00_Boot - Initial loading scene
- 01_Menu - Main menu and level selection
- 02_Game - Core gameplay scene

## Requirements
- Unity 2021.3.45f1 LTS or newer
- Reference resolution Landscape 1920x1080

## How to Start the Game
1. Open the 00_Boot scene in Unity
2. Click Play in Unity
3. Choose level in the menu scene
4. Click Play at the menu scene

## Development Guidelines
- All game scenes should be loaded through the boot scene
- Use the Infrastructure layer for core systems
- UI elements should be managed through the UI scripts
- Runtime scripts handle gameplay mechanics
- Core scripts contain fundamental game systems

## Building the Game
1. Open 00_Boot scene
2. Go to File > Build Settings
3. Add all scenes in the correct order:
   - 00_Boot
   - 01_Menu
   - 02_Game
4. Configure platform settings
5. Click "Build" or "Build and Run"
