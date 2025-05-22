# .NET MAUI Android Setup Guide

Set up Android development for .NET MAUI using Visual Studio and CLI.

---

## Enable Android Support in Visual Studio

1. Open the **Visual Studio Installer**.
2. Click **Modify** on your installed version.
3. Make sure the **"Mobile development with .NET"** workload is selected.
4. Click **Modify** to install missing components (Android SDK, Emulator, etc.).

---

Open a terminal or PowerShell and run:

```bash
dotnet workload install maui
dotnet workload install maui-android
```

last step check image
