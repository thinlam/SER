namespace BuildingBlocks.CrossCutting.Offices;

public interface IExporterHelper
{
    /// <summary>
    /// Export template động dựa trên placeholders $FieldName
    /// </summary>
    /// <param name="instruction">Hướng dẫn export chứa template path, items và hidden columns</param>
    AsposeResult Export<T>(AsposeInstruction<T> instruction);

    /// <summary>
    /// Export dynamic using dictionary data - reads column mappings from Excel template.
    /// No property reflection required, maps dictionary keys to template columns directly.
    /// </summary>
    /// <param name="instruction">Instruction with dictionary items and template path</param>
    AsposeResult ExportDynamic(DynamicExportInstruction instruction);

    /// <summary>
    /// Export hierarchical data với 2 cấp group (LinhVuc -> PhongBan -> Items)
    /// Template markers:
    /// - Row 1: $Header_1 (group header, full merge)
    /// - Row 2: $Header_2 | $Count (sub-group header, partial merge + count)
    /// - Row 3: $STT | $NoiDung | $Field1 | ... (data row)
    /// </summary>
    AsposeResult ExportHierarchical<TGroup, TSubGroup, TItem>(
        TwoLevelHierarchicalInstruction<TGroup, TSubGroup, TItem> instruction);

    /// <summary>
    /// Export tree data with Excel outline grouping (expand/collapse)
    /// Uses Level property for hierarchical grouping
    /// </summary>
    AsposeResult ExportWithOutline<T>(TreeOutlineInstruction<T> instruction);

    /// <summary>
    /// Export multi-level hierarchical data with vertical cell merging.
    /// Supports N levels of hierarchy where certain columns can be merged vertically per root group.
    /// Uses dictionary-based data for flexibility.
    /// </summary>
    AsposeResult ExportMultiLevelHierarchical(MultiLevelHierarchicalInstruction instruction);

    /// <summary>
    /// Export two sheets from a single template workbook.
    /// Sheet 1: T1 data, Sheet 2: T2 data.
    /// Template must have two worksheets with $FieldName markers.
    /// </summary>
    AsposeResult ExportMultiSheet<T1, T2>(MultiSheetInstruction<T1, T2> instruction);

    /// <summary>
    /// Export N sheets with custom names from a single template worksheet.
    /// Template worksheet is copied for each sheet, renamed, and filled with dictionary-based data.
    /// Supports dynamic number of sheets (e.g., year-based reports: "Báo cáo tổng - 2025", "Báo cáo tổng - 2026").
    /// </summary>
    /// <param name="instruction">Instruction with template path and list of sheet configurations</param>
    AsposeResult ExportDynamicMultiSheet(DynamicMultiSheetInstruction instruction);
}