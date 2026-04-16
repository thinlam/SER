# Deployment Guide

Module deployment pipeline for BuildingBlocks ecosystem.

## Deployment Scripts

| Script | Platform | Description |
|--------|----------|-------------|
| `deploy.bat` | Windows CMD | Native Windows deployment |
| `deploy.sh` | WSL/Linux | Build in WSL, copy via Windows PowerShell |
| `DeployScript.ps1` | PowerShell | Zero-downtime file copy with app_offline.htm |

## Quick Start

### Windows (CMD)

```cmd
deploy.bat <Module> [Environment] [DeploymentMode]
```

### WSL / Linux

```bash
./deploy.sh <Module> [Environment] [DeploymentMode]
```

### Parameters

| Parameter | Required | Values | Default |
|-----------|----------|--------|---------|
| Module | Yes | `DVDC`, `QLDA`, `NVTT`, `QLHD` | - |
| Environment | No | `Staging`, `Production` | `Staging` |
| DeploymentMode | No | `Incremental`, `Full` | `Incremental` |

### Examples

```bash
# Deploy DVDC to Staging (incremental)
./deploy.sh DVDC

# Full deploy QLHD to Staging
./deploy.sh QLHD Staging Full

# Build NVTT for Production (no server copy)
./deploy.sh NVTT Production
```

## Architecture: How deploy.sh Works in WSL

WSL2 runs inside a Hyper-V virtual machine with its own network stack. VPN connections on the Windows host are **not** automatically available to WSL2. This means:

- Windows host can access `\\192.168.1.12\...` (via VPN)
- WSL2 **cannot** directly access UNC paths or the VPN network

### Solution: Hybrid Approach

```
┌─────────────────────────────────────────────┐
│  WSL2 (deploy.sh)                           │
│                                             │
│  1. dotnet publish ──► bin/Release/.../publish │
│  2. Cleanup publish folder                  │
│  3. Update web.config                       │
│  4. Call powershell.exe ──────────────────┐ │
│                                          │  │
└──────────────────────────────────────────┼──┘
                                           │
┌──────────────────────────────────────────┼──┐
│  Windows Host (via powershell.exe)       ▼  │
│                                             │
│  5. DeployScript.ps1                        │
│     - Uses Windows network stack (VPN OK)   │
│     - Copy to \\192.168.1.12\api_mnd\...    │
│     - Zero-downtime via app_offline.htm     │
└─────────────────────────────────────────────┘
```

**Key:** `dotnet publish` runs in WSL (fast), file copy delegates to `powershell.exe` which uses Windows network stack (has VPN route).

### WSL Path Conversion

`deploy.sh` uses `wslpath -w` to convert Linux paths to Windows paths before calling PowerShell:

```bash
# WSL path → Windows path
WIN_PUBLISH_PATH=$(wslpath -w "$PUBLISH_PATH")
# /home/user/.../publish → \\wsl$\Ubuntu\home\user\.../publish
```

## Deployment Modes

### Incremental (Default)

- Copies only files modified today
- Excludes `web.config` and `PrintTemplates/`
- Does **not** take app offline
- Safe for active users

### Full

- Mirrors entire publish folder to destination
- Includes `web.config` and `PrintTemplates/`
- Creates backup before deploying
- Uses `app_offline.htm` for zero-downtime
- Best for major updates

## Server Destinations

| Module | UNC Path |
|--------|----------|
| DVDC | `\\192.168.1.12\api_mnd\TTCDS\DichVuDungChung` |
| QLDA | `\\192.168.1.12\api_mnd\TTCDS\QuanLyDuAn` |
| NVTT | `\\192.168.1.12\api_mnd\TTCDS\NhiemVuTrongTam` |
| QLHD | `\\192.168.1.12\api_mnd\TTCDS\QuanLyHopDong` |

Production builds append `\Production` to the path and skip server deployment.

## Publish Folder Cleanup

After `dotnet publish`, the script removes:

| Category | Items |
|----------|-------|
| Config | `appsettings.Development.json`, non-target env configs |
| Secrets | `.env*` files |
| Docs | `*.md` files |
| Dev dirs | `.claude/`, `plans/`, `docs/`, `logs/`, `Tests/` |
| Deploy scripts | `Deploy.bat`, `deploy.sh`, `DeployScript.ps1`, `Dockerfile`, etc. |
| Test files | `*Tests*.dll`, `Moq.dll`, `xunit*.dll`, `coverlet*.dll` |
| Localization | Non-English folders (`vi`, `fr`, `de`, etc.) |

## Troubleshooting

### WSL: "No route to host"

WSL2 cannot reach the VPN network. Solution: use `deploy.sh` (calls `powershell.exe` internally) instead of trying to mount SMB shares in WSL.

### WSL: "Permission denied" on UNC path

Linux cannot create UNC paths (`//192.168.1.12/...`). The `deploy.sh` script handles this by delegating to `powershell.exe`. Do **not** change `DESTINATION_UNC` to a Linux path.

### WSL: powershell.exe not found

Ensure WSL interop is enabled:

```bash
# Check interop
cat /proc/sys/fs/binfmt_misc/WSLInterop

# Enable if disabled
echo 1 | sudo tee /proc/sys/fs/binfmt_misc/WSLInterop
```

### Windows: "Access denied" on network share

Verify VPN connection and network share credentials:

```cmd
net use \\192.168.1.12\api_mnd /user:update
```
