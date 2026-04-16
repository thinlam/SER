#!/usr/bin/env bash
# ============================================
# ef.sh - Unified EF Core Migration Tool (Linux)
# ============================================
#
# Usage: ./ef.sh <Module> <Command> [MigrationName] [--dev|--dbo]
#   Module: DVDC, QLDA, NVTT, QLHD (required)
#   Command: add, remove, update, list (required)
#   MigrationName: Required for 'add' command
#   --dev/--dbo: Only for 'update' command - specify schema (default: dbo)
#
# Examples:
#   ./ef.sh QLHD add AddUserTable         - Add migration (always dbo)
#   ./ef.sh QLHD remove                   - Remove last migration (dbo schema)
#   ./ef.sh QLHD remove --dev             - Remove last migration (dev schema)
#   ./ef.sh QLHD remove 0                 - Remove ALL migrations (loop, dbo)
#   ./ef.sh QLHD update                   - Update to latest (dbo schema)
#   ./ef.sh QLHD update --dev             - Update to latest (dev schema)
#   ./ef.sh QLHD update --dbo             - Update to latest (force dbo)
#   ./ef.sh QLHD list                     - List migrations (dbo)
#   ./ef.sh QLHD list --dev               - List migrations (dev)
# ============================================

set -euo pipefail

# Default to Development environment for local WSL/Linux
export ASPNETCORE_ENVIRONMENT="${ASPNETCORE_ENVIRONMENT:-Development}"

MODULE="${1:-}"
COMMAND="${2:-}"
MIGRATION_NAME="${3:-}"

# === Check for schema flags ===
DEV_SCHEMA=false
for arg in "$@"; do
    if [[ "$arg" == "--dev" ]]; then
        DEV_SCHEMA=true
    fi
    if [[ "$arg" == "--dbo" ]]; then
        DEV_SCHEMA=force-dbo
    fi
done

# === Set Schema value for display and commands ===
if [[ "$DEV_SCHEMA" == true ]]; then
    SCHEMA_VALUE="dev"
elif [[ "$DEV_SCHEMA" == "force-dbo" ]]; then
    SCHEMA_VALUE="dbo"
else
    SCHEMA_VALUE="dbo"
fi

# === Validate Module ===
if [[ -z "$MODULE" ]]; then
    echo ""
    echo "ERROR: Module parameter is required"
    echo ""
    echo "Usage: ./ef.sh <Module> <Command> [MigrationName] [--dev|--dbo]"
    echo "  Module: DVDC, QLDA, NVTT, QLHD"
    echo "  Command: add, remove, update, list"
    exit 1
fi

# === Validate Command ===
if [[ -z "$COMMAND" ]]; then
    echo ""
    echo "ERROR: Command parameter is required"
    echo ""
    echo "Usage: ./ef.sh <Module> <Command> [MigrationName] [--dev|--dbo]"
    echo "  Command: add, remove, update, list"
    exit 1
fi

# === Set Module Paths (case-insensitive) ===
MODULE=$(echo "$MODULE" | tr '[:lower:]' '[:upper:]')

case "$MODULE" in
    DVDC) MIGRATOR_PATH="../DichVuDungChung/SER/DVDC.Migrator/DVDC.Migrator.csproj" ;;
    QLDA) MIGRATOR_PATH="../QuanLyDuAn/SER/QLDA.Migrator/QLDA.Migrator.csproj" ;;
    NVTT) MIGRATOR_PATH="../NhiemVuTrongTam/SER/NVTT.Migrator/NVTT.Migrator.csproj" ;;
    QLHD) MIGRATOR_PATH="modules/QLHD/QLHD.Migrator/QLHD.Migrator.csproj" ;;
    *)
        echo ""
        echo "ERROR: Invalid module \"$MODULE\""
        echo ""
        echo "Valid modules: DVDC, QLDA, NVTT, QLHD"
        exit 1
        ;;
esac

