<#
.SYNOPSIS
    Deploys application files to a network destination with zero-downtime support.

.DESCRIPTION
    This script implements a robust deployment process that:
    - Uses app_offline.htm for zero-downtime deployment
    - Supports incremental or full deployment modes
    - Full mode: creates backup, includes PrintTemplates and web.config
    - Includes comprehensive error handling and logging
    - Validates paths and permissions
    - Provides dry-run capability

.PARAMETER SourcePath
    Path to the source directory containing files to deploy. Mandatory.

.PARAMETER DestinationPath
    Network path to the destination directory. Mandatory.

.PARAMETER LogPath
    Path to the log file. If not specified, logs to console only.

.PARAMETER ExcludePatterns
    Array of patterns to exclude from deployment. Default: @("*.pdb", "*.env")
    Note: In Incremental mode, web.config and PrintTemplates are also excluded.

.PARAMETER DeploymentMode
    Deployment mode: "Incremental" (default) or "Full".
    - Incremental: copies only today's modified files, excludes web.config and PrintTemplates
    - Full: creates backup, copies all files including web.config and PrintTemplates

.PARAMETER WhatIf
    Preview mode - shows what would be done without making changes.

.PARAMETER ProjectPath
    Path to the .NET project or solution to publish. If specified, runs dotnet publish before deployment.

.EXAMPLE
    .\DeployScript.ps1 -SourcePath "C:\Build\Output" -DestinationPath "\\Server\Share\App"

.EXAMPLE
    .\DeployScript.ps1 -SourcePath "C:\Build\Output" -DestinationPath "\\Server\Share\App" -DeploymentMode Full -WhatIf

.EXAMPLE
    .\DeployScript.ps1 -ProjectPath "C:\Project\WebApi" -DestinationPath "\\Server\Share\App"
#>

param(
    [Parameter(Mandatory = $true, ParameterSetName = "FromSource")]
    [string]$SourcePath,

    [Parameter(Mandatory = $true)]
    [string]$DestinationPath,

    [string]$LogPath,

    [string[]]$ExcludePatterns = @("*.pdb", "*.env"),

    [ValidateSet("Incremental", "Full")]
    [string]$DeploymentMode = "Incremental",

    [switch]$WhatIf,

    [Parameter(Mandatory = $true, ParameterSetName = "FromProject")]
    [string]$ProjectPath
)

# Function to write log messages
function Write-Log {
    param(
        [string]$Message,
        [string]$Level = "INFO"
    )

    $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    $logMessage = "[$timestamp] [$Level] $Message"

    if ($LogPath) {
        Add-Content -Path $LogPath -Value $logMessage
    }

    Write-Host $logMessage
}

# Function to publish project
function Publish-Project {
    param([string]$ProjectPath)

    Write-Log "Publishing project from: $ProjectPath"

    $publishOutput = Join-Path $ProjectPath "bin/Release/net8.0/publish"

    if ($WhatIf) {
        Write-Log "WHATIF: Would run dotnet publish -c Release -o $publishOutput"
        return $publishOutput
    }

    try {
        $result = Start-Process -FilePath "dotnet" -ArgumentList "publish", "-c", "Release", "-o", $publishOutput -Wait -NoNewWindow -PassThru
        if ($result.ExitCode -ne 0) {
            throw "dotnet publish failed with exit code $($result.ExitCode)"
        }
        Write-Log "Project published successfully to: $publishOutput"
        return $publishOutput
    }
    catch {
        Write-Log "Failed to publish project: $_" "ERROR"
        throw
    }
}

# Function to validate paths
function Test-Paths {
    Write-Log "Validating paths..."

    if (!(Test-Path $SourcePath)) {
        throw "Source path does not exist: $SourcePath"
    }

    if (!(Test-Path $DestinationPath)) {
        throw "Destination path does not exist: $DestinationPath"
    }

    # Test write access to destination
    try {
        $testFile = Join-Path $DestinationPath "deploy_test.tmp"
        New-Item -ItemType File -Path $testFile -Force | Out-Null
        Remove-Item $testFile -Force
    }
    catch {
        throw "No write access to destination: $DestinationPath"
    }

    Write-Log "Path validation completed."
}

