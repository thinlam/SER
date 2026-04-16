using QLHD.Application.DanhMucLoaiLais.DTOs;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Queries;

public record DanhMucLoaiLaiGetByIdQuery(int Id) : IRequest<DanhMucLoaiLaiDto>;

internal class DanhMucLoaiLaiGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DanhMucLoaiLaiGetByIdQuery, DanhMucLoaiLaiDto>
{
    private readonly IRepository<DanhMucLoaiLai, int> _repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();

    public async Task<DanhMucLoaiLaiDto> Handle(DanhMucLoaiLaiGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
            .Select(e => new DanhMucLoaiLaiDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                MoTa = e.MoTa,
                Used = e.Used,
                IsDefault = e.IsDefault
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new KeyNotFoundException($"Không tìm thấy bản ghi với ID: {request.Id}");

        return entity;
    }
}