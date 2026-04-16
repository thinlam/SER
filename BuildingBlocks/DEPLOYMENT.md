# Deployment Scripts

This directory contains deployment scripts for different environments and platforms.

## deploy.bat
Windows batch script for deploying modules to various environments.

Usage:
```
deploy.bat <Module> [Environment] [DeploymentMode]
```

Parameters:
- Module: DVDC, QLDA, NVTT, QLHD (required)
- Environment: Staging (default), Production
- DeploymentMode: Incremental (default), Full

## deploy.sh
WSL/Linux shell script for deploying modules to various environments.

Usage:
```
./deploy.sh <Module> [Environment] [DeploymentMode]
```

Parameters:
- Module: DVDC, QLDA, NVTT, QLHD (required)
- Environment: Staging (default), Production
- DeploymentMode: Incremental (default), Full

### Differences between Windows and WSL/Linux versions:

1. **Network paths**:
   - Windows uses UNC paths like `\\server\share`
   - WSL/Linux mounts network drives in `/mnt/network/`

2. **File operations**:
   - Windows uses PowerShell/cmd commands
   - Linux uses standard bash commands (rm, cp, rsync)

3. **Permissions**:
   - Unix script requires executable permissions (`chmod +x deploy.sh`)

4. **Configuration management**:
   - Windows uses PowerShell to modify XML
   - Linux uses sed for configuration updates

Both scripts provide equivalent functionality for their respective platforms.