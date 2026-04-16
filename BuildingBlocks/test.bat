@echo off
setlocal enabledelayedexpansion

REM ============================================
REM test.bat - Unified Test Runner
REM ============================================
REM
REM Usage: test.bat [Module] [Options]
REM   Module: BB, DVDC, QLDA, NVTT, QLHD, All (default: All)
REM   Options:
REM     --verbosity <level>  : minimal, normal, detailed (default: minimal)
REM     --filter <pattern>   : Filter tests by name pattern
REM     --coverage           : Run with code coverage
REM     --watch              : Watch mode (re-run on changes)
REM
REM Examples:
REM   test.bat                    - Run all tests
REM   test.bat QLHD               - Run QLHD tests only
REM   test.bat BB --verbosity detailed  - Run BuildingBlocks tests with detailed output
REM   test.bat QLHD --filter "Create"   - Run QLHD tests matching "Create"
REM   test.bat All --coverage     - Run all tests with coverage
REM ============================================

set MODULE=%1
set VERBOSITY=minimal
set FILTER=
set COVERAGE=false
set WATCH=false

REM === Parse Options ===
:parse_args
if "%~2"=="" goto :done_parsing
if /i "%~2"=="--verbosity" (
    set VERBOSITY=%~3
    shift
    shift
    goto :parse_args
)
if /i "%~2"=="--filter" (
    set FILTER=%~3
    shift
    shift
    goto :parse_args
)
if /i "%~2"=="--coverage" (
    set COVERAGE=true
    shift
    goto :parse_args
)
if /i "%~2"=="--watch" (
    set WATCH=true
    shift
    goto :parse_args
)
shift
goto :parse_args

:done_parsing

REM === Set Defaults ===
if "%MODULE%"=="" set MODULE=All
if /i "%MODULE%"=="--verbosity" set MODULE=All
if /i "%MODULE%"=="--filter" set MODULE=All
if /i "%MODULE%"=="--coverage" set MODULE=All
if /i "%MODULE%"=="--watch" set MODULE=All

REM === Display Header ===
echo.
echo ============================================
echo   TEST RUNNER
echo ============================================
echo   Module    : %MODULE%
echo   Verbosity : %VERBOSITY%
if not "%FILTER%"=="" echo   Filter    : %FILTER%
if "%COVERAGE%"=="true" echo   Coverage  : Enabled
if "%WATCH%"=="true" echo   Watch     : Enabled
echo ============================================
echo.

REM === Build Coverage Options ===
set COVERAGE_OPTS=
if "%COVERAGE%"=="true" (
    set COVERAGE_OPTS=--collect:"XPlat Code Coverage" --results-directory ./TestResults
)

REM === Build Filter Options ===
set FILTER_OPTS=
if not "%FILTER%"=="" (
    set FILTER_OPTS=--filter "%FILTER%"
)

REM === Build Watch Options ===
set WATCH_OPTS=
if "%WATCH%"=="true" (
    set WATCH_OPTS=--watch
)

REM === Run Tests Based on Module ===
if /i "%MODULE%"=="All" goto :run_all
if /i "%MODULE%"=="BB" goto :run_bb
if /i "%MODULE%"=="DVDC" goto :run_dvdc
if /i "%MODULE%"=="QLDA" goto :run_qlda
if /i "%MODULE%"=="NVTT" goto :run_nvtt
if /i "%MODULE%"=="QLHD" goto :run_qlhd

echo.
echo ERROR: Invalid module "%MODULE%"
echo.
echo Valid modules: BB, DVDC, QLDA, NVTT, QLHD, All
echo.
pause
exit /b 1

:run_all
echo Running ALL tests...
echo.
dotnet test %WATCH_OPTS% --verbosity %VERBOSITY% %FILTER_OPTS% %COVERAGE_OPTS%
goto :end

:run_bb
echo Running BuildingBlocks tests...
echo.
dotnet test tests/BuildingBlocks.Tests/SharedKernel.Tests.csproj %WATCH_OPTS% --verbosity %VERBOSITY% %FILTER_OPTS% %COVERAGE_OPTS%
goto :end

:run_dvdc
echo Running DVDC tests...
echo.
if exist "../DichVuDungChung/SER/DVDC.Tests/DVDC.Tests.csproj" (
    dotnet test ../DichVuDungChung/SER/DVDC.Tests/DVDC.Tests.csproj %WATCH_OPTS% --verbosity %VERBOSITY% %FILTER_OPTS% %COVERAGE_OPTS%
) else (
    echo No tests found for DVDC module.
)
goto :end

:run_qlda
echo Running QLDA tests...
echo.
if exist "../QuanLyDuAn/SER/QLDA.Tests/QLDA.Tests.csproj" (
    dotnet test ../QuanLyDuAn/SER/QLDA.Tests/QLDA.Tests.csproj %WATCH_OPTS% --verbosity %VERBOSITY% %FILTER_OPTS% %COVERAGE_OPTS%
) else (
    echo No tests found for QLDA module.
)
goto :end

:run_nvtt
echo Running NVTT tests...
echo.
if exist "../NhiemVuTrongTam/SER/NVTT.Tests/NVTT.Tests.csproj" (
    dotnet test ../NhiemVuTrongTam/SER/NVTT.Tests/NVTT.Tests.csproj %WATCH_OPTS% --verbosity %VERBOSITY% %FILTER_OPTS% %COVERAGE_OPTS%
) else (
    echo No tests found for NVTT module.
)
goto :end

:run_qlhd
echo Running QLHD tests...
echo.
dotnet test tests/QLHD.Tests/QLHD.Tests.csproj %WATCH_OPTS% --verbosity %VERBOSITY% %FILTER_OPTS% %COVERAGE_OPTS%
goto :end

:end
if %ERRORLEVEL% EQU 0 (
    echo.
    echo ============================================
    echo   TESTS PASSED
    echo ============================================
) else (
    echo.
    echo ============================================
    echo   TESTS FAILED
    echo ============================================
    echo   Error code: %ERRORLEVEL%
)

if "%COVERAGE%"=="true" (
    echo.
    echo Coverage report saved to: ./TestResults
)

pause