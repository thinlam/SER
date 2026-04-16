#!/usr/bin/env bash
# ============================================
# run.sh - Run Module WebApi with hot reload (Linux)
# ============================================
#
# Usage: ./run.sh <Module> [--dev]
#   Module: DVDC, QLDA, NVTT, QLHD (required)
#   --dev: Use dev schema instead of dbo
#
# Examples:
#   ./run.sh QLHD       - Run QLHD.WebApi with watch (dbo schema)
#   ./run.sh QLHD --dev - Run QLHD.WebApi with watch (dev schema)
#   ./run.sh DVDC       - Run DVDC.WebApi with watch

set -euo pipefail

# Default to Development environment for local WSL/Linux
export ASPNETCORE_ENVIRONMENT="${ASPNETCORE_ENVIRONMENT:-Development}"

MODULE="${1:-}"

# === Validate Module ===
if [[ -z "$MODULE" ]]; then
    echo ""
    echo "ERROR: Module parameter is required"
    echo ""
    echo "Usage: ./run.sh <Module> [--dev]"
    echo "  Module: DVDC, QLDA, NVTT, QLHD"
    exit 1
fi

# === Check for --dev flag ===
DEV_SCHEMA=false
for arg in "$@"; do
    if [[ "$arg" == "--dev" ]]; then
        DEV_SCHEMA=true
    fi
done

if [[ "$DEV_SCHEMA" == true ]]; then
    export ConnectionStrings__Schema="dev"
fi

# === Set Module Paths (case-insensitive) ===
MODULE=$(echo "$MODULE" | tr '[:lower:]' '[:upper:]')

case "$MODULE" in
    DVDC) WEBAPI_PATH="../DichVuDungChung/SER/DVDC.WebApi/DVDC.WebApi.csproj" ;;
    QLDA) WEBAPI_PATH="../QuanLyDuAn/SER/QLDA.WebApi/QLDA.WebApi.csproj" ;;
    NVTT) WEBAPI_PATH="../NhiemVuTrongTam/SER/NVTT.WebApi/NVTT.WebApi.csproj" ;;
    QLHD) WEBAPI_PATH="modules/QLHD/QLHD.WebApi/QLHD.WebApi.csproj" ;;
    *)
        echo ""
        echo "ERROR: Invalid module \"$MODULE\""
        echo ""
        echo "Valid modules: DVDC, QLDA, NVTT, QLHD"
        exit 1
        ;;
esac

echo ""
echo "============================================"
echo "  $MODULE WebApi - Running with Watch"
echo "============================================"
echo "  Project: $WEBAPI_PATH"
if [[ "$DEV_SCHEMA" == true ]]; then
    echo "  Schema: dev"
else
    echo "  Schema: dbo (default)"
fi
echo "============================================"
echo ""

dotnet watch --project "$WEBAPI_PATH"
