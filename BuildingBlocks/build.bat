@echo off
setlocal

:: Build script for BuildingBlocks solution
:: Usage:
::   build.bat           - Build entire solution
::   build.bat QLHD      - Build BuildingBlocks + QLHD module only
::   build.bat DVDC      - Build BuildingBlocks + DVDC module only
::   build.bat QLDA      - Build BuildingBlocks + QLDA module only
::   build.bat NVTT      - Build BuildingBlocks + NVTT module only
::   build.bat BB        - Build BuildingBlocks core only
::   build.bat clean     - Clean build output
::   build.bat -c Release - Build in Release mode (default: Debug)

set "CONFIG=Debug"
set "MODULE="
set "CLEAN=0"

:: Parse arguments
:parse_args
if "%~1"=="" goto :end_parse
if /i "%~1"=="-c" (
    set "CONFIG=%~2"
    shift
    shift
    goto :parse_args
)
if /i "%~1"=="--config" (
    set "CONFIG=%~2"
    shift
    shift
    goto :parse_args
)
if /i "%~1"=="clean" (
    set "CLEAN=1"
    shift
    goto :parse_args
)
set "MODULE=%~1"
shift
goto :parse_args
:end_parse

echo.
echo ============================================
echo BuildingBlocks Build Script
echo ============================================
echo Configuration: %CONFIG%
echo.

:: Clean if requested
if "%CLEAN%"=="1" (
    echo Cleaning solution...
    dotnet clean BuildingBlocks.sln -c %CONFIG% -v q
    echo Clean complete.
    exit /b 0
)

:: Build based on module selection
if "%MODULE%"=="" (
    :: Build entire solution
    echo Building entire solution...
    dotnet build BuildingBlocks.sln -c %CONFIG%
    goto :done
)

if /i "%MODULE%"=="BB" (
    :: Build only BuildingBlocks core
    echo Building BuildingBlocks core only...
    dotnet build src\BuildingBlocks.CrossCutting\BuildingBlocks.CrossCutting.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build src\BuildingBlocks.Domain\BuildingBlocks.Domain.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build src\BuildingBlocks.Persistence\BuildingBlocks.Persistence.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build src\BuildingBlocks.Application\BuildingBlocks.Application.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build src\BuildingBlocks.Infrastructure\BuildingBlocks.Infrastructure.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    goto :done
)

:: Build BuildingBlocks core + specific module
echo Building BuildingBlocks core + %MODULE% module...

:: First build BuildingBlocks core (dependency)
echo.
echo [1/2] Building BuildingBlocks core...
dotnet build src\BuildingBlocks.CrossCutting\BuildingBlocks.CrossCutting.csproj -c %CONFIG% -v q
if errorlevel 1 goto :fail
dotnet build src\BuildingBlocks.Domain\BuildingBlocks.Domain.csproj -c %CONFIG% -v q
if errorlevel 1 goto :fail
dotnet build src\BuildingBlocks.Persistence\BuildingBlocks.Persistence.csproj -c %CONFIG% -v q
if errorlevel 1 goto :fail
dotnet build src\BuildingBlocks.Application\BuildingBlocks.Application.csproj -c %CONFIG% -v q
if errorlevel 1 goto :fail
dotnet build src\BuildingBlocks.Infrastructure\BuildingBlocks.Infrastructure.csproj -c %CONFIG% -v q
if errorlevel 1 goto :fail

echo.
echo [2/2] Building %MODULE% module...

if /i "%MODULE%"=="QLHD" (
    dotnet build modules\QLHD\QLHD.Domain\QLHD.Domain.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build modules\QLHD\QLHD.Persistence\QLHD.Persistence.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build modules\QLHD\QLHD.Application\QLHD.Application.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build modules\QLHD\QLHD.Infrastructure\QLHD.Infrastructure.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build modules\QLHD\QLHD.WebApi\QLHD.WebApi.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build modules\QLHD\QLHD.Migrator\QLHD.Migrator.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    goto :done
)

if /i "%MODULE%"=="DVDC" (
    dotnet build ..\DichVuDungChung\SER\DVDC.Domain\DVDC.Domain.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\DichVuDungChung\SER\DVDC.Persistence\DVDC.Persistence.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\DichVuDungChung\SER\DVDC.Application\DVDC.Application.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\DichVuDungChung\SER\DVDC.Infrastructure\DVDC.Infrastructure.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\DichVuDungChung\SER\DVDC.WebApi\DVDC.WebApi.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\DichVuDungChung\SER\DVDC.Migrator\DVDC.Migrator.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    goto :done
)

if /i "%MODULE%"=="QLDA" (
    dotnet build ..\QuanLyDuAn\SER\QLDA.Domain\QLDA.Domain.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\QuanLyDuAn\SER\QLDA.Persistence\QLDA.Persistence.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\QuanLyDuAn\SER\QLDA.Application\QLDA.Application.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\QuanLyDuAn\SER\QLDA.Infrastructure\QLDA.Infrastructure.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\QuanLyDuAn\SER\QLDA.WebApi\QLDA.WebApi.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\QuanLyDuAn\SER\QLDA.Migrator\QLDA.Migrator.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    goto :done
)

if /i "%MODULE%"=="NVTT" (
    dotnet build ..\NhiemVuTrongTam\SER\NVTT.Domain\NVTT.Domain.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\NhiemVuTrongTam\SER\NVTT.Persistence\NVTT.Persistence.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\NhiemVuTrongTam\SER\NVTT.Application\NVTT.Application.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\NhiemVuTrongTam\SER\NVTT.Infrastructure\NVTT.Infrastructure.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\NhiemVuTrongTam\SER\NVTT.WebApi\NVTT.WebApi.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    dotnet build ..\NhiemVuTrongTam\SER\NVTT.Migrator\NVTT.Migrator.csproj -c %CONFIG%
    if errorlevel 1 goto :fail
    goto :done
)

echo [ERROR] Unknown module: %MODULE%
echo Valid modules: BB, DVDC, QLDA, QLHD, NVTT
exit /b 1

:fail
echo.
echo ============================================
echo Build FAILED
echo ============================================
exit /b 1

:done
echo.
echo ============================================
echo Build SUCCESS - %CONFIG%
echo ============================================
endlocal