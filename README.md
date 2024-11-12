# **A Brain Game**

> Midterm Project: A cognitive training game developed in Unity, focused on enhancing processing speed, working memory, and cognitive flexibility.

## Table of Contents

- [About the Project](#about-the-project)
- [Gameplay Mechanics](#gameplay-mechanics)
- [Level Design](#level-design)
- [Other Features](#other-features)
- [How to Play](#how-to-play)
- [File Information](#file-information)
- [Credits and Acknowledgments](#credits-and-acknowledgments)
- [License](#license)

---

## About the Project

**A Brain Game** is a Unity-based cognitive training game designed to help players improve processing speed, working memory, and shifting abilities. Inspired by cognitive training apps like Lumosity and Cognifit, this game challenges players to eliminate crates by reducing their values to zero using subtraction. This project applies the concepts and techniques covered in the course and emphasizes developing an engaging, educational gameplay experience. This was a Midterm Project for Game Development (CS 4630) at Mizzou.

![image](https://github.com/user-attachments/assets/695c7f8a-999c-4df4-91fb-3e22eb6b12d8)

---

## Gameplay Mechanics

1. **Cannon Control**: Players use mouse movement to aim the cannon.
2. **Shooting Mechanics**: Pressing `S`, `D`, or `F` fires bullets with values of 1, 2, and 3, respectively, towards crates.
3. **Crate Spawning**: Crates with random values spawn from the top at intervals and fall towards the bottom of the screen.
4. **Crate Destruction**: When a bullet hits a crate, the bullet’s value is subtracted from the crate's value.
   - **Goal**: Reduce the crate’s value to exactly zero to destroy it and earn points.
   - **Penalty**: If the crate's value goes below zero, points are deducted, and the crate is destroyed.
5. **Failure Condition**: If a crate reaches the bottom of the screen without being reduced to zero, points are deducted.

---

## Level Design

1. **Multiple Levels**: The game includes three or more levels with progressively challenging objectives.
2. **Level Progression**:
   - Start with 50 of each bullet type (1, 2, and 3).
   - Players move up a level if they successfully complete the current level and move down if they fail.
3. **Scenes**:
   - **Start Scene**: Introduction to gameplay, developer information, credits, and a start button.
   - **End Scene**: Displays the final score, highest score, and a restart button.
4. **Timer**: Each level has a limited amount of time to complete it.

---

## Other Features

### UI Elements

- Displays current level
- Current score and remaining time
- Remaining bullets and crates
- Crate values for easy visibility

### Bonus Features

- **Audio & Visual Effects**:
- **Audio Control**: Button to turn audio on/off.
- **Pause Button**: Option to pause and resume the game.
- **Enhanced Crate Movements**: Variations in crate movements add gameplay variety.

---

## Installation

To run the game locally on Windows:
1. [Download the ZIP file](https://github.com/stella-craig/Brain-Game/releases/download/v1.0.0/Brain.Game.Build.zip)
2. Extract the ZIP file to your desired location.
3. Open the extracted folder and double-click `Brain Game.exe` to start the game.

---

## How to Play

- **Controls**:
  - **Move Cannon**: Move the mouse to adjust cannon direction.
  - **Fire Bullets**:
    - Press `S` to shoot a bullet with a value of 1.
    - Press `D` to shoot a bullet with a value of 2.
    - Press `F` to shoot a bullet with a value of 3.
  - **Pause**: Press the pause button to pause the game.
  - **Audio Control**: Toggle audio on/off as desired.

- **Objective**:
  - Shoot falling crates and reduce their values to zero without overshooting. Earn points for successful hits and avoid penalties for overshooting or missing crates.

---

## File Information

- [Brain Game Folder](https://github.com/stella-craig/Brain-Game/tree/main/Brain%20Game): The folder used by Unity Editor to work on the project. Includes all Assets and Packages.
- [Demo Video](https://github.com/stella-craig/Brain-Game/blob/main/Demo%20Video.mkv): A video of me demoing the game and showing off all the different features and gameplay. Required for the assignment.
- [Midterm Project Instructions](https://github.com/stella-craig/Brain-Game/blob/main/Midterm%20Project%20Instructions.pdf): The requirements for the project as given by the professor.

---

## Credits and Acknowledgments

- **Unity Technologies** for providing the game engine.
- **Background Music**: [30 MIN | Royalty Free Music | No Copyright | Meditation, Relaxation, Stress Relief, Ambient Music](https://www.youtube.com/watch?v=yd5b2L0gGqw&list=PLzUWQHotbql3pMZsAn9S4-eiWIYoXBKb5)
- **Inspiration**: Inspired by cognitive training apps such as Lumosity and Cognifit.

---

## License

This project is for educational purposes and is part of a course assignment. Any code or assets not explicitly developed by the author are credited to their respective owners.












