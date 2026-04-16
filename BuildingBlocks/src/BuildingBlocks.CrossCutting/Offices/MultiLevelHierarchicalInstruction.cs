namespace BuildingBlocks.CrossCutting.Offices;

/// <summary>
/// Configuration for multi-level hierarchical Excel export with vertical cell merging.
/// Supports N levels of hierarchy where certain columns can be merged vertically per group.
/// </summary>
public class MultiLevelHierarchicalInstruction {
    public required string TemplatePath { get; set; }
    public Dictionary<string, string>? PlaceholderReplacements { get; set; }

    /// <summary>
    /// Column indices for vertically merged columns (0-based).
    /// These columns will be merged across all rows within each root group.
    /// </summary>
    public required List<int> MergedColumnIndices { get; set; }

    /// <summary>
    /// Data rows with Level property indicating hierarchy depth.
    /// Level 1 = root group, Level 2 = subgroup, etc.
    /// </summary>
    public required List<Dictionary<string, object?>> Rows { get; set; }

    /// <summary>
    /// Property name to determine hierarchy level from each row.
    /// Default: "Level"
    /// </summary>
    public string LevelPropertyName { get; set; } = "Level";

    /// <summary>
    /// The level that defines root groups for merging.
    /// Default: 1 (Level 1 rows are root groups)
    /// Set to 0 if you have a super-root level that spans multiple Level 1 groups.
    /// </summary>
    public int RootLevel { get; set; } = 1;

    /// <summary>
    /// Property name for STT (row number within root group).
    /// Used to fill STT column automatically.
    /// </summary>
    public string? SttPropertyName { get; set; }

    /// <summary>
    /// Column index for STT (if auto-numbering needed).
    /// </summary>
    public int SttColumnIndex { get; set; } = -1;

    /// <summary>
    /// Template row index (0-based) where $ markers are located.
    /// </summary>
    public int TemplateRowIndex { get; set; } = 5; // Default to row 6 (0-indexed = 5)
}