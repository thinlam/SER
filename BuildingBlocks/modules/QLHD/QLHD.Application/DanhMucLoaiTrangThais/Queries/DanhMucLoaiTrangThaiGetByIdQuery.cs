using QLHD.Application.DanhMucLoaiTrangThais.DTOs;

namespace QLHD.Application.DanhMucLoaiTrangThais.Queries;

public record DanhMucLoaiTrangThaiGetByIdQuery(int Id) : IRequest<DanhMucLoaiTrangThaiDto>;

internal class DanhMucLoaiTrangThaiGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiTrangThaiGetByIdQuery, DanhMucLoaiTrangThaiDto> {
    private readonly IRepository<DanhMucLoaiTrangThai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiTrangThai, int>>();

    public async Task<DanhMucLoaiTrangThaiDto> Handle(DanhMucLoaiTrangThaiGetByIdQuery request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetOriginalSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new ManagedException($"Không tìm thấy loại trạng thái với ID: {request.Id}");

        return new DanhMucLoaiTrangThaiDto {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            MoTa = entity.MoTa,
            Used = entity.Used
        };
    }
}