@echo off
setlocal enabledelayedexpansion

REM ============================================
REM ef.bat - Unified EF Core Migration Tool
REM ============================================
REM
REM Usage: ef.bat <Module> <Command> [MigrationName] [--dev|--dbo]
REM   Module: DVDC, QLDA, NVTT, QLHD (required)
REM   Command: add, remove, update, list (required)
REM   MigrationName: Required for 'add' command
REM   --dev/--dbo: Only for 'update' command - specify schema (default: dbo)
REM
REM Examples:
REM   ef.bat QLHD add AddUserTable         - Add migration (always dbo)
REM   ef.bat QLHD remove                   - Remove last migration (dbo schema)
REM   ef.bat QLHD remove --dev             - Remove last migration (dev schema)
REM   ef.bat QLHD remove 0                 - Remove ALL migrations (loop, dbo)
REM   ef.bat QLHD update                   - Update to latest (dbo schema)
REM   ef.bat QLHD update --dev             - Update to latest (dev schema)
REM   ef.bat QLHD update --dbo             - Update to latest (force dbo)
REM   ef.bat QLHD list                     - List migrations (dbo)
REM   ef.bat QLHD list --dev               - List migrations (dev)
REM ============================================

set MODULE=%1
set COMMAND=%2
set MIGRATION_NAME=%3
set DEV_SCHEMA=false

REM === Check for schema flags ===
for %%a in (%*) do (
    if /i "%%a"=="--dev" set DEV_SCHEMA=true
    if /i "%%a"=="--dbo" set DEV_SCHEMA=force-dbo
)

REM === Clear MIGRATION_NAME if it's a flag ===
if /i "%MIGRATION_NAME%"=="--dev" set MIGRATION_NAME=
if /i "%MIGRATION_NAME%"=="--dbo" set MIGRATION_NAME=

REM === Set Schema value for display and commands ===
if "%DEV_SCHEMA%"=="true" set SCHEMA_VALUE=dev
if "%DEV_SCHEMA%"=="force-dbo" set SCHEMA_VALUE=dbo
if "%DEV_SCHEMA%"=="false" set SCHEMA_VALUE=dbo

REM === Set ASPNETCORE_ENVIRONMENT ===
if not defined ASPNETCORE_ENVIRONMENT set ASPNETCORE_ENVIRONMENT=Development

REM === Validate Module ===
if "%MODULE%"=="" (
    echo.
    echo ERROR: Module parameter is required
    echo.
    echo Usage: ef.bat ^<Module^> ^<Command^> [MigrationName] [--dev]
    echo   Module: DVDC, QLDA, NVTT, QLHD
    echo   Command: add, remove, update, list
    echo.
    pause
    exit /b 1
)

REM === Validate Command ===
if "%COMMAND%"=="" (
    echo.
    echo ERROR: Command parameter is required
    echo.
    echo Usage: ef.bat ^<Module^> ^<Command^> [MigrationName] [--dev]
    echo   Command: add, remove, update, list
    echo.
    pause
    exit /b 1
)

