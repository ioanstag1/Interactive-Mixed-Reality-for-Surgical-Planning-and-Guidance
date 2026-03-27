# Interactive Mixed Reality for Surgical Planning and Guidance
### Standalone MR System on Meta Quest 3


---

## Overview

A standalone Mixed Reality application for interactive anatomical 
exploration, built for the Meta Quest 3. The system combines AI-driven 
CT segmentation, real-time volume rendering, and controller-free hand 
tracking to support both surgical planning and intraoperative simulation 
in a single MR platform.

---

## Key Features

| Feature | Details |
|---|---|
| CT Segmentation | TotalSegmentator (nnU-Net) + manual refinement in 3D Slicer |
| Volume Rendering | Real-time raymarching via UnityVolumeRendering |
| Interactive Slicing | Free-axis axial, coronal, sagittal planes — repositionable in 3D |
| Synchronized Monitor | Virtual 2D display updating in real time from slice planes |
| Organ Manipulation | Grab, move, and toggle individual segmented meshes |
| Interaction | Controller-free hand tracking via Meta XR SDK |
| Device | Meta Quest 3 (standalone, no PC required) |

---

## System Pipeline
```
CT (DICOM) → TotalSegmentator → 3D Slicer → OBJ/STL meshes
                                                        ↓
CT (DICOM) → UnityVolumeRendering → Real-time volume
                                                        ↓
                              Unity (Meta Quest 3 MR App)
```

---

## Two Modes

### 1. Intraoperative Simulation
CT volume embedded in a virtual patient model on a surgical table. 
Three interactive slicing planes (axial, coronal, sagittal) update 
a synchronized 2D monitor in real time. Users navigate anatomy 
freely using hand gestures.

### 2. Surgical Planning
Segmented organ and bone meshes are layered on top of the CT volume. 
Users toggle individual structures on/off and spatially manipulate 
them to assess surgical paths and anatomical relationships.

---
## System in Action

### 3D Segmented Anatomy
<img width="801" height="304" alt="image" src="https://github.com/user-attachments/assets/01a231cd-95d4-4a77-8ccf-b81d37566236" />

### Volume Rendering
<img width="843" height="371" alt="image" src="https://github.com/user-attachments/assets/8fb47e12-2d04-46a4-ac8f-d1efb84f01f2" />

### Simulation Setup
<img width="892" height="326" alt="image" src="https://github.com/user-attachments/assets/7a4b0066-0003-4cc6-8197-ea5e6b1a5c1d" />

### Simulation / Interaction
<img width="507" height="287" alt="image" src="https://github.com/user-attachments/assets/3cc12c46-f00e-47e4-8f72-e8aa28dd5869" />
<img width="507" height="287" alt="image" src="https://github.com/user-attachments/assets/bafbd046-23db-4b98-92a5-444be83a404c" />
<img width="510" height="287" alt="image" src="https://github.com/user-attachments/assets/4ed9656c-e9f5-49d0-82a1-3b4bbb1eae3e" />




--- 
## Stack

| Component | Technology |
|---|---|
| Development platform | Unity (C#) |
| MR SDK | Meta XR SDK |
| Segmentation | TotalSegmentator, 3D Slicer |
| Volume rendering | UnityVolumeRendering (raymarching) |
| Medical data format | DICOM, NRRD, OBJ/STL |
| Device | Meta Quest 3 |

---
## Dependencies

- [UnityVolumeRendering](https://github.com/mlavik1/UnityVolumeRendering) 
  by Morten Lavik — open-source Unity toolkit for real-time DICOM/NRRD 
  volume rendering via raymarching
- Meta XR SDK — hand tracking and passthrough on Meta Quest 3
- TotalSegmentator — AI-based multi-organ CT segmentation
- 3D Slicer — segmentation refinement and mesh export
---

## Limitations & Future Work

- Spatial registration currently relies on visual approximation
- Performance constrained by Meta Quest 3 hardware on high-res datasets
- Future: haptic feedback integration, 4D CT support, 
  automatic landmark-based registration, clinical evaluation with surgeons

---
- Lavik, M. (2021). UnityVolumeRendering [Open-source Unity plugin]. 
  GitHub. https://github.com/mlavik1/UnityVolumeRendering
