using QLHD.Application.TienDos.DTOs;

namespace QLHD.Application.TienDos.Commands;

public record TienDoUpdateCommand(Guid Id, TienDoUpdateModel Model) : IRequest<TienDoDto>;

internal class TienDoUpdateCommandHandler : IRequestHandler<TienDoUpdateCommand, TienDoDto> {
    private readonly IRepository<TienDo, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TienDoUpdateCommandHandler(IServiceProvider serviceProvider) {
        _repository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
        _unitOfWork = _repository.UnitOfWork;
    }

    public async Task<TienDoDto> Handle(TienDoUpdateCommand request, CancellationToken cancellationToken = default) {
        var entity = await _repository.GetQueryableSet()
            .Include(t => t.TrangThai)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy tiến độ");

        entity.UpdateFrom(request.Model);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}