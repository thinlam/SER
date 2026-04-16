@echo off
setlocal enabledelayedexpansion

REM ============================================
REM run.bat - Run Module WebApi (with hot reload)
REM ============================================
REM
REM Usage: run.bat <Module>
REM   Module: DVDC, QLDA, NVTT, QLHD (required)
REM
REM Examples:
REM   run.bat QLHD - Run QLHD.WebApi with watch
REM   run.bat DVDC - Run DVDC.WebApi with watch
REM
REM Note: Schema is configured in appsettings.json
REM ============================================

set MODULE=%1

REM === Set ASPNETCORE_ENVIRONMENT ===
if not defined ASPNETCORE_ENVIRONMENT set ASPNETCORE_ENVIRONMENT=Development

REM === Validate Module ===
if "%MODULE%"=="" (
    echo.
    echo ERROR: Module parameter is required
    echo.
    echo Usage: run.bat ^<Module^>
    echo   Module: DVDC, QLDA, NVTT, QLHD
    echo.
    pause
    exit /b 1
)

REM === Set Module Paths (case-insensitive) ===
if /i "%MODULE%"=="DVDC" (
    set MODULE=DVDC
    set WEBAPI_PATH=../DichVuDungChung/SER/DVDC.WebApi/DVDC.WebApi.csproj
    goto :module_found
)
if /i "%MODULE%"=="QLDA" (
    set MODULE=QLDA
    set WEBAPI_PATH=../QuanLyDuAn/SER/QLDA.WebApi/QLDA.WebApi.csproj
    goto :module_found
)
if /i "%MODULE%"=="NVTT" (
    set MODULE=NVTT
    set WEBAPI_PATH=../NhiemVuTrongTam/SER/NVTT.WebApi/NVTT.WebApi.csproj
    goto :module_found
)
if /i "%MODULE%"=="QLHD" (
    set MODULE=QLHD
    set WEBAPI_PATH=modules/QLHD/QLHD.WebApi/QLHD.WebApi.csproj
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

echo.
echo ============================================
echo   %MODULE% WebApi - Running with Watch
echo ============================================
echo   Project: %WEBAPI_PATH%
echo ============================================
echo.

dotnet watch --project %WEBAPI_PATH%

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo ============================================
    echo   RUN FAILED
    echo ============================================
    echo   Error code: %ERRORLEVEL%
    echo.
    pause
)
