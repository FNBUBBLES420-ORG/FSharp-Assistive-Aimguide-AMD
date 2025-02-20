<p align="center">
  <img src="https://github.com/FNBUBBLES420-ORG/Assistive-AimGuide/blob/main/banner/Assitive-AimGuide.png" alt="Assistive-AimGuide" width="350">
</p>

<p align="center">
  <img src="https://github.com/FNBUBBLES420-ORG/Assistive-AimGuide/blob/main/Assistive-Aim-guide-Auto-Setup/fnbubbles420.png" alt="Fnbubbles420 Logo" width="80" align="left">
  <img src="https://github.com/FNBUBBLES420-ORG/Assistive-AimGuide/blob/main/Assistive-Aim-guide-Auto-Setup/fnbubbles420.png" alt="Fnbubbles420 Logo" width="80" align="right">
  <br><br><br>
  <h1 align="center">FNBubbles420 Org - Assistive Aim-Guide / AMD GPU</h1>
</p>

## Support the Project ⭐

# **If you find this project useful, Please Join Our Discord , We Have Lots to Offer, great community , supportive community, mental health support, and more [Click To Join](https://discord.fnbubbles420.org/)** your support is appreciated.
## FNBubbles420 Org is committed to creating an inclusive environment that supports all individuals, especially those dealing with mental health issues or physical disabilities. Our efforts are focused on providing adaptive technology, mental health resources, peer support groups, and creating educational programs that promote accessibility and mental wellness.

## 🚨 Disclaimer

This tool is developed as an **accessibility aid** for gamers with disabilities to help them compete more effectively in games.  
We **advocate for fair play** and accessibility in gaming and do **not endorse cheating** or the promotion of cheating in any form.  
Use of this tool in online games is at your own risk. Please consult with game developers if unsure about compatibility with game policies.  
This tool should be used primarily as an assistive device in environments that support inclusivity.

## Bubbles Advanced AI Anti Cheat Engine

### ***[BAAACE](https://github.com/KernFerm/Bubbles-Advanced-Ai-Anti-Cheat-Engine)***

---

## 🌟 About Us

