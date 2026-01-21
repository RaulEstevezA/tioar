# Tio AR — Extended Documentation (EN)

This document provides extended documentation for the **Tio AR** project developed by the **UOC Gamers** team.

---

## Project Summary

**Tio AR** is a mobile **Augmented Reality (AR)** mini-game developed using **Unity 6** and **XR / AR Foundation**.  
The player must locate the **Tió** in their real environment and hit it as many times as possible before time runs out.

The game follows a **3-round system**, with different time limits per round. The final score is accumulated globally and displayed at the end of the match.

---

## Gameplay Loop

The game is structured as three consecutive rounds:

### Round Structure
Each round consists of two phases:

1) **Search Phase**
- Displays the message **"Busca al Tió"**
- Duration: **5 seconds**
- This time **does not count** towards the round timer
- Allows the player to scan the environment and detect surfaces

2) **Hit Phase**
- The Tió spawns in a **random AR position**
- Message displayed: **"¡Golpea al Tió!"**
- The round timer starts (different per round)
- Each valid hit increments the score by **+1**

At the end of a round:
- Timer reaches 0
- The current Tió instance is destroyed
- The next round begins automatically

### Round Timers
The game uses a configurable array in the GameManager script:

- Round 1: **10 seconds**
- Round 2: **8 seconds**
- Round 3: **4 seconds**

> Note: These values can be modified easily from the Inspector.

---

## AR System (XR / AR Foundation)

The game uses the Unity XR pipeline with AR Foundation:

- **Plane detection** is enabled to allow AR surface tracking
- Plane visuals (debug grids / circles) can be disabled without affecting gameplay
- The Tió is spawned in front of the player using a random offset relative to the camera

### Tió Spawn Logic
The Tió appears using a random offset from the camera direction:

- Forward distance: 4 to 6 units
- Horizontal offset: -2 to 2 units

This produces a variety of valid spawn positions while keeping the target visible.

---

## UI System

The UI is built using **Canvas + TextMeshPro**:

### HUD
Displayed during gameplay:
- **TimeText** → Remaining time
- **ScoreText** → Total hits

### Timed Messages
Displayed automatically during each round:
- **SearchMessage** → "Busca al Tió" (5 sec)
- **HitMessage** → "¡Golpea al Tió!" (short hint before timer starts)

### Start Screen
The game starts with a panel:
- Start button
- Audio toggle icon

The match does not begin until the user presses **Start**.

### End Screen
After round 3:
- End panel appears
- Final score is displayed
- Restart button available

---

## Audio System

The project includes:
- Background music
- Random hit sounds (4 variations)
- Global sound toggle button (mute/unmute)

### Global Sound Toggle
Sound is controlled globally using:

- `AudioListener.volume = 1f` (enabled)
- `AudioListener.volume = 0f` (muted)

The icon changes depending on the current state.

### Hit Sound System
Each time the player hits the Tió:
- One sound is selected randomly from 4 different hit clips
- Played using `PlayOneShot()` to avoid cutting audio prematurely

---

## Touch Interaction / Hit Detection

Hits are detected using Unity event-based touch input:

### Required Components
- The Tió prefab includes a **Box Collider**
- The Main Camera includes a **Physics Raycaster**
- The scene includes an **EventSystem**

### Click Handling
On touch/click:
- A hit is registered only if the round is active
- Score increments +1
- A random hit sound plays

---

## Main Scripts

### `GameManagerAR`
Controls the full round loop:
- manages timers
- spawns/destroys the target
- updates UI
- triggers end screen
- restart logic

### `SearchMessage`
Displays the search message for a fixed duration.

### `TimedMessage`
Reusable component to show a message for a fixed time (used for "¡Golpea al Tió!").

### `SoundToggleButton`
Controls:
- mute/unmute
- icon switching
- updates global volume using `AudioListener`

### `TioHitSound`
Plays a random hit sound on successful touch.

---

## Build & Deployment Notes

- Platform: **Android**
- AR support requires a device compatible with **ARCore**
- Camera permission is required for AR operation

---

## Known Limitations

- This AR module is separated from the 2D and 3D parts of the project due to integration/build constraints
- Spawn is random relative to the camera; advanced plane-based placement (e.g., surface selection) is not required for this version

---

## Credits

Developed by the **UOC Gamers** team:

- Aleix Ortiz
- Carlos Ruz
- Jordi Montserrat
- Raul Estevez
- Roger Mohino


[**Main**](README.md)

[**Setup & Requirements (English)**](SETUP.md)