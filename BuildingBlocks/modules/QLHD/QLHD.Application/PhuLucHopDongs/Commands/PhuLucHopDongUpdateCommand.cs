using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.PhuLucHopDongs.Commands;

/// <summary>
/// Command cập nhật phụ lục hợp đồng
/// </summary>
public record PhuLucHopDongUpdateCommand(Guid Id, PhuLucHopDongInsertModel Model) : IRequest<PhuLucHopDongDto>;

internal class PhuLucHopDongUpdateCommandHandler : IRequestHandler<PhuLucHopDongUpdateCommand, PhuLucHopDongDto>
{
    private readonly IRepository<PhuLucHopDong, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PhuLucHopDongUpdateCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<PhuLucHopDongDto> Handle(PhuLucHopDongUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity, "Không tìm thấy phụ lục hợp đồng");

        entity.SoPhuLuc = request.Model.SoPhuLuc;
        entity.NgayKy = request.Model.NgayKy;
        entity.NoiDungPhuLuc = request.Model.NoiDungPhuLuc;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}