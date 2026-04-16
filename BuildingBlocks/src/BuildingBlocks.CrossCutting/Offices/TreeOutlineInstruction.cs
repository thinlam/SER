namespace BuildingBlocks.CrossCutting.Offices;

/// <summary>
/// Configuration for tree-based Excel export with outline grouping (expand/collapse)
/// Uses Aspose.Cells GroupRows API for Excel row grouping
/// </summary>
public class TreeOutlineInstruction<T> {
    public required string TemplatePath { get; set; }
    public required List<T> Items { get; set; }
    public List<string> HiddenColumns { get; set; } = [];
    public string LevelPropertyName { get; set; } = "Level";
    public bool CollapseGroups { get; set; } = false;
    public bool SummaryRowBelow { get; set; } = false;
    public Dictionary<string, string>? PlaceholderReplacements { get; set; }
}