# Function to create backup for Full deployment
function New-Backup {
    Write-Log "Creating backup before Full deployment..."

    $timestamp = Get-Date -Format "yyyyMMdd_HHmmss"
    $backupFolderName = "backup_$timestamp"
    $backupRoot = Join-Path $DestinationPath "backup"
    $backupPath = Join-Path $backupRoot $backupFolderName

    if ($WhatIf) {
        Write-Log "WHATIF: Would create backup at $backupPath"
        return $backupPath
    }

    try {
        # Create backup folder
        New-Item -ItemType Directory -Path $backupPath -Force | Out-Null

        # Copy critical files to backup
        $itemsToBackup = @("web.config", "PrintTemplates", "appsettings.json", "appsettings.Production.json", "appsettings.Staging.json")

        foreach ($item in $itemsToBackup) {
            $sourcePath = Join-Path $DestinationPath $item
            if (Test-Path $sourcePath) {
                $destPath = Join-Path $backupPath $item
                Copy-Item -Path $sourcePath -Destination $destPath -Recurse -Force
                Write-Log "Backed up: $item"
            }
        }

        Write-Log "Backup created at: $backupPath"
        return $backupPath
    }
    catch {
        Write-Log "Failed to create backup: $_" "WARNING"
        return $null
    }
}

# Function to get files to deploy
function Get-FilesToDeploy {
    Write-Log "Getting files to deploy (Mode: $DeploymentMode)..."

    $allFiles = Get-ChildItem -Path $SourcePath -File -Recurse

    # Build exclusion patterns based on mode
    $effectiveExclusions = $ExcludePatterns.Clone()

    if ($DeploymentMode -eq "Incremental") {
        # In Incremental mode, also exclude web.config and PrintTemplates
        $effectiveExclusions += "web.config"
        $effectiveExclusions += "*PrintTemplates*"
    }

    # Apply exclusions
    $filesToDeploy = $allFiles | Where-Object {
        $include = $true
        foreach ($pattern in $effectiveExclusions) {
            if ($_.Name -like $pattern -or $_.FullName -like $pattern) {
                $include = $false
                break
            }
        }
        $include
    }

    if ($DeploymentMode -eq "Incremental") {
        $today = (Get-Date).Date
        $filesToDeploy = $filesToDeploy | Where-Object { $_.LastWriteTime.Date -eq $today }
        Write-Log "Found $($filesToDeploy.Count) files modified today."
    }
    else {
        Write-Log "Found $($filesToDeploy.Count) files to deploy (full mode - includes web.config and PrintTemplates)."
    }

    return $filesToDeploy
}

