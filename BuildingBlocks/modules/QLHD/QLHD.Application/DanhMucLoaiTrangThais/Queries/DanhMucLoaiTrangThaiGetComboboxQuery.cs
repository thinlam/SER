namespace QLHD.Application.DanhMucLoaiTrangThais.Queries;

public record DanhMucLoaiTrangThaiGetComboboxQuery : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucLoaiTrangThaiGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiTrangThaiGetComboboxQuery, List<ComboBoxDto<int>>> {
    private readonly IRepository<DanhMucLoaiTrangThai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiTrangThai, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucLoaiTrangThaiGetComboboxQuery request, CancellationToken cancellationToken = default) {
        var query = _repository.GetQueryableSet()
            .OrderBy(e => e.Ma)
            .Select(e => new ComboBoxDto<int> {
                Id = e.Id,
                Ten = e.Ten ?? "",
                Ma = e.Ma
            });

        return await query.ToListAsync(cancellationToken);
    }
}