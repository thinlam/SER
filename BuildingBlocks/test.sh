#!/bin/bash

# ============================================
# test.sh - Unified Test Runner (Unix/Linux)
# ============================================
#
# Usage: test.sh [Module] [Options]
#   Module: BB, DVDC, QLDA, NVTT, QLHD, All (default: All)
#   Options:
#     --verbosity <level>  : minimal, normal, detailed (default: minimal)
#     --filter <pattern>   : Filter tests by name pattern
#     --coverage           : Run with code coverage
#     --watch              : Watch mode (re-run on changes)
#
# Examples:
#   test.sh                    - Run all tests
#   test.sh QLHD               - Run QLHD tests only
#   test.sh BB --verbosity detailed  - Run BuildingBlocks tests with detailed output
#   test.sh QLHD --filter "Create"   - Run QLHD tests matching "Create"
#   test.sh All --coverage     - Run all tests with coverage
# ============================================

set -e

# Default values
MODULE="All"
VERBOSITY="minimal"
FILTER=""
COVERAGE=false
WATCH=false

# Parse arguments
while [[ $# -gt 0 ]]; do
    case $1 in
        --verbosity)
            VERBOSITY="$2"
            shift 2
            ;;
        --filter)
            FILTER="$2"
            shift 2
            ;;
        --coverage)
            COVERAGE=true
            shift
            ;;
        --watch)
            WATCH=true
            shift
            ;;
        BB|DVDC|QLDA|NVTT|QLHD|All)
            MODULE="$1"
            shift
            ;;
        *)
            echo "Unknown option: $1"
            exit 1
            ;;
    esac
done

# Display header
echo ""
echo "============================================"
echo "  TEST RUNNER"
echo "============================================"
echo "  Module    : $MODULE"
echo "  Verbosity : $VERBOSITY"
[[ -n "$FILTER" ]] && echo "  Filter    : $FILTER"
[[ "$COVERAGE" == true ]] && echo "  Coverage  : Enabled"
[[ "$WATCH" == true ]] && echo "  Watch     : Enabled"
echo "============================================"
echo ""

# Build options
COVERAGE_OPTS=""
[[ "$COVERAGE" == true ]] && COVERAGE_OPTS="--collect:\"XPlat Code Coverage\" --results-directory ./TestResults"

FILTER_OPTS=""
[[ -n "$FILTER" ]] && FILTER_OPTS="--filter \"$FILTER\""

WATCH_OPTS=""
[[ "$WATCH" == true ]] && WATCH_OPTS="--watch"

# Run tests based on module
run_tests() {
    local project=$1
    local name=$2

    echo "Running $name tests..."
    echo ""

    eval dotnet test $project $WATCH_OPTS --verbosity $VERBOSITY $FILTER_OPTS $COVERAGE_OPTS
}

case $MODULE in
    All)
        run_tests "" "ALL"
        ;;
    BB)
        run_tests "tests/BuildingBlocks.Tests/SharedKernel.Tests.csproj" "BuildingBlocks"
        ;;
    DVDC)
        if [[ -f "../DichVuDungChung/SER/DVDC.Tests/DVDC.Tests.csproj" ]]; then
            run_tests "../DichVuDungChung/SER/DVDC.Tests/DVDC.Tests.csproj" "DVDC"
        else
            echo "No tests found for DVDC module."
        fi
        ;;
    QLDA)
        if [[ -f "../QuanLyDuAn/SER/QLDA.Tests/QLDA.Tests.csproj" ]]; then
            run_tests "../QuanLyDuAn/SER/QLDA.Tests/QLDA.Tests.csproj" "QLDA"
        else
            echo "No tests found for QLDA module."
        fi
        ;;
    NVTT)
        if [[ -f "../NhiemVuTrongTam/SER/NVTT.Tests/NVTT.Tests.csproj" ]]; then
            run_tests "../NhiemVuTrongTam/SER/NVTT.Tests/NVTT.Tests.csproj" "NVTT"
        else
            echo "No tests found for NVTT module."
        fi
        ;;
    QLHD)
        run_tests "tests/QLHD.Tests/QLHD.Tests.csproj" "QLHD"
        ;;
    *)
        echo ""
        echo "ERROR: Invalid module '$MODULE'"
        echo ""
        echo "Valid modules: BB, DVDC, QLDA, NVTT, QLHD, All"
        exit 1
        ;;
esac

# Summary
echo ""
echo "============================================"
echo "  TESTS PASSED"
echo "============================================"

[[ "$COVERAGE" == true ]] && echo "" && echo "Coverage report saved to: ./TestResults"