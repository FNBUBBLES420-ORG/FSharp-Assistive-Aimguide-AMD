# 🛠 How to Compile the Assistive Aim Guide into an Executable (.exe)

This guide explains how to **compile your F# project into a `.exe` file** that runs on Windows 11.

---

## **🔹 Method 1: Using .NET CLI (`dotnet publish`)** ✅ (Recommended)
This method produces a **standalone executable** that **does not require the .NET runtime**.

### **✅ Steps:**

### **1️⃣ Ensure .NET SDK is Installed**  
Check if you have the .NET SDK installed:
```sh
dotnet --version
```
If missing, install it from:  
👉 [Download .NET SDK](https://dotnet.microsoft.com/en-us/download)

---

### **2️⃣ Navigate to Your Project Directory**
Open **Command Prompt (cmd)** and navigate to your F# project:
```sh
cd path\to\your\project
```

---

### **3️⃣ Publish as a Standalone `.exe`**
Run the following command to generate a Windows 11 `.exe`:
```sh
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true -p:AssemblyName=Assistive-AimGuide
```
- `-c Release` → Optimized build mode.
- `-r win-x64` → Targets **Windows 64-bit**.
- `--self-contained true` → No need to install .NET runtime.
- `-p:PublishSingleFile=true` → Generates a **single `.exe` file**.
- `-p:EnableCompressionInSingleFile=true` → Reduces `.exe` size.
- `-p:AssemblyName=Assistive-AimGuide` → Names the output file as **`Assistive-AimGuide.exe`**.

---

### **4️⃣ Find Your `.exe` File**
After building, the `.exe` will be located at:
```
bin\Release\netX.X\win-x64\publish\Assistive-AimGuide.exe
```

---

### **5️⃣ Run the `.exe`**
Execute the program by running:
```sh
bin\Release\netX.X\win-x64\publish\Assistive-AimGuide.exe
```

---

## **🔹 Method 2: Using `fsc.exe` (F# Compiler) 📌**
This method is useful for simple projects without external dependencies.

### **✅ Steps:**

### **1️⃣ Compile F# Code to `.exe`**
```sh
fsc.exe -o:Assistive-AimGuide.exe -r:System.Console.dll Assistive-AimGuide.fs
```
- `-o:Assistive-AimGuide.exe` → Names the output file.
- `-r:System.Console.dll` → Includes required dependencies.
- `Assistive-AimGuide.fs` → Main F# file.

---

### **2️⃣ Run the `.exe`**
```sh
Assistive-AimGuide.exe
```

---

## **🔥 Recommended Approach**
✅ Use **Method 1 (`dotnet publish`)** if your project uses **multiple files and dependencies**.  
✅ Use **Method 2 (`fsc.exe`)** if your project is a **single file without dependencies**.  

Let me know if you need any help! 🚀
