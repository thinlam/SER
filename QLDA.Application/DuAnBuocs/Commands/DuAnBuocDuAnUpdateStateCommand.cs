using System.Data;
using Microsoft.EntityFrameworkCore;
using QLDA.Application.DuAnBuocs.DTOs;

namespace QLDA.Application.DuAnBuocs.Commands;

/// <summary>
/// Thêm mới bước hoặc cập nhật trạng thái của dự án
/// </summary>
/// <param name="Entity"></param>
public record DuAnBuocDuAnUpdateStateCommand(DuAnBuocDuAnUpdateStateDto Dto) : IRequest<DuAnBuoc>;

public record DuAnBuocDuAnUpdateStateCommandHandler : IRequestHandler<DuAnBuocDuAnUpdateStateCommand, DuAnBuoc> {
    private readonly IRepository<DuAnBuoc, int> DuAnBuoc;
    private readonly IUnitOfWork _unitOfWork;

    public DuAnBuocDuAnUpdateStateCommandHandler(IServiceProvider serviceProvider) {
        DuAnBuoc = serviceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();
        _unitOfWork = DuAnBuoc.UnitOfWork;
    }

    public async Task<DuAnBuoc> Handle(DuAnBuocDuAnUpdateStateCommand request, CancellationToken cancellationToken) {
        var entity = await DuAnBuoc.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Dto.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity);

        entity.UpdateState(request.Dto);

        if (_unitOfWork.HasTransaction) {
            await DuAnBuoc.UpdateAsync(entity, cancellationToken);
        } else {
            using var tx = await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await DuAnBuoc.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        return entity;
    }
}