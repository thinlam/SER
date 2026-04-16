namespace BuildingBlocks.CrossCutting.Offices;

/// <summary>
/// Instruction for exporting two sheets from a single template workbook.
/// Sheet 1 contains T1 data, Sheet 2 contains T2 data.
/// Template must have two worksheets with $FieldName markers.
/// </summary>
public class MultiSheetInstruction<T1, T2>
{
    public required string TemplatePath { get; set; }
    public required List<T1> Sheet1Items { get; set; }
    public required List<T2> Sheet2Items { get; set; }
    public List<string> Sheet1HiddenColumns { get; set; } = [];
    public List<string> Sheet2HiddenColumns { get; set; } = [];
}