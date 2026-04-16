@echo off
setlocal enabledelayedexpansion

REM ============================================
REM deploy.bat - Unified Module Deployment
REM ============================================
REM
REM Usage: deploy.bat <Module> [Environment] [DeploymentMode]
REM   Module: DVDC, QLDA, NVTT, QLHD (required)
REM   Environment: Staging (default), Production
REM   DeploymentMode: Incremental (default), Full
REM
REM Examples:
REM   deploy.bat DVDC                    - DVDC to Staging
REM   deploy.bat QLHD Staging Full       - QLHD Full deployment
REM   deploy.bat NVTT Production         - NVTT Production build
REM
REM Destinations:
REM   DVDC: \\192.168.1.12\api_mnd\TTCDS\DichVuDungChung
REM   QLDA: \\192.168.1.12\api_mnd\TTCDS\QuanLyDuAn
REM   NVTT: \\192.168.1.12\api_mnd\TTCDS\NhiemVuTrongTam
REM   QLHD: \\192.168.1.12\api_mnd\TTCDS\QuanLyHopDong
REM ============================================

set MODULE=%1
set ENVIRONMENT=%2
set DEPLOYMENT_MODE=%3

REM === Validate Module (Required) ===
if "%MODULE%"=="" (
    echo.
    echo ERROR: Module parameter is required
    echo.
    echo Usage: deploy.bat ^<Module^> [Environment] [DeploymentMode]
    echo   Module: DVDC, QLDA, NVTT, QLHD
    echo   Environment: Staging ^(default^), Production
    echo   DeploymentMode: Incremental ^(default^), Full
    echo.
    pause
    exit /b 1
)

REM === Set Defaults ===
if "%ENVIRONMENT%"=="" set ENVIRONMENT=Staging
if "%DEPLOYMENT_MODE%"=="" set DEPLOYMENT_MODE=Incremental

REM === Set Module Configuration (case-insensitive) ===
if /i "%MODULE%"=="DVDC" (
    set MODULE=DVDC
    set MODULE_NAME=DichVuDungChung
    set WEBAPI_PATH=../DichVuDungChung/SER/DVDC.WebApi/DVDC.WebApi.csproj
    set DESTINATION_PATH=\\192.168.1.12\api_mnd\TTCDS\DichVuDungChung
    goto :module_found
)
if /i "%MODULE%"=="QLDA" (
    set MODULE=QLDA
    set MODULE_NAME=QuanLyDuAn
    set WEBAPI_PATH=../QuanLyDuAn/SER/QLDA.WebApi/QLDA.WebApi.csproj
    set DESTINATION_PATH=\\192.168.1.12\api_mnd\TTCDS\QuanLyDuAn
    goto :module_found
)
if /i "%MODULE%"=="NVTT" (
    set MODULE=NVTT
    set MODULE_NAME=NhiemVuTrongTam
    set WEBAPI_PATH=../NhiemVuTrongTam/SER/NVTT.WebApi/NVTT.WebApi.csproj
    set DESTINATION_PATH=\\192.168.1.12\api_mnd\TTCDS\NhiemVuTrongTam
    goto :module_found
)
if /i "%MODULE%"=="QLHD" (
    set MODULE=QLHD
    set MODULE_NAME=QuanLyHopDong
    set WEBAPI_PATH=modules/QLHD/QLHD.WebApi/QLHD.WebApi.csproj
    set DESTINATION_PATH=\\192.168.1.12\api_mnd\TTCDS\QuanLyHopDong
    goto :module_found
)

echo.
echo ERROR: Invalid module "%MODULE%"
echo.
echo Valid modules: DVDC, QLDA, NVTT, QLHD
echo.
pause
exit /b 1

:module_found

REM === Validate Environment ===
if /i not "%ENVIRONMENT%"=="Staging" if /i not "%ENVIRONMENT%"=="Production" (
    echo.
    echo ERROR: Invalid environment "%ENVIRONMENT%"
    echo.
    pause
    exit /b 1
)

REM === Validate DeploymentMode ===
if /i not "%DEPLOYMENT_MODE%"=="Incremental" if /i not "%DEPLOYMENT_MODE%"=="Full" (
    echo.
    echo ERROR: Invalid deployment mode "%DEPLOYMENT_MODE%"
    echo.
    pause
    exit /b 1
)

REM === Adjust Production Destination ===
if /i "%ENVIRONMENT%"=="Production" set DESTINATION_PATH=%DESTINATION_PATH%\Production

