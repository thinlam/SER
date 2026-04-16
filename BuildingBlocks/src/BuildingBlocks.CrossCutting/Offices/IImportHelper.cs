namespace BuildingBlocks.CrossCutting.Offices;

public interface IImporterHelper
{
    /// <summary>
    /// Export template động dựa trên placeholders $FieldName
    /// </summary>
    /// <param name="templatePath">Đường dẫn tới file .xlsx template</param>
    /// <param name="comboData">Template có danh mục</param>
    AsposeResult GetTemplate(string templatePath, List<List<ComboData>>? comboData = null);

    public List<T> ReadDataFromExcel<T>(Stream excelStream)
        where T : new();
}