REM === Set Module Paths (case-insensitive) ===
if /i "%MODULE%"=="DVDC" (
    set MODULE=DVDC
    set MIGRATOR_PATH=../DichVuDungChung/SER/DVDC.Migrator/DVDC.Migrator.csproj
    goto :module_found
)
if /i "%MODULE%"=="QLDA" (
    set MODULE=QLDA
    set MIGRATOR_PATH=../QuanLyDuAn/SER/QLDA.Migrator/QLDA.Migrator.csproj
    goto :module_found
)
if /i "%MODULE%"=="NVTT" (
    set MODULE=NVTT
    set MIGRATOR_PATH=../NhiemVuTrongTam/SER/NVTT.Migrator/NVTT.Migrator.csproj
    goto :module_found
)
if /i "%MODULE%"=="QLHD" (
    set MODULE=QLHD
    set MIGRATOR_PATH=modules/QLHD/QLHD.Migrator/QLHD.Migrator.csproj
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

REM === Display Info ===
echo.
echo ============================================
echo   %MODULE% EF CORE MIGRATION
echo ============================================
echo   Command: %COMMAND%
if not "%MIGRATION_NAME%"=="" echo   Migration: %MIGRATION_NAME%
if /i "%COMMAND%"=="update" echo   Schema: %SCHEMA_VALUE%
if /i "%COMMAND%"=="list" echo   Schema: %SCHEMA_VALUE%
if /i "%COMMAND%"=="remove" echo   Schema: %SCHEMA_VALUE%
echo ============================================
echo.

REM === Execute Command ===
if /i "%COMMAND%"=="add" goto :add_migration
if /i "%COMMAND%"=="remove" goto :remove_migration
if /i "%COMMAND%"=="update" goto :update_database
if /i "%COMMAND%"=="list" goto :list_migrations

echo.
echo ERROR: Invalid command "%COMMAND%"
echo Valid commands: add, remove, update, list
echo.
pause
exit /b 1

:add_migration
if "%MIGRATION_NAME%"=="" (
    echo ERROR: Migration name required for 'add' command
    echo Usage: ef.bat %MODULE% add ^<MigrationName^>
    pause
    exit /b 1
)
REM Add migration always uses dbo schema
set FULL_NAME=%MIGRATION_NAME%
set OUTPUT_DIR=Migrations/dbo
echo Adding migration: %FULL_NAME%
echo Output directory: %OUTPUT_DIR%
echo Schema: dbo (always)
cmd /c "set ASPNETCORE_ENVIRONMENT=Development&& set ConnectionStrings__Schema=dbo&& dotnet ef migrations add %FULL_NAME% --project %MIGRATOR_PATH% --startup-project %MIGRATOR_PATH% --output-dir %OUTPUT_DIR%"
goto :end

:remove_migration
REM Check for "0" to remove ALL migrations
if /i not "%MIGRATION_NAME%"=="0" goto :single_remove

echo Removing ALL migrations...
echo.
set REMOVE_COUNT=0

:remove_loop
cmd /c "set ASPNETCORE_ENVIRONMENT=Development&& set ConnectionStrings__Schema=%SCHEMA_VALUE%&& dotnet ef migrations remove --project %MIGRATOR_PATH% --startup-project %MIGRATOR_PATH% --context AppDbContext --force 2>nul"
if %ERRORLEVEL% EQU 0 (
    set /a REMOVE_COUNT+=1
    echo Removed migration #%REMOVE_COUNT%
    goto :remove_loop
)
echo.
echo ============================================
echo   Removed %REMOVE_COUNT% migration(s)
echo ============================================
if %REMOVE_COUNT% GTR 0 exit /b 0
goto :end

:single_remove
echo Removing last migration...
echo From: Migrations/%SCHEMA_VALUE%
cmd /c "set ASPNETCORE_ENVIRONMENT=Development&& set ConnectionStrings__Schema=%SCHEMA_VALUE%&& dotnet ef migrations remove --project %MIGRATOR_PATH% --startup-project %MIGRATOR_PATH% --context AppDbContext --force"
goto :end

:update_database
if "%MIGRATION_NAME%"=="" (
    echo Updating database to latest migration...
    echo Schema: %SCHEMA_VALUE%
    cmd /c "set ASPNETCORE_ENVIRONMENT=Development&& set ConnectionStrings__Schema=%SCHEMA_VALUE%&& dotnet ef database update --project %MIGRATOR_PATH% --startup-project %MIGRATOR_PATH%"
) else (
    echo Updating database to: %MIGRATION_NAME%
    echo Schema: %SCHEMA_VALUE%
    cmd /c "set ASPNETCORE_ENVIRONMENT=Development&& set ConnectionStrings__Schema=%SCHEMA_VALUE%&& dotnet ef database update %MIGRATION_NAME% --project %MIGRATOR_PATH% --startup-project %MIGRATOR_PATH%"
)
goto :end

:list_migrations
echo Listing migrations...
echo Schema: %SCHEMA_VALUE%
cmd /c "set ASPNETCORE_ENVIRONMENT=Development&& set ConnectionStrings__Schema=%SCHEMA_VALUE%&& dotnet ef migrations list --project %MIGRATOR_PATH% --startup-project %MIGRATOR_PATH%"
goto :end

:end
if %ERRORLEVEL% EQU 0 (
    echo.
    echo ============================================
    echo   OPERATION COMPLETED SUCCESSFULLY
    echo ============================================
) else (
    echo.
    echo ============================================
    echo   OPERATION FAILED
    echo ============================================
    echo   Error code: %ERRORLEVEL%
)
pause