REM === Display Deployment Info ===
echo.
echo ============================================
echo   %MODULE% (%MODULE_NAME%) DEPLOYMENT
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
echo Publishing %MODULE%.WebApi...
set PUBLISH_PATH=%~dp0bin\Release\net8.0\publish\%MODULE%

dotnet publish %WEBAPI_PATH% --configuration Release --output ./bin/Release/net8.0/publish/%MODULE%

if %ERRORLEVEL% NEQ 0 (
    echo Publish failed with error code %ERRORLEVEL%.
    pause
    exit /b %ERRORLEVEL%
)

REM === Cleanup Publish Folder ===
echo Cleaning up publish folder...

if exist "%PUBLISH_PATH%\appsettings.Development.json" del /q "%PUBLISH_PATH%\appsettings.Development.json"

if /i "%ENVIRONMENT%"=="Staging" (
    if exist "%PUBLISH_PATH%\appsettings.Production.json" del /q "%PUBLISH_PATH%\appsettings.Production.json"
)
if /i "%ENVIRONMENT%"=="Production" (
    if exist "%PUBLISH_PATH%\appsettings.Staging.json" del /q "%PUBLISH_PATH%\appsettings.Staging.json"
)

del /q "%PUBLISH_PATH%\.env*" 2>nul
del /q "%PUBLISH_PATH%\*.md" 2>nul

for %%f in (Deploy.bat deploy.bat DeployScript.ps1 makefile Dockerfile .dockerignore) do (
    if exist "%PUBLISH_PATH%\%%f" del /q "%PUBLISH_PATH%\%%f"
)

for %%d in (.claude plans docs logs Tests) do (
    if exist "%PUBLISH_PATH%\%%d" rmdir /s /q "%PUBLISH_PATH%\%%d"
)

del /q "%PUBLISH_PATH%\%MODULE%.*.Tests.*" 2>nul
del /q "%PUBLISH_PATH%\*Tests*.dll" 2>nul
del /q "%PUBLISH_PATH%\*Tests*.json" 2>nul
del /q "%PUBLISH_PATH%\Moq.dll" 2>nul
del /q "%PUBLISH_PATH%\xunit*.dll" 2>nul
del /q "%PUBLISH_PATH%\coverlet*.dll" 2>nul
del /q "%PUBLISH_PATH%\Microsoft.NET.Test*.dll" 2>nul

REM === Remove non-English localization folders ===
echo Removing non-English localization folders...
powershell.exe -ExecutionPolicy Bypass -Command "Get-ChildItem -Path '%PUBLISH_PATH%' -Directory | Where-Object { $_.Name -match '^[a-z]{2}(-[A-Za-z]+)?$' -and $_.Name -notmatch '^en(-US)?$' } | ForEach-Object { Remove-Item -Path $_.FullName -Recurse -Force; Write-Host \"Removed: $($_.Name)\" }"

echo Cleanup completed.

REM === Update web.config ===
if exist "%PUBLISH_PATH%\web.config" (
    echo Setting ASPNETCORE_ENVIRONMENT to %ENVIRONMENT%...
    powershell.exe -ExecutionPolicy Bypass -Command "[xml]$x=Get-Content '%PUBLISH_PATH%\web.config'; $ev=$x.SelectSingleNode('//environmentVariable[@name=\"ASPNETCORE_ENVIRONMENT\"]'); if($ev){$ev.SetAttribute('value','%ENVIRONMENT%')}; $x.Save('%PUBLISH_PATH%\web.config'); Write-Host 'web.config updated'"
)

REM === Deploy ===
if /i "%ENVIRONMENT%"=="Production" (
    echo.
    echo ============================================
    echo   %MODULE% PRODUCTION BUILD COMPLETE
    echo ============================================
    echo   Build artifacts: %PUBLISH_PATH%
    echo ============================================
) else (
    echo Copying files to server...
    powershell.exe -ExecutionPolicy Bypass -File "%~dp0DeployScript.ps1" -SourcePath "%PUBLISH_PATH%" -DestinationPath "%DESTINATION_PATH%" -DeploymentMode %DEPLOYMENT_MODE%

    if %ERRORLEVEL% EQU 0 (
        echo.
        echo ============================================
        echo   %MODULE% DEPLOYMENT SUCCESSFUL
        echo ============================================
        echo   Destination: %DESTINATION_PATH%
        echo ============================================
    ) else (
        echo Deployment failed with error code %ERRORLEVEL%.
    )
)

pause