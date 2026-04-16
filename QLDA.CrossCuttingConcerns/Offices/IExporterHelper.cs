namespace SharedKernel.CrossCuttingConcerns.Offices;

public interface IExporterHelper {
    /// <summary>
    /// Export template động dựa trên placeholders $FieldName
    /// </summary>
    /// <param name="TemplatePath">Đường dẫn tới file .xlsx template</param>
    /// <param name="Items">Danh sách object (từ Dapper) để in</param>
    /// <param name="HiddenColumns">Danh sách các cột cần ẩn trong file Excel</param>
    AsposeResult Export<T>(AsposeInstruction<T> instruction);

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
    /// Export tree data với Excel outline grouping (expand/collapse feature)
    /// Sử dụng Aspose.Cells GroupRows API dựa trên Level property
    /// </summary>
    AsposeResult ExportWithOutline<T>(TreeOutlineInstruction<T> instruction);
}
