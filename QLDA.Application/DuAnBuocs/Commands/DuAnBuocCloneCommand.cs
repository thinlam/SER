using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QLDA.Application.DanhMucBuocs.DTOs;
using QLDA.Application.DuAnBuocs.Extensions;

namespace QLDA.Application.DuAnBuocs.Commands;

/// <summary>
/// Clone danh sách sách quy trình bước từ cây quy trình
/// </summary>
public record DuAnBuocCloneCommand(DuAn DuAn) : IRequest {
}

internal class DuAnBuocCloneCommandHandler : IRequestHandler<DuAnBuocCloneCommand> {
    private readonly IRepository<DuAnBuoc, int> DuAnBuoc;
    private readonly IRepository<DanhMucBuoc, int> DanhMucBuoc;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<DuAnBuocCloneCommandHandler> Logger;

    public DuAnBuocCloneCommandHandler(IServiceProvider serviceProvider) {
        DuAnBuoc = serviceProvider.GetRequiredService<IRepository<DuAnBuoc, int>>();
        DanhMucBuoc = serviceProvider.GetRequiredService<IRepository<DanhMucBuoc, int>>();
        UnitOfWork = DuAnBuoc.UnitOfWork;
        Logger = serviceProvider.GetRequiredService<ILogger<DuAnBuocCloneCommandHandler>>();
    }

    public async Task Handle(DuAnBuocCloneCommand request, CancellationToken cancellationToken) {

        if (UnitOfWork.HasTransaction) {
            await Clone(request, cancellationToken);
        } else {
            using var tx = await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            await Clone(request, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            await UnitOfWork.CommitTransactionAsync(cancellationToken);
        }




    }

    #region Private helper methods
    private async Task Clone(DuAnBuocCloneCommand request, CancellationToken cancellationToken = default) {
        if (request.DuAn.QuyTrinhId == null) {
            await DuAnBuoc.GetOrderedSet()
                .Where(e => e.DuAnId == request.DuAn.Id)
                .ExecuteDeleteAsync(cancellationToken);
            return;
        }

        var buocs = await DanhMucBuoc.GetOrderedSet()
            .AsNoTracking()
            .Where(e => !e.IsDeleted && e.Used)
            .Where(e => e.QuyTrinhId == request.DuAn.QuyTrinhId)
            .Include(b => b.BuocManHinhs)
            .Include(b => b.BuocTrangThaiTienDos)
            .ToListAsync(cancellationToken);

        if (buocs.Count == 0) return;



        var existing = await DuAnBuoc.GetQueryableSet()
            .Where(dab => dab.DuAnId == request.DuAn.Id)
            .ToListAsync(cancellationToken);


        var combinedMap = existing.ToDictionary(x => x.BuocId, x => x);

        /*
         * Số ngày thực hiện dự kiến mỗi bước
         * Là một trường quan trọng kết hợp với ngày bắt đầu NgayBatDau ở bảng DuAn để tính và thứ tự TreeList của bảng này
         * => tính ngày bắt đầu - kết thúc dự kiến trong dự án bước (DuAnBuoc)
         * Chú giải:
         * + bước đầu tiên ngày bắt đầu dự kiến là ngày bắt đầu dự kiến
         * + các bước tiếp theo, ngày bắt đầu dự kiến là ngày kết thúc dự kiến của bước trước đó cộng thêm 1 ngày
         * + ngày kết thúc bằng ngày dự kiến cộng ngày theo số ngày dự kiến
         * Lưu ý: Khi tính phải sắp xếp vị trí chúng dưới dạng TreeList - sắp xếp theo level, số thứ  tự
         * ==================================================================
         * Ví dụ dự án có ngày bắt đầu: 20/11
         * duAnBuoc thứ 1 (sau khi sắp xếp TreeList):
         * - duAnBuoc.ngayBatDauDuKien = duAn.ngayBatDau
         * - duAnBuoc.ngayKetThucDuKien = duAn.ngayBatDau.AddDays(dmBuoc.SoNgayThucHien)
         * duAnBuoc thứ n
         * - duAnBuoc.ngayBatDauDuKien = duAnBuoc[n-1].ngayKetThucDuKien.AddDays(1)
         * - duAnBuoc.ngayKetThucDuKien = duAn.ngayBatDau.AddDays(dmBuoc.SoNgayThucHien)
         */


        var toAdd = new List<DuAnBuoc>();
        var firstNode = true;

        var orderedSteps = buocs.ToSteps().ToTreeList();

        foreach (var step in orderedSteps) {
            var isUpdate = combinedMap.TryGetValue(step.Id, out var node);
            node ??= new DuAnBuoc {
                DuAnId = request.DuAn.Id,
                BuocId = step.BuocId ?? 0,
                TenBuoc = step.OriginalTen, // buoc.Ten có thêm ký tự rồi không dùng được
                PartialView = step.PartialView,
                Used = true,
                DuAnBuocManHinhs = step.BuocManHinhs?
                    .Select(m => new DuAnBuocManHinh { ManHinhId = m.ManHinhId, Stt = m.Stt })
                    .ToList(),
            };

            //Là node lá
            step.Path ??= "/";

            // Nếu path là "/", thì phải thêm điều kiện để phân biệt rõ node gốc với con
            var isLeaf = !orderedSteps.Any(e =>
                e.Path != null &&
                e.Path != step.Path &&
                e.Path.StartsWith(step.Path.EndsWith("/") ? step.Path : step.Path + "/")
            );
            if (isLeaf && request.DuAn.NgayBatDau != null) {
                var startDate = request.DuAn.NgayBatDau;
                var endDate = request.DuAn.NgayBatDau;
                node.NgayDuKienBatDau = firstNode ? startDate : endDate!.Value.AddDays(1);
                node.NgayDuKienKetThuc = node.NgayDuKienBatDau!.Value.AddDays(step.SoNgayThucHien == 0 ? 1 : step.SoNgayThucHien);
                ;
                endDate = node.NgayDuKienKetThuc.Value;
                firstNode = false;
            } else {
                node.NgayDuKienBatDau = null;
                node.NgayDuKienKetThuc = null;
            }

            if (!isUpdate)
                toAdd.Add(node);
        }

        if (toAdd.Count > 0)
            await DuAnBuoc.AddRangeAsync(toAdd, cancellationToken);

        //Xóa các bước không nằm trong dmBuoc
        var toRemove = existing
            .Where(dab => !buocs.Select(b => b.Id).Contains(dab.BuocId))
            .ToList();
        if (toRemove.Count > 0)
            DuAnBuoc.BulkDelete(toRemove);
    }
    #endregion
}