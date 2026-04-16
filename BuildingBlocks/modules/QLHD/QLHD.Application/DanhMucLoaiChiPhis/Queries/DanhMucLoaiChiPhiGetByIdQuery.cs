using QLHD.Application.DanhMucLoaiChiPhis.DTOs;

namespace QLHD.Application.DanhMucLoaiChiPhis.Queries;

public record DanhMucLoaiChiPhiGetByIdQuery(int Id) : IRequest<DanhMucLoaiChiPhiDto>;

internal class DanhMucLoaiChiPhiGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiChiPhiGetByIdQuery, DanhMucLoaiChiPhiDto>
{
    private readonly IRepository<DanhMucLoaiChiPhi, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();

    public async Task<DanhMucLoaiChiPhiDto> Handle(DanhMucLoaiChiPhiGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new DanhMucLoaiChiPhiDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                IsDefault = e.IsDefault,
                IsMajor = e.IsMajor
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return entity;
    }
}