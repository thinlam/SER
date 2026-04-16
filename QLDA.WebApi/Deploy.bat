@echo off
setlocal enabledelayedexpansion

REM ============================================
REM Deploy.bat - Environment-Based Deployment
REM ============================================
REM
REM Usage: Deploy.bat [Environment] [DeploymentMode]
REM   Environment: Staging (default), Production
REM   DeploymentMode: Incremental (default), Full
REM
REM Examples:
REM   Deploy.bat                     - Staging + Incremental (deploy to server)
REM   Deploy.bat Staging             - Staging + Incremental (deploy to server)
REM   Deploy.bat Staging Full        - Staging + Full deployment (deploy to server)
REM   Deploy.bat Production          - Production build only (no deploy)
REM
REM Destinations:
REM   Staging:    \\App01\API_MND\TTCDS\QuanLyDuAn
REM   Production: Build only (no server deploy)
REM ============================================

REM === Parse Arguments ===
set ENVIRONMENT=%1
set DEPLOYMENT_MODE=%2

REM === Set Defaults ===
if "%ENVIRONMENT%"=="" set ENVIRONMENT=Staging
if "%DEPLOYMENT_MODE%"=="" set DEPLOYMENT_MODE=Incremental

REM === Validate Environment ===
if /i not "%ENVIRONMENT%"=="Staging" if /i not "%ENVIRONMENT%"=="Production" (
    echo.
    echo ERROR: Invalid environment "%ENVIRONMENT%"
    echo.
    echo Usage: Deploy.bat [Environment] [DeploymentMode]
    echo   Environment: Staging, Production
    echo   DeploymentMode: Incremental, Full
    echo.
    pause
    exit /b 1
)

REM === Validate DeploymentMode ===
if /i not "%DEPLOYMENT_MODE%"=="Incremental" if /i not "%DEPLOYMENT_MODE%"=="Full" (
    echo.
    echo ERROR: Invalid deployment mode "%DEPLOYMENT_MODE%"
    echo.
    echo Usage: Deploy.bat [Environment] [DeploymentMode]
    echo   DeploymentMode: Incremental, Full
    echo.
    pause
    exit /b 1
)

REM === Set Destination Path Based on Environment ===
if /i "%ENVIRONMENT%"=="Staging" (
    set DESTINATION_PATH=\\App01\API_MND\TTCDS\QuanLyDuAn
)
if /i "%ENVIRONMENT%"=="Production" (
    set DESTINATION_PATH=
)

REM === Display Deployment Info ===
echo.
echo ============================================
echo   DEPLOYMENT CONFIGURATION
echo ============================================
echo   Environment    : %ENVIRONMENT%
echo   Deployment Mode: %DEPLOYMENT_MODE%
if /i "%ENVIRONMENT%"=="Production" (
    echo   Destination    : Build Only ^(no server deploy^)
) else (
    echo   Destination    : %DESTINATION_PATH%
)
echo ============================================
echo.

REM === Build Project ===
echo Publishing project...

set PUBLISH_PATH=%~dp0bin\Release\net8.0\publish

dotnet publish QLDA.WebApi.csproj --configuration Release --output ./bin/Release/net8.0/publish

if %ERRORLEVEL% NEQ 0 (
    echo Publish failed with error code %ERRORLEVEL%.
    pause
    exit /b %ERRORLEVEL%
)

REM === Cleanup Publish Folder ===
echo Cleaning up publish folder...

REM Remove development config (always)
if exist "%PUBLISH_PATH%\appsettings.Development.json" del /q "%PUBLISH_PATH%\appsettings.Development.json"

REM Remove config based on target environment
if /i "%ENVIRONMENT%"=="Staging" (
    REM Deploying to Staging: remove Production config, keep Staging
    if exist "%PUBLISH_PATH%\appsettings.Production.json" del /q "%PUBLISH_PATH%\appsettings.Production.json"
)
if /i "%ENVIRONMENT%"=="Production" (
    REM Deploying to Production: remove Staging config, keep Production
    if exist "%PUBLISH_PATH%\appsettings.Staging.json" del /q "%PUBLISH_PATH%\appsettings.Staging.json"
)

REM Remove env files
del /q "%PUBLISH_PATH%\.env*" 2>nul

REM Remove markdown files
del /q "%PUBLISH_PATH%\*.md" 2>nul

REM Remove deployment scripts
if exist "%PUBLISH_PATH%\Deploy.bat" del /q "%PUBLISH_PATH%\Deploy.bat"
if exist "%PUBLISH_PATH%\DeployScript.ps1" del /q "%PUBLISH_PATH%\DeployScript.ps1"
if exist "%PUBLISH_PATH%\makefile" del /q "%PUBLISH_PATH%\makefile"
if exist "%PUBLISH_PATH%\Dockerfile" del /q "%PUBLISH_PATH%\Dockerfile"
if exist "%PUBLISH_PATH%\.dockerignore" del /q "%PUBLISH_PATH%\.dockerignore"

REM Remove development folders
if exist "%PUBLISH_PATH%\.claude" rmdir /s /q "%PUBLISH_PATH%\.claude"
if exist "%PUBLISH_PATH%\plans" rmdir /s /q "%PUBLISH_PATH%\plans"
if exist "%PUBLISH_PATH%\docs" rmdir /s /q "%PUBLISH_PATH%\docs"
if exist "%PUBLISH_PATH%\logs" rmdir /s /q "%PUBLISH_PATH%\logs"
if exist "%PUBLISH_PATH%\Tests" rmdir /s /q "%PUBLISH_PATH%\Tests"

REM Remove Tests project artifacts
del /q "%PUBLISH_PATH%\QLDA.*.Tests.*" 2>nul
del /q "%PUBLISH_PATH%\*Tests*.dll" 2>nul
del /q "%PUBLISH_PATH%\*Tests*.json" 2>nul
del /q "%PUBLISH_PATH%\Moq.dll" 2>nul
del /q "%PUBLISH_PATH%\xunit*.dll" 2>nul
del /q "%PUBLISH_PATH%\coverlet*.dll" 2>nul
del /q "%PUBLISH_PATH%\Microsoft.NET.Test*.dll" 2>nul

REM Remove debug symbols (optional - uncomment if needed)
REM del /q "%PUBLISH_PATH%\*.pdb" 2>nul

echo Cleanup completed.

REM === Deploy Based on Environment ===
if /i "%ENVIRONMENT%"=="Production" (
    echo.
    echo ============================================
    echo   PRODUCTION BUILD COMPLETE
    echo ============================================
    echo   Build artifacts available at:
    echo   %PUBLISH_PATH%
    echo.
    echo   NOTE: Production deployment requires manual
    echo   copy or CI/CD pipeline to deploy to server.
    echo ============================================
) else (
    echo Copying files to server...
    powershell.exe -ExecutionPolicy Bypass -File "%~dp0DeployScript.ps1" -SourcePath "%PUBLISH_PATH%" -DestinationPath "%DESTINATION_PATH%" -DeploymentMode %DEPLOYMENT_MODE%

    if %ERRORLEVEL% EQU 0 (
        echo.
        echo ============================================
        echo   DEPLOYMENT COMPLETED SUCCESSFULLY
        echo ============================================
        echo   Environment: %ENVIRONMENT%
        echo   Mode: %DEPLOYMENT_MODE%
        echo   Destination: %DESTINATION_PATH%
        echo ============================================
    ) else (
        echo Deployment failed with error code %ERRORLEVEL%.
    )
)

pause
