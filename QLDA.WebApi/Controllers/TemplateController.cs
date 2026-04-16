using Microsoft.EntityFrameworkCore;

namespace QLDA.WebApi.Controllers;

[Tags("Mẫu")]
[Route("api/template")]
public class TemplateController(IServiceProvider serviceProvider) : AggregateRootController(serviceProvider) {
    private readonly IImporterHelper _excelImporter = serviceProvider.GetRequiredService<IImporterHelper>();
    private readonly IRepository<DuAn, Guid> DuAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();

    private readonly IRepository<DuAnBuoc, int> DuAnBuoc =
        serviceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();

    [HttpGet("import-bao-cao-tien-do")]

    [ProducesResponseType<FileContentResult>(StatusCodes.Status200OK)]
    [ProducesResponseType<ResultApi>(StatusCodes.Status400BadRequest)]
    public async Task<FileContentResult> GetBaoCaoTienDo() {
        var fileNameTemplate = "Import_BaoCaoTienDo.xlsx";
        var templatePath = Path.Combine(
            AppContext.BaseDirectory, // ví dụ: ...\QLDA.WebApi
            "PrintTemplates", // chính xác tên folder trong project
            fileNameTemplate
        );

        var danhSachTenDuAn = await DuAn.GetQueryableSet().Where(e => !e.IsDeleted)
            .Select(e => new ComboData {
                Name = e.TenDuAn ?? string.Empty,
                Id = e.Id.ToString(),
            }).ToListAsync();

        var danhSachTenBuoc = await DuAnBuoc.GetQueryableSet().Where(e => !e.IsDeleted)
            .Select(e => new ComboData() {
                Id = e.Id.ToString(),
                ParentId = e.DuAnId.ToString(),
                Name = e.TenBuoc ?? e.Buoc!.Ten ?? string.Empty
            }).Distinct().ToListAsync();
        List<List<ComboData>> comboData = [
            danhSachTenDuAn,
            danhSachTenBuoc
        ];

        var importResult = _excelImporter.GetTemplate(templatePath, comboData);

        return new FileContentResult(importResult.FileBytes,
            importResult.ContentType) {
            FileDownloadName = fileNameTemplate
        };
    }
}