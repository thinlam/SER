namespace BuildingBlocks.CrossCutting.Offices;

/// <summary>
/// Instruction for exporting N sheets with custom names from a single template.
/// Each sheet is created by copying the template worksheet and filling with dictionary-based data.
/// </summary>
public class DynamicMultiSheetInstruction
{
    /// <summary>
    /// Path to the Excel template file.
    /// Template must have at least one worksheet with $FieldName markers.
    /// </summary>
    public required string TemplatePath { get; set; }

    /// <summary>
    /// List of sheet instructions - each defines title and data for one sheet.
    /// Sheets are created in order, named according to Title property.
    /// </summary>
    public required List<SheetInstruction> Sheets { get; set; }

    /// <summary>
    /// Placeholder replacements to apply across all sheets.
    /// Key: placeholder (e.g., "&lt;Nam&gt;"), Value: replacement text.
    /// </summary>
    public Dictionary<string, string>? PlaceholderReplacements { get; set; }
}

/// <summary>
/// Configuration for a single sheet in dynamic multi-sheet export.
/// </summary>
public class SheetInstruction
{
    /// <summary>
    /// Title/name for the worksheet tab.
    /// Example: "Báo cáo tổng - 2025"
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Data rows as dictionaries.
    /// Keys map to template column markers ($FieldName).
    /// </summary>
    public required List<Dictionary<string, object?>> Items { get; set; }

    /// <summary>
    /// Columns to hide/remove from this sheet.
    /// Column names match template markers (without $ prefix).
    /// </summary>
    public List<string> HiddenColumns { get; set; } = [];
}