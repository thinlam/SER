namespace QLHD.Application.DanhMucTrangThais.Queries;

public record DanhMucTrangThaiGetComboboxQuery(int? LoaiTrangThaiId = null, string? MaLoaiTrangThai = null) : IRequest<List<ComboBoxDto<int>>>;

internal class DanhMucTrangThaiGetComboboxQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucTrangThaiGetComboboxQuery, List<ComboBoxDto<int>>> {
    private readonly IRepository<DanhMucTrangThai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();

    public async Task<List<ComboBoxDto<int>>> Handle(DanhMucTrangThaiGetComboboxQuery request, CancellationToken cancellationToken = default) {
        var query = _repository.GetQueryableSet()
            .WhereIf(request.LoaiTrangThaiId.HasValue, e => !request.LoaiTrangThaiId.HasValue || e.LoaiTrangThaiId == request.LoaiTrangThaiId)
            .WhereIf(!string.IsNullOrEmpty(request.MaLoaiTrangThai), e => e.MaLoaiTrangThai == request.MaLoaiTrangThai)
            .OrderBy(e => e.Ma)
            .Select(e => new ComboBoxDto<int> {
                Id = e.Id,
                Ten = e.Ten ?? "",
                Ma = e.Ma
            });

        return await query.ToListAsync(cancellationToken);
    }
}