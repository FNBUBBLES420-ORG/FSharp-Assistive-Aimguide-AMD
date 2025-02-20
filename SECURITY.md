# Security and Dependency Management

This document outlines the security considerations and dependency management guidelines for this project. Use the grids below to install the correct package versions for your target GPU hardware.

---

## Dependency Integrity

All dependencies are managed via the .NET package manager (`dotnet add package`). The versions listed in the tables have been verified for compatibility and security. Always use secure connections when installing packages, and verify package integrity using the publisher’s checksums or signatures.

---

## AMD GPU Deployment

For systems with AMD GPUs using DirectML, install the following packages:

| **Package**                           | **Command**                                                                                               | **Version**    |
|---------------------------------------|-----------------------------------------------------------------------------------------------------------|----------------|
| Microsoft.ML.OnnxRuntime              | `dotnet add package Microsoft.ML.OnnxRuntime --version 1.20.1`                                              | 1.20.1         |
| Microsoft.ML.OnnxRuntime.DirectML     | `dotnet add package Microsoft.ML.OnnxRuntime.DirectML --version 1.20.1`                                     | 1.20.1         |
| TorchSharp                            | `dotnet add package TorchSharp --version 0.101.0`                                                           | 0.101.0        |
| MathNet.Numerics                      | `dotnet add package MathNet.Numerics --version 5.0.0`                                                       | 5.0.0          |
| Emgu.CV                               | `dotnet add package Emgu.CV --version 4.6.0.5131`                                                           | 4.6.0.5131     |
| System.IO.Ports                       | `dotnet add package System.IO.Ports --version 7.0.0`                                                        | 7.0.0          |
| InputSimulatorStandard                | `dotnet add package InputSimulatorStandard --version 1.0.0`                                                 | 1.0.0          |
| RJCP.SerialPortStream                 | `dotnet add package RJCP.SerialPortStream --version 3.0.1`                                                  | 3.0.1          |
| SharpDX                               | `dotnet add package SharpDX --version 4.2.0`                                                                | 4.2.0          |
| SharpDX.Direct3D11                    | `dotnet add package SharpDX.Direct3D11 --version 4.2.0`                                                     | 4.2.0          |
| SharpDX.DXGI                          | `dotnet add package SharpDX.DXGI --version 4.2.0`                                                           | 4.2.0          |
| Newtonsoft.Json                       | `dotnet add package Newtonsoft.Json --version 13.0.3`                                                       | 13.0.3         |

---

## Additional Security Measures

- **Environment Isolation:**  
  Utilize containerization or virtual environments to isolate project dependencies from your host system.

- **Regular Updates:**  
  Monitor for security updates and vulnerability patches for all dependencies. Review release notes regularly to ensure that you apply necessary security fixes.

- **Dependency Scanning:**  
  Use tools such as [OWASP Dependency-Check](https://owasp.org/www-project-dependency-check/) to identify and remediate potential vulnerabilities in your project dependencies.

- **Secure Configuration:**  
  Make sure that configuration files (e.g., `config.json`, `.env`) do not contain sensitive data. Store secrets and sensitive configuration in secure vaults or environment variables.

---

By following these guidelines and installing the specified package versions, you help ensure that your project remains secure, stable, and compliant with our security standards. For further security best practices, refer to our internal security documentation or contact the security team.

---
