using QLHD.Application.DanhMucTrangThais.DTOs;

namespace QLHD.Application.DanhMucTrangThais.Queries;

public record DanhMucTrangThaiGetByIdQuery(int Id) : IRequest<DanhMucTrangThaiDto>;

internal class DanhMucTrangThaiGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucTrangThaiGetByIdQuery, DanhMucTrangThaiDto> {
    private readonly IRepository<DanhMucTrangThai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();

    public async Task<DanhMucTrangThaiDto> Handle(DanhMucTrangThaiGetByIdQuery request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetOriginalSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy trạng thái với ID: {request.Id}");

        return new DanhMucTrangThaiDto {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used,
            LoaiTrangThaiId = entity.LoaiTrangThaiId,
            MaLoaiTrangThai = entity.MaLoaiTrangThai,
            TenLoaiTrangThai = entity.TenLoaiTrangThai
        };
    }
}