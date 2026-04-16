using Aspose.Cells.Tables;

namespace BuildingBlocks.CrossCutting.Offices;

public record MergeInstruction(int RowIndex, int StartColumnIndex, int EndColumnIndex, string FieldName);

public record TemplateBinding(int TemplateRowIndex, Dictionary<int, string> ColumnMappings, ListObject? TemplateTable);