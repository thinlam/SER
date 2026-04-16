#!/usr/bin/env bash
# ============================================
# deploy.sh - Unified Module Deployment (Linux/WSL)
# ============================================
#
# Usage: ./deploy.sh <Module> [Environment] [DeploymentMode]
#   Module: DVDC, QLDA, NVTT, QLHD (required)
#   Environment: Staging (default), Production
#   DeploymentMode: Incremental (default), Full
#
# Examples:
#   ./deploy.sh DVDC                    - DVDC to Staging
#   ./deploy.sh QLHD Staging Full       - QLHD Full deployment
#   ./deploy.sh NVTT Production         - NVTT Production build
#
# Destinations (UNC via Windows host network):
#   DVDC: \\192.168.1.12\api_mnd\TTCDS\DichVuDungChung
#   QLDA: \\192.168.1.12\api_mnd\TTCDS\QuanLyDuAn
#   NVTT: \\192.168.1.12\api_mnd\TTCDS\NhiemVuTrongTam
#   QLHD: \\192.168.1.12\api_mnd\TTCDS\QuanLyHopDong
# ============================================

set -euo pipefail

# === Destination Base Path ===
# UNC path for Windows (used via powershell.exe from WSL)
DESTINATION_UNC="\\\\192.168.1.12\\api_mnd\\TTCDS"

# === Parse Arguments ===
MODULE="${1:-}"
ENVIRONMENT="${2:-Staging}"
DEPLOYMENT_MODE="${3:-Incremental}"

# === Validate Module (Required) ===
if [[ -z "$MODULE" ]]; then
    echo ""
    echo "ERROR: Module parameter is required"
    echo ""
    echo "Usage: ./deploy.sh <Module> [Environment] [DeploymentMode]"
    echo "  Module: DVDC, QLDA, NVTT, QLHD"
    echo "  Environment: Staging (default), Production"
    echo "  DeploymentMode: Incremental (default), Full"
    echo ""
    exit 1
fi

# === Validate and Set Module Configuration (case-insensitive) ===
case "${MODULE,,}" in
    dvdc)
        MODULE="DVDC"
        MODULE_NAME="DichVuDungChung"
        WEBAPI_PATH="../DichVuDungChung/SER/DVDC.WebApi/DVDC.WebApi.csproj"
        DESTINATION_PATH="${DESTINATION_UNC}\\DichVuDungChung"
        ;;
    qlda)
        MODULE="QLDA"
        MODULE_NAME="QuanLyDuAn"
        WEBAPI_PATH="../QuanLyDuAn/SER/QLDA.WebApi/QLDA.WebApi.csproj"
        DESTINATION_PATH="${DESTINATION_UNC}\\QuanLyDuAn"
        ;;
    nvtt)
        MODULE="NVTT"
        MODULE_NAME="NhiemVuTrongTam"
        WEBAPI_PATH="../NhiemVuTrongTam/SER/NVTT.WebApi/NVTT.WebApi.csproj"
        DESTINATION_PATH="${DESTINATION_UNC}\\NhiemVuTrongTam"
        ;;
    qlhd)
        MODULE="QLHD"
        MODULE_NAME="QuanLyHopDong"
        WEBAPI_PATH="modules/QLHD/QLHD.WebApi/QLHD.WebApi.csproj"
        DESTINATION_PATH="${DESTINATION_UNC}\\QuanLyHopDong"
        ;;
    *)
        echo ""
        echo "ERROR: Invalid module \"$MODULE\""
        echo ""
        echo "Valid modules: DVDC, QLDA, NVTT, QLHD"
        echo ""
        exit 1
        ;;
esac

# === Validate Environment ===
if [[ ! "$ENVIRONMENT" =~ ^(Staging|Production)$ ]]; then
    echo ""
    echo "ERROR: Invalid environment \"$ENVIRONMENT\""
    echo ""
    exit 1
fi

# === Validate DeploymentMode ===
if [[ ! "$DEPLOYMENT_MODE" =~ ^(Incremental|Full)$ ]]; then
    echo ""
    echo "ERROR: Invalid deployment mode \"$DEPLOYMENT_MODE\""
    echo ""
    exit 1
fi

# === Adjust Production Destination ===
if [[ "$ENVIRONMENT" == "Production" ]]; then
    DESTINATION_PATH="${DESTINATION_PATH}/Production"
fi

# === Display Deployment Info ===
echo ""
echo "============================================"
echo "  ${MODULE} (${MODULE_NAME}) DEPLOYMENT"
echo "============================================"
echo "  Environment    : ${ENVIRONMENT}"
echo "  Deployment Mode: ${DEPLOYMENT_MODE}"
if [[ "$ENVIRONMENT" == "Production" ]]; then
    echo "  Destination    : Build Only (no server deploy)"
else
    echo "  Destination    : ${DESTINATION_PATH}"
fi
echo "============================================"
echo ""