# === Display Info ===
echo ""
echo "============================================"
echo "  $MODULE EF CORE MIGRATION"
echo "============================================"
echo "  Command: $COMMAND"
[[ -n "$MIGRATION_NAME" ]] && echo "  Migration: $MIGRATION_NAME"
if [[ "$COMMAND" == "update" ]] || [[ "$COMMAND" == "list" ]] || [[ "$COMMAND" == "remove" ]]; then
    echo "  Schema: $SCHEMA_VALUE"
fi
echo "============================================"
echo ""

# === Execute Command ===
COMMAND=$(echo "$COMMAND" | tr '[:upper:]' '[:lower:]')

case "$COMMAND" in
    add)
        if [[ -z "$MIGRATION_NAME" ]]; then
            echo "ERROR: Migration name required for 'add' command"
            echo "Usage: ./ef.sh $MODULE add <MigrationName>"
            exit 1
        fi
        # Add migration always uses dbo schema
        FULL_NAME="$MIGRATION_NAME"
        echo "Adding migration: $FULL_NAME"
        echo "Output directory: Migrations/dbo"
        echo "Schema: dbo (always)"
        export ConnectionStrings__Schema="dbo"
        dotnet ef migrations add "$FULL_NAME" --project "$MIGRATOR_PATH" --startup-project "$MIGRATOR_PATH" --output-dir Migrations/dbo
        ;;

    remove)
        # Check for "0" to remove ALL migrations
        if [[ "$MIGRATION_NAME" == "0" ]]; then
            echo "Removing ALL migrations..."
            echo ""
            REMOVE_COUNT=0
            export ConnectionStrings__Schema="$SCHEMA_VALUE"
            while dotnet ef migrations remove --project "$MIGRATOR_PATH" --startup-project "$MIGRATOR_PATH" --context AppDbContext --force 2>/dev/null; do
                ((REMOVE_COUNT++)) || true
                echo "Removed migration #$REMOVE_COUNT"
            done
            echo ""
            echo "============================================"
            echo "  Removed $REMOVE_COUNT migration(s)"
            echo "============================================"
        else
            echo "Removing last migration..."
            echo "From: Migrations/$SCHEMA_VALUE"
            export ConnectionStrings__Schema="$SCHEMA_VALUE"
            dotnet ef migrations remove --project "$MIGRATOR_PATH" --startup-project "$MIGRATOR_PATH" --context AppDbContext --force
        fi
        ;;

    update)
        export ConnectionStrings__Schema="$SCHEMA_VALUE"
        if [[ -z "$MIGRATION_NAME" ]] || [[ "$MIGRATION_NAME" == "--dev" ]] || [[ "$MIGRATION_NAME" == "--dbo" ]]; then
            echo "Updating database to latest migration..."
            echo "Schema: $SCHEMA_VALUE"
            dotnet ef database update --project "$MIGRATOR_PATH" --startup-project "$MIGRATOR_PATH"
        else
            echo "Updating database to: $MIGRATION_NAME"
            echo "Schema: $SCHEMA_VALUE"
            dotnet ef database update "$MIGRATION_NAME" --project "$MIGRATOR_PATH" --startup-project "$MIGRATOR_PATH"
        fi
        ;;

    list)
        echo "Listing migrations..."
        echo "Schema: $SCHEMA_VALUE"
        export ConnectionStrings__Schema="$SCHEMA_VALUE"
        dotnet ef migrations list --project "$MIGRATOR_PATH" --startup-project "$MIGRATOR_PATH"
        ;;

    *)
        echo ""
        echo "ERROR: Invalid command \"$COMMAND\""
        echo "Valid commands: add, remove, update, list"
        exit 1
        ;;
esac

# === Result ===
if [[ $? -eq 0 ]]; then
    echo ""
    echo "============================================"
    echo "  OPERATION COMPLETED SUCCESSFULLY"
    echo "============================================"
else
    echo ""
    echo "============================================"
    echo "  OPERATION FAILED"
    echo "============================================"
    exit 1
fi