At **[FNBubbles420 Org](https://github.com/FNBUBBLES420-ORG)**, we are dedicated to supporting **disabled gamers, developers, veterans, and streamers** through various initiatives. One of our primary programs is **[Game Vision Aid](https://github.com/FNBUBBLES420-ORG/game-vision-aid)**, which aims to enhance accessibility and performance for gamers with visual impairments.  

**Game Vision Aid is coming soon** — we are still testing and developing it to ensure it meets the highest standards for accessibility.

While the **Assistive AimGuide** is a separate project, it embodies our organization's dedication to leveraging innovative technologies to enhance accessibility and equality in gaming for those with disabilities. This commitment underlines our ongoing efforts to serve and uplift the community.

---

### 💬 Words to Live By  
*"Life is a journey best traveled together; when we lift each other up, we rise as a community, stronger and more united. Every small act of kindness creates ripples that can change the world."*  
– **Bubbles**

---

To learn more about what drives us, visit our **[Mission Page](https://www.fnbubbles420.org/ourmission)**.  
If you'd like to get involved or learn more about volunteering, visit our **[Volunteer Page](https://www.fnbubbles420.org/volunteer)**.

---

## 📥 How to Download the Repo (First-Time Users)

Click the link to read [**Instructions**](https://www.gitprojects.fnbubbles420.org/how-to-download-repos) 📄.

# Copyright Notice

© 2024 Bubbles The Dev and FNBUBBLES420ORG. All rights reserved.

This image, including its design, text, and visual elements, is protected under copyright law. Unauthorized use, reproduction, distribution, or modification without the express written permission of Bubbles The Dev and FNBUBBLES420ORG is prohibited. For licensing or usage inquiries, please contact [media@fnbubbles420.org](mailto:media@fnbubbles420.org).
</div>

# 🎯 Assistive Aim Guide (F# YOLO-Based AI)

🚀 **An AI-powered aim assistance tool designed for accessibility, featuring human-like movement and real-time object tracking.**

- **Smooth, non-locking mouse movement** for a natural feel.
- **Supports AMD GPUs** using DirectML acceleration for high-performance inference.
- **Real-time object detection** powered by **Ultralytics YOLO models**.
- **FPS & latency monitoring** for performance insights.
- **Dynamic YOLO model selection via UI** at runtime.
- **Windows 11 compatibility** (requires DirectX and Windows-specific libraries).
- **Supports ONNX models (`.onnx`)** for AI inference.
- **Arduino Leonardo support** for serial input-based control. **`Recommended`**

---

## 🛠 Features

- **AI-driven object detection** (detects players, objects, etc.).
- **Human-like aiming behavior** (no snap-locks or robotic movements).
- **Optimized for Windows 11** with **AMD DirectML acceleration**.
- **Real-time screen capture & automatic target detection**.
- **Configurable settings** for sensitivity, reaction time, and detection thresholds.
- **Supports multiple YOLO models** (Ultralytics and custom ONNX models).
- **Live FPS & latency tracking** displayed in the console.
- **Interactive UI for selecting YOLO models** at startup.
- **ONNX-only AI model support** (TensorRT `.engine` models are not supported).
- **Arduino Leonardo integration** for real-time serial control. 

---

## 📥 Installation Guide

### **Step 1: Install Required Dependencies**

#### 1️⃣ **Install .NET 8.0 LTS**

Ensure you have the **.NET 8.0 SDK** installed.  ***LONG TERM SUPPORT***
👉 [Download .NET SDK](https://dotnet.microsoft.com/en-us/download)  
Verify the installation by running:
```sh
dotnet --version
```

## 2️⃣ Install Project Dependencies
Run the setup script:
```
setup_dependencies.bat  # (Windows 11)
```
- Or manually install the required packages:

```
dotnet add package Microsoft.ML.OnnxRuntime --version 1.20.1
dotnet add package Microsoft.ML.OnnxRuntime.DirectML --version 1.20.1
dotnet add package TorchSharp --version 0.101.0
dotnet add package MathNet.Numerics --version 5.0.0
dotnet add package Emgu.CV --version 4.6.0.5131
dotnet add package System.IO.Ports --version 7.0.0
dotnet add package InputSimulatorStandard --version 1.0.0
dotnet add package RJCP.SerialPortStream --version 3.0.1
dotnet add package SharpDX --version 4.2.0
dotnet add package SharpDX.Direct3D11 --version 4.2.0
dotnet add package SharpDX.DXGI --version 4.2.0
dotnet add package Newtonsoft.Json --version 13.0.3
```

## 3️⃣ Configure Execution Policy for PowerShell
Open PowerShell as Administrator, navigate to the directory containing `install.ps1`, and run:
```
Set-ExecutionPolicy Bypass -Scope Process -Force
.\install.ps1
```
- click Y to continue if is asked you if you want to proceed.

### make sure to `CD` the `src` folder before doing below: 
## 🔧 Build and Run the Project
1️⃣ Restore Dependencies
```
dotnet restore
```

## 2️⃣ Compile the Project
```
dotnet build
```

## 3️⃣ Launch the Assistive Aim Guide
```
dotnet run
```
- Upon launch, a UI will prompt you to select a YOLO model before the tracking system starts.

### 🎮 How It Works
1. Select the YOLO model using the UI at launch.
2. Select your game window (or use the primary monitor for capture).
3. The AI detects objects in real-time and calculates the required movement.
4. The mouse moves naturally toward detected objects (no snap-locks).
5. FPS & latency are monitored in real-time and displayed in the console.
6. Exit the tool at any time by pressing the configured key.

## ⚙️ Configuration
You can edit the config.json file to tweak settings such as:

- Model file (`model_path`)
- Sensitivity (`mouse_speed`)
- Reaction delay (`reaction_time`)
- Detection confidence (`detection_threshold`)
- Enabled features (`visuals`, `debug_mode`)

```
{
  "model_path": "yolov8m.onnx",
  "mouse_speed": 1.5,
  "reaction_time": 50,
  "detection_threshold": 0.4,
  "visuals": true,
  "debug_mode": false,
  "gpu_id": 0
}
```

## 🔧 Troubleshooting
- Issue: Tool not detecting objects?
- Fix: Ensure your screen capture or camera is working and properly positioned.
---
- Issue: Mouse movements feel robotic.
- Fix: Adjust mouse_speed and reaction_time in config.json.
---
- Issue: Performance is slow.
- Fix: Verify you have an AMD GPU with DirectML acceleration and check the FPS monitor.
---
- Issue: Arduino Leonardo not recognized.
- Fix: Ensure the correct COM port is set and the drivers are properly installed.
---

### Note: This tool is Windows 11-only due to its reliance on DirectX and Windows-specific libraries.

# LICENSE
### ***This project is proprietary and all rights are reserved by the author.***
### ***Unauthorized copying, distribution, or modification of this project is strictly prohibited.***
### ***Unless You have written permission from the Developer or the FNBUBBLES420 ORG.***

## 📧 Need help? Contact us on Discord or open an issue!

[Invite Link](https://discord.fnbubbles420.org/invite)

- Go to the `Assistive AimGuide channel` and `ping Bubbles The Dev`.
- How to use custom models join the server and ask `Bubbles`.

## 🚀 Happy Gaming! 🎮
