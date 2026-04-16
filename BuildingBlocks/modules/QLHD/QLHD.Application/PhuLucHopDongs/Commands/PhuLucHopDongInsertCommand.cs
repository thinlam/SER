using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.PhuLucHopDongs.Commands;

/// <summary>
/// Command thêm mới phụ lục hợp đồng
/// </summary>
public record PhuLucHopDongInsertCommand(PhuLucHopDongInsertModel Model) : IRequest<PhuLucHopDongDto>;

internal class PhuLucHopDongInsertCommandHandler : IRequestHandler<PhuLucHopDongInsertCommand, PhuLucHopDongDto>
{
    private readonly IRepository<PhuLucHopDong, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PhuLucHopDongInsertCommandHandler(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<PhuLucHopDongDto> Handle(PhuLucHopDongInsertCommand request, CancellationToken cancellationToken)
    {
        var entity = new PhuLucHopDong
        {
            HopDongId = request.Model.HopDongId,
            SoPhuLuc = request.Model.SoPhuLuc,
            NgayKy = request.Model.NgayKy,
            NoiDungPhuLuc = request.Model.NoiDungPhuLuc
        };

        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}