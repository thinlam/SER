using Microsoft.EntityFrameworkCore;
using QLDA.Application.Common;

namespace QLDA.Application.KeHoachLuaChonNhaThaus.Commands;

public record KeHoachLuaChonNhaThauDeleteCommand(Guid Id) : IRequest {
}

public record KeHoachLuaChonNhaThauDeleteCommandHandler : IRequestHandler<KeHoachLuaChonNhaThauDeleteCommand> {
    private readonly IRepository<KeHoachLuaChonNhaThau, Guid> KeHoachLuaChonNhaThau;
    private readonly IRepository<GoiThau, Guid> GoiThau;
    private readonly IRepository<QuyetDinhDuyetKHLCNT, Guid> QuyetDinhDuyetKHLCNT;
    private readonly IRepository<DangTaiKeHoachLcntLenMang, Guid> DangTaiKeHoachLcntLenMang;
    private readonly IRepository<TepDinhKem, Guid> TepDinhKem;
    private readonly IUnitOfWork _unitOfWork;

    public KeHoachLuaChonNhaThauDeleteCommandHandler(IServiceProvider serviceProvider) {
        KeHoachLuaChonNhaThau = serviceProvider.GetRequiredService<IRepository<KeHoachLuaChonNhaThau, Guid>>();
        GoiThau = serviceProvider.GetRequiredService<IRepository<GoiThau, Guid>>();
        QuyetDinhDuyetKHLCNT = serviceProvider.GetRequiredService<IRepository<QuyetDinhDuyetKHLCNT, Guid>>();
        DangTaiKeHoachLcntLenMang = serviceProvider.GetRequiredService<IRepository<DangTaiKeHoachLcntLenMang, Guid>>();
        TepDinhKem = serviceProvider.GetRequiredService<IRepository<TepDinhKem, Guid>>();
        _unitOfWork = KeHoachLuaChonNhaThau.UnitOfWork;
    }

    public async Task Handle(KeHoachLuaChonNhaThauDeleteCommand request, CancellationToken cancellationToken) {
        await ValidateAsync(request, cancellationToken);
        var entity = await KeHoachLuaChonNhaThau.GetOrderedSet()
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        ManagedException.ThrowIfNull(entity);

        await RemoveAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    #region  Private helper methods

    private async Task ValidateAsync(KeHoachLuaChonNhaThauDeleteCommand request, CancellationToken cancellationToken) {
        var hasGoiThau = await GoiThau.GetQueryableSet().AnyAsync(e => e.KeHoachLuaChonNhaThauId == request.Id && e.KeHoachLuaChonNhaThau != null && !e.KeHoachLuaChonNhaThau.IsDeleted, cancellationToken);
        var hasQuyetDinhDuyetKHLCNT = await QuyetDinhDuyetKHLCNT.GetQueryableSet().AnyAsync(e => e.KeHoachLuaChonNhaThauId == request.Id && e.KeHoachLuaChonNhaThau != null && !e.KeHoachLuaChonNhaThau.IsDeleted, cancellationToken);
        var hasDangTaiKeHoachLcntLenMang = await DangTaiKeHoachLcntLenMang.GetQueryableSet().AnyAsync(e => e.KeHoachLuaChonNhaThauId == request.Id && e.KeHoachLuaChonNhaThau != null && !e.KeHoachLuaChonNhaThau.IsDeleted, cancellationToken);

        ManagedException.ThrowIf(
            when: hasGoiThau,
            message: "Kế hoạch lựa chọn nhà thầu đã có gói thầu không thể xoá!"
        );
        ManagedException.ThrowIf(
            when: hasQuyetDinhDuyetKHLCNT,
            message: "Kế hoạch lựa chọn nhà thầu đã duyệt không thể xoá!"
        );
        ManagedException.ThrowIf(
            when: hasDangTaiKeHoachLcntLenMang,
            message: "Kế hoạch lựa chọn nhà thầu đã đăng tải lên mạng không thể xoá!"
        );
    }

    private async Task RemoveAsync(KeHoachLuaChonNhaThau entity, CancellationToken cancellationToken) {

        entity.IsDeleted = true;

        await SyncHelper.SetDeleteWithRelatedFiles(TepDinhKem, [entity.Id.ToString()], cancellationToken);
    }

    #endregion
}