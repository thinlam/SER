using Aspose.Cells.Tables;

namespace SharedKernel.CrossCuttingConcerns.Offices;

public record MergeInstruction(int RowIndex, int StartColumnIndex, int EndColumnIndex, string FieldName);

public record TemplateBinding(int TemplateRowIndex, Dictionary<int, string> ColumnMappings, ListObject? TemplateTable);


