# Ensure script runs with administrator privileges
if (-not ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) {
    Write-Host "❌ Please run this script as Administrator!"
    pause
    exit
}

Write-Host "==============================="
Write-Host "🚀 Installing Required Packages..."
Write-Host "==============================="

# Check if .NET SDK is installed
$dotnetVersion = & dotnet --version 2>$null
if (-not $dotnetVersion) {
    Write-Host "❌ .NET SDK is not installed. Please install .NET SDK from:"
    Write-Host "   https://dotnet.microsoft.com/en-us/download"
    pause
    exit
}

# Navigate to the script's directory
Set-Location -Path $PSScriptRoot

# Check if an .fsproj file exists in the directory
$fsprojFile = Get-ChildItem -Path . -Filter "*.fsproj" | Select-Object -First 1
if (-not $fsprojFile) {
    Write-Host "❌ No .fsproj file found! Ensure you are running this script inside a valid F# project directory."
    pause
    exit
}

# Define package list (Added System.IO.Ports for Serial Communication)
$packages = @(
    "Microsoft.ML.OnnxRuntime --version 1.20.1"
    "Microsoft.ML.OnnxRuntime.Gpu --version 1.20.1"
    "TorchSharp --version 0.101.0"
    "MathNet.Numerics --version 5.0.0"
    "Emgu.CV --version 4.6.0.5131"
    "ManagedCuda --version 10.0.0"
    "System.IO.Ports --version 7.0.0"
    "InputSimulatorStandard --version 1.0.0"
    "RJCP.SerialPortStream --version 3.0.1"
    "SharpDX --version 4.2.0"
    "SharpDX.Direct3D11 --version 4.2.0"
    "SharpDX.DXGI --version 4.2.0"
    "Newtonsoft.Json --version 13.0.3"
)

# Create a log file
$logfile = "install_log.txt"
if (Test-Path $logfile) { Clear-Content $logfile }
Add-Content -Path $logfile -Value "Install Log - $(Get-Date)"

# Install packages
foreach ($package in $packages) {
    Write-Host "Installing: $package..."
    $output = & dotnet add package $package 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Host "❌ Failed to install: $package (Check install_log.txt for details)"
        Add-Content -Path $logfile -Value "❌ Failed: $package - $output"
        pause
        exit
    }
    Write-Host "✅ Successfully installed: $package"
}

Write-Host "==============================="
Write-Host "🎉 All dependencies installed successfully!"
Write-Host "==============================="

# Check if Serial Ports exist (Modern PowerShell command)
Write-Host "🔍 Detecting Serial Ports..."
$serialPorts = Get-CimInstance Win32_SerialPort | Select-Object DeviceID, Description
if ($serialPorts) {
    $serialPorts | Format-Table -AutoSize
} else {
    Write-Host "⚠️ No serial ports detected. Ensure your Arduino Leonardo is connected."
}

pause