# === Build Project ===
echo "Publishing ${MODULE}.WebApi..."
PUBLISH_PATH="$(pwd)/bin/Release/net8.0/publish/${MODULE}"

mkdir -p "./bin/Release/net8.0/publish"

if ! dotnet publish "$WEBAPI_PATH" --configuration Release --output "$PUBLISH_PATH"; then
    echo "Publish failed."
    exit 1
fi

# === Cleanup Publish Folder ===
echo "Cleaning up publish folder..."

# Remove dev config
[[ -f "$PUBLISH_PATH/appsettings.Development.json" ]] && rm -f "$PUBLISH_PATH/appsettings.Development.json"

# Remove env-specific configs not matching target
if [[ "$ENVIRONMENT" == "Staging" ]]; then
    rm -f "$PUBLISH_PATH/appsettings.Production.json"
fi
if [[ "$ENVIRONMENT" == "Production" ]]; then
    rm -f "$PUBLISH_PATH/appsettings.Staging.json"
fi

# Remove sensitive and non-deployable files
rm -f "$PUBLISH_PATH"/.env* 2>/dev/null || true
rm -f "$PUBLISH_PATH"/*.md 2>/dev/null || true

for f in Deploy.bat deploy.bat deploy.sh DeployScript.ps1 makefile Dockerfile .dockerignore; do
    rm -f "${PUBLISH_PATH}/${f}"
done

# Remove non-deployable directories
for d in .claude plans docs logs Tests backup; do
    rm -rf "${PUBLISH_PATH}/${d}"
done

# Remove test-related files
rm -f "${PUBLISH_PATH}/${MODULE}".*.Tests.* 2>/dev/null || true
rm -f "${PUBLISH_PATH}"/*Tests*.dll 2>/dev/null || true
rm -f "${PUBLISH_PATH}"/*Tests*.json 2>/dev/null || true
rm -f "${PUBLISH_PATH}"/Moq.dll 2>/dev/null || true
rm -f "${PUBLISH_PATH}"/xunit*.dll 2>/dev/null || true
rm -f "${PUBLISH_PATH}"/coverlet*.dll 2>/dev/null || true
rm -f "${PUBLISH_PATH}"/Microsoft.NET.Test*.dll 2>/dev/null || true

# Remove non-English localization folders
echo "Removing non-English localization folders..."
find "$PUBLISH_PATH" -maxdepth 1 -type d -regex '.*/[a-z]\{2\}\(-[A-Za-z]\+\)\?$' \
    ! -name 'en' ! -name 'en-US' ! -name 'en-GB' -exec rm -rf {} + 2>/dev/null || true

echo "Cleanup completed."

# === Update web.config ===
if [[ -f "$PUBLISH_PATH/web.config" ]]; then
    echo "Setting ASPNETCORE_ENVIRONMENT to ${ENVIRONMENT}..."
    sed -i "s|name=\"ASPNETCORE_ENVIRONMENT\" value=\"[^\"]*\"|name=\"ASPNETCORE_ENVIRONMENT\" value=\"${ENVIRONMENT}\"|g" \
        "${PUBLISH_PATH}/web.config"
    echo "web.config updated"
fi

# === Deploy ===
if [[ "$ENVIRONMENT" == "Production" ]]; then
    echo ""
    echo "============================================"
    echo "  ${MODULE} PRODUCTION BUILD COMPLETE"
    echo "============================================"
    echo "  Build artifacts: ${PUBLISH_PATH}"
    echo "============================================"
else
    echo "Copying files to server..."

    # Convert WSL publish path to Windows path for powershell.exe
    WIN_PUBLISH_PATH=$(wslpath -w "$PUBLISH_PATH")

    # Use PowerShell via Windows host (has VPN/network access)
    SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
    WIN_SCRIPT_DIR=$(wslpath -w "$SCRIPT_DIR")

    if [[ "$DEPLOYMENT_MODE" == "Incremental" ]]; then
        echo "Incremental mode: excluding web.config and PrintTemplates"
        powershell.exe -ExecutionPolicy Bypass -File "${WIN_SCRIPT_DIR}\\DeployScript.ps1" \
            -SourcePath "$WIN_PUBLISH_PATH" \
            -DestinationPath "$DESTINATION_PATH" \
            -DeploymentMode Incremental
    else
        echo "Full mode: including web.config and PrintTemplates"
        powershell.exe -ExecutionPolicy Bypass -File "${WIN_SCRIPT_DIR}\\DeployScript.ps1" \
            -SourcePath "$WIN_PUBLISH_PATH" \
            -DestinationPath "$DESTINATION_PATH" \
            -DeploymentMode Full
    fi

    if [[ $? -eq 0 ]]; then
        echo ""
        echo "============================================"
        echo "  ${MODULE} DEPLOYMENT SUCCESSFUL"
        echo "============================================"
        echo "  Destination: ${DESTINATION_PATH}"
        echo "============================================"
    else
        echo "Deployment failed."
        exit 1
    fi
fi