# Function to perform deployment
function Invoke-Deployment {
    param([array]$Files)

    Write-Log "Starting deployment..."

    $baseDestination = $DestinationPath
    $appOfflineUnderscore = Join-Path $baseDestination "app_offline_.htm"
    $appOffline = Join-Path $baseDestination "app_offline.htm"

    # Step 0: Create backup for Full deployment
    if ($DeploymentMode -eq "Full") {
        $backupPath = New-Backup
        if ($backupPath) {
            Write-Log "Backup location: $backupPath"
        }
    }

    # Step 1: Take app offline
    if (Test-Path $appOfflineUnderscore) {
        if ($WhatIf) {
            Write-Log "WHATIF: Would rename $appOfflineUnderscore to $appOffline"
        }
        else {
            try {
                Rename-Item -Path $appOfflineUnderscore -NewName "app_offline.htm"
                Write-Log "Application taken offline."
                # Wait for IIS to unload the application domain
                Write-Log "Waiting for a seconds for application to fully unload..."
                Start-Sleep -Seconds 3
            }
            catch {
                Write-Log "Failed to take application offline: $_" "ERROR"
                throw
            }
        }
    }
    else {
        # Create app_offline.htm if it doesn't exist
        Write-Log "app_offline_.htm not found. Creating app_offline.htm to take app offline..."
        if (-not $WhatIf) {
            $offlineContent = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Server Offline</title>
</head>
<body>
    <h1>Server Already Offline</h1>
    <p>The application is currently being updated. Please try again in a few moments.</p>
</body>
</html>
"@
            Set-Content -Path $appOffline -Value $offlineContent -Encoding UTF8
            Write-Log "Created app_offline.htm. Application taken offline."
            Start-Sleep -Seconds 3
        }
    }

    # Step 2: Copy files
    if ($Files.Count -gt 0) {
        if ($DeploymentMode -eq "Incremental") {
            # For incremental, use PowerShell copy
            Write-Log "Using PowerShell copy for incremental deployment..."
            foreach ($file in $Files) {
                $relativePath = $file.FullName.Substring($SourcePath.Length + 1)
                $destinationFilePath = Join-Path $baseDestination $relativePath
                $destinationDir = Split-Path $destinationFilePath -Parent

                if ($WhatIf) {
                    Write-Log "WHATIF: Would copy $($file.FullName) to $destinationFilePath"
                }
                else {
                    $maxRetries = 3
                    $retryCount = 0
                    $success = $false

                    while ($retryCount -lt $maxRetries -and -not $success) {
                        try {
                            if (Test-Path $destinationDir) {
                                $item = Get-Item $destinationDir
                                if (-not $item.PSIsContainer) {
                                    throw "Cannot create directory $destinationDir because a file with that name already exists."
                                }
                            }
                            else {
                                New-Item -ItemType Directory -Path $destinationDir -Force | Out-Null
                            }
                            Copy-Item -Path $file.FullName -Destination $destinationFilePath -Force
                            Write-Log "Copied $($file.Name) to $destinationFilePath"
                            $success = $true
                        }
                        catch {
                            $retryCount++
                            if ($retryCount -lt $maxRetries) {
                                Write-Log "Failed to copy $($file.Name) (attempt $retryCount): $_. Waiting before retry..." "WARNING"
                                Start-Sleep -Seconds 3
                            }
                            else {
                                Write-Log "Failed to copy $($file.Name) after $maxRetries attempts: $_" "ERROR"
                                throw
                            }
                        }
                    }
                }
            }
        }
        else {
            # For full deployment, use Robocopy (no exclusions for web.config/PrintTemplates)
            $robocopyArgs = @(
                $SourcePath,
                $DestinationPath,
                "/MIR",  # Mirror directory tree
                "/NJH",  # No job header
                "/NJS",  # No job summary
                "/NP",   # No progress
                "/R:3",  # Retry 3 times
                "/W:1",  # Wait 1 second between retries
                "/XD",   # Exclude directories
                "backup" # Exclude backup folder from being purged
            )

            # Only exclude *.pdb and *.env in Full mode
            foreach ($pattern in $ExcludePatterns) {
                $robocopyArgs += "/XF"
                $robocopyArgs += $pattern
            }

            if ($WhatIf) {
                Write-Log "WHATIF: Would run Robocopy with args: $($robocopyArgs -join ' ')"
            }
            else {
                try {
                    $result = Start-Process -FilePath "robocopy.exe" -ArgumentList $robocopyArgs -Wait -NoNewWindow -PassThru
                    if ($result.ExitCode -gt 7) {
                        throw "Robocopy failed with exit code $($result.ExitCode)"
                    }
                    Write-Log "Files copied successfully using Robocopy."
                }
                catch {
                    Write-Log "Failed to copy files: $_" "ERROR"
                    throw
                }
            }
        }
    }
    else {
        Write-Log "No files to deploy."
    }

    # Step 3: Bring app back online
    if (Test-Path $appOffline) {
        if ($WhatIf) {
            Write-Log "WHATIF: Would rename $appOffline back to app_offline_.htm"
        }
        else {
            try {
                Rename-Item -Path $appOffline -NewName "app_offline_.htm"
                Write-Log "Application brought back online."
            }
            catch {
                Write-Log "Failed to bring application online: $_" "ERROR"
                throw
            }
        }
    }
    else {
        Write-Log "Warning: app_offline.htm not found. Application should already be online."
    }

    Write-Log "Deployment completed successfully."
}

# Main execution
try {
    Write-Log "=== Deployment Script Started ==="

    if ($WhatIf) {
        Write-Log "Running in WHATIF mode - no changes will be made."
    }

    # If ProjectPath is specified, publish the project first
    if ($ProjectPath) {
        $script:SourcePath = Publish-Project -ProjectPath $ProjectPath
    }

    Test-Paths
    $files = Get-FilesToDeploy
    Invoke-Deployment -Files $files

    Write-Log "=== Deployment Script Completed ==="
}
catch {
    Write-Log "Deployment failed: $_" "ERROR"

    # Rollback: Bring app back online if it was taken offline
    $appOffline = Join-Path $DestinationPath "app_offline.htm"
    if (Test-Path $appOffline) {
        try {
            Rename-Item -Path $appOffline -NewName "app_offline_.htm"
            Write-Log "Application brought back online after deployment failure."
            Start-Sleep -Seconds 3
        }
        catch {
            Write-Log "Failed to bring application back online: $_" "ERROR"
        }
    }

    Write-Log "=== Deployment Script Failed ==="
    exit 1
}
