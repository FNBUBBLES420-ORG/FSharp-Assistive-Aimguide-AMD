@echo off
chcp 65001 >nul 2>&1  REM Ensure UTF-8 encoding for compatibility
cls

echo ===============================
echo  🚀 Installing DotNet...
echo ===============================

:: Check if .NET SDK is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ .NET SDK is not installed. Please install .NET SDK from:
    echo ✅ .NET 8.0 Long Term Support
    echo 👉 https://dotnet.microsoft.com/en-us/download
    echo 👉 Follow the directions when installing .NET SDK.
    echo 👉 Once .NET is successfully installed, read below:
    echo ===============================
    echo 🎉 Close this terminal - Press Enter
    echo 👉 Navigate to the src folder where the .NET packages are stored *hint look at the readme.md.
    echo 👉 Copy all .NET package commands and paste them into a NEW CMD window.
    echo 👉 Press Start, type "CMD.exe", and press Enter.
    echo 👉 Paste all commands at once, press Enter to install them.
    echo 👉 The last package may require an additional Enter press.
    echo ===============================
    pause
    exit /b
)

echo ✅ .NET SDK is installed. Proceeding...
echo ===============================
echo 🎉 All dependencies are ready! Enjoy coding!
echo ===============================
pause
