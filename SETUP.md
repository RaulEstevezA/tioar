# Setup & Requirements (EN)

This document explains how to **run and build** the *Tio AR* project.

---

## Quick Start (APK)

If you only want to test the game on a mobile device, download the latest APK from:

- [Releases](../../releases)

> The APK requires an **ARCore-compatible** Android device and camera permission.

---

## Requirements

### Software
- **Unity 6** (recommended: latest stable version used in the project)
- **Android Build Support** module installed via Unity Hub
- **Android SDK + NDK + OpenJDK** (Unity Hub can install these automatically)

### Unity Packages
The project uses XR/AR packages such as:
- **AR Foundation**
- **XR Interaction Toolkit**
- **ARCore XR Plugin**

All packages can be installed and verified via:
`Window → Package Manager`

---

## Build Settings (Android)

Open:
`File → Build Settings`

- Platform: **Android**
- Click **Switch Platform** (if not already selected)

Recommended settings:
- Build System: **Gradle**
- Target Architecture: **ARM64** (recommended)

---

## Player Settings (Android)

Open:
`Edit → Project Settings → Player → Android`

### Orientation
- Default Orientation: **Landscape Left** (or Landscape)

### Permissions
- **Camera permission** is required (AR mode)
- Unity/AR Foundation will request it automatically at runtime

### Graphics API
ARCore does **not support Vulkan** in this project configuration.

Ensure:
- `Auto Graphics API` disabled
- **OpenGLES3** enabled
- Vulkan removed

---

## XR / AR Configuration

Open:
`Edit → Project Settings → XR Plug-in Management`

- Enable **XR Plug-in Management**
- Under Android:
  - Enable ARCore (ARCore XR Plugin)

Open:
`Edit → Project Settings → XR Plug-in Management → AR Foundation`
- Default configuration is sufficient for this project

---

## Run in Unity (Editor)

AR features require a real device.  
Testing in the Unity Editor is limited because there is no real camera-based tracking.

Recommended workflow:
1) Build APK
2) Install on device
3) Test AR behavior on a real environment

---

## Build APK

1) `File → Build Settings`
2) Select Android
3) Click **Build**
4) Choose output folder
5) Install the generated APK on the device

---

## Notes

- If you face camera black screen issues, verify:
  - ARCore support on device
  - Camera permission granted
  - OpenGLES3 enabled (no Vulkan)
- The project is intended for academic evaluation and demo purposes.

[**Main**](README.md)
[**English documentation**](README_en.md)