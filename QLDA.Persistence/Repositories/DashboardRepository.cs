using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLDA.Domain.DTOs;
using QLDA.Domain.Enums;
using QLDA.Domain.Interfaces;

namespace QLDA.Persistence.Repositories;

/// <summary>
/// Repository implementation cho thống kê dashboard
/// </summary>
/// <remarks>
/// Tập trung logic truy vấn dashboard để đảm bảo consistency và dễ maintain.
/// Mọi thay đổi về filter chỉ cần sửa ở đây, tất cả query sẽ đồng bộ.
/// </remarks>
public class DashboardRepository : IDashboardRepository {
    private readonly IRepository<DuAn, Guid> _duAn;

    public DashboardRepository(IServiceProvider serviceProvider) {
        _duAn = serviceProvider.GetRequiredService<IRepository<DuAn, Guid>>();
    }

    /// <summary>
    /// Base query cho dashboard - lọc dự án theo năm
    /// </summary>
    /// <remarks>
    /// Logic: ThoiGianKhoiCong <= Nam <= ThoiGianHoanThanh
    /// </remarks>
    private IQueryable<DuAn> BaseQuery(int nam) {
        return _duAn.GetQueryableSet()
            .AsNoTracking()
            .Where(e => !e.IsDeleted)
            .Where(e => e.ThoiGianKhoiCong <= nam && e.ThoiGianHoanThanh >= nam);
    }

    public async Task<DashboardTongHopDto> GetTongHopAsync(int nam, CancellationToken cancellationToken = default) {
        // Single query với all includes
        var duAnData = await BaseQuery(nam)
            .Include(e => e.LoaiDuAnTheoNam)
            .Include(e => e.BuocHienTai)
            .Include(e => e.GiaiDoanHienTai)
            .Select(e => new DuAnDashboardProjection {
                LoaiDuAnTheoNamMa = e.LoaiDuAnTheoNam != null ? e.LoaiDuAnTheoNam.Ma : null,
                LoaiDuAnTheoNamId = e.LoaiDuAnTheoNamId,
                LoaiDuAnTheoNamTen = e.LoaiDuAnTheoNam != null ? e.LoaiDuAnTheoNam.Ten : null,
                BuocHienTaiId = e.BuocHienTaiId,
                TenBuoc = e.BuocHienTai != null ? e.BuocHienTai.TenBuoc : null,
                GiaiDoanHienTaiId = e.GiaiDoanHienTaiId,
                TenGiaiDoan = e.GiaiDoanHienTai != null ? e.GiaiDoanHienTai.Ten : null
            })
            .ToListAsync(cancellationToken);

        // In-memory grouping
        return new DashboardTongHopDto {
            Nam = nam,
            TongSoDuAn = duAnData.Count,
            SoKhoiCongMoi = duAnData.Count(e => e.LoaiDuAnTheoNamMa == EnumLoaiDuAnTheoNam.KCM.ToString()),
            SoChuyenTiep = duAnData.Count(e => e.LoaiDuAnTheoNamMa == EnumLoaiDuAnTheoNam.CT.ToString()),
            SoTonDong = duAnData.Count(e => e.LoaiDuAnTheoNamMa == EnumLoaiDuAnTheoNam.TD.ToString()),
            TheoLoai = [.. duAnData
                .Where(e => e.LoaiDuAnTheoNamId.HasValue)
                .GroupBy(e => new { e.LoaiDuAnTheoNamId, e.LoaiDuAnTheoNamMa, e.LoaiDuAnTheoNamTen })
                .Select(g => new DashboardLoaiDuAnDto {
                    Nam = nam,
                    LoaiDuAnTheoNamId = g.Key.LoaiDuAnTheoNamId,
                    Ma = g.Key.LoaiDuAnTheoNamMa,
                    Ten = g.Key.LoaiDuAnTheoNamTen,
                    SoLuong = g.Count()
                })],
            TheoBuoc = [.. duAnData
                .Where(e => e.BuocHienTaiId.HasValue)
                .GroupBy(e => new { e.BuocHienTaiId, e.TenBuoc })
                .Select(g => new DashboardTheoBuocDto {
                    BuocId = g.Key.BuocHienTaiId,
                    TenBuoc = g.Key.TenBuoc,
                    SoLuong = g.Count()
                })
                .OrderBy(e => e.BuocId)],
            TheoGiaiDoan = [.. duAnData
                .Where(e => e.GiaiDoanHienTaiId.HasValue)
                .GroupBy(e => new { e.GiaiDoanHienTaiId, e.TenGiaiDoan })
                .Select(g => new DashboardTheoGiaiDoanDto {
                    GiaiDoanId = g.Key.GiaiDoanHienTaiId,
                    TenGiaiDoan = g.Key.TenGiaiDoan,
                    SoLuong = g.Count()
                })
                .OrderBy(e => e.GiaiDoanId)]
        };
    }

    public async Task<int> CountTongTheoNamAsync(int nam, CancellationToken cancellationToken = default) {
        return await BaseQuery(nam).CountAsync(cancellationToken);
    }

    public async Task<int> CountByLoaiAsync(int nam, string ma, CancellationToken cancellationToken = default) {
        return await BaseQuery(nam)
            .Include(e => e.LoaiDuAnTheoNam)
            .Where(e => e.LoaiDuAnTheoNam != null && e.LoaiDuAnTheoNam.Ma == ma)
            .CountAsync(cancellationToken);
    }

    public async Task<List<DashboardLoaiDuAnDto>> GetTheoLoaiAsync(int nam, string? ma = null, CancellationToken cancellationToken = default) {
        var query = BaseQuery(nam).Include(e => e.LoaiDuAnTheoNam);

        if (!string.IsNullOrEmpty(ma)) {
            return await query
                .Where(e => e.LoaiDuAnTheoNam != null && e.LoaiDuAnTheoNam.Ma == ma)
                .GroupBy(e => new { e.LoaiDuAnTheoNamId, e.LoaiDuAnTheoNam!.Ma, e.LoaiDuAnTheoNam.Ten })
                .Select(g => new DashboardLoaiDuAnDto {
                    Nam = nam,
                    LoaiDuAnTheoNamId = g.Key.LoaiDuAnTheoNamId,
                    Ma = g.Key.Ma,
                    Ten = g.Key.Ten,
                    SoLuong = g.Count()
                })
                .ToListAsync(cancellationToken);
        }

        return await query
            .GroupBy(e => new { e.LoaiDuAnTheoNamId, e.LoaiDuAnTheoNam!.Ma, e.LoaiDuAnTheoNam.Ten })
            .Select(g => new DashboardLoaiDuAnDto {
                Nam = nam,
                LoaiDuAnTheoNamId = g.Key.LoaiDuAnTheoNamId,
                Ma = g.Key.Ma,
                Ten = g.Key.Ten,
                SoLuong = g.Count()
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<List<DashboardTheoBuocDto>> GetTheoBuocAsync(int nam, CancellationToken cancellationToken = default) {
        return await BaseQuery(nam)
            .Include(e => e.BuocHienTai)
            .Where(e => e.BuocHienTaiId.HasValue)
            .GroupBy(e => new { BuocId = e.BuocHienTaiId!.Value, e.BuocHienTai!.TenBuoc })
            .Select(g => new DashboardTheoBuocDto {
                BuocId = g.Key.BuocId,
                TenBuoc = g.Key.TenBuoc,
                SoLuong = g.Count()
            })
            .OrderBy(e => e.BuocId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<DashboardTheoGiaiDoanDto>> GetTheoGiaiDoanAsync(int nam, CancellationToken cancellationToken = default) {
        return await BaseQuery(nam)
            .Include(e => e.GiaiDoanHienTai)
            .Where(e => e.GiaiDoanHienTaiId.HasValue)
            .GroupBy(e => new { GiaiDoanId = e.GiaiDoanHienTaiId!.Value, e.GiaiDoanHienTai!.Ten })
            .Select(g => new DashboardTheoGiaiDoanDto {
                GiaiDoanId = g.Key.GiaiDoanId,
                TenGiaiDoan = g.Key.Ten,
                SoLuong = g.Count()
            })
            .OrderBy(e => e.GiaiDoanId)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Projection class for dashboard query results
    /// </summary>
    private class DuAnDashboardProjection {
        public string? LoaiDuAnTheoNamMa { get; set; }
        public int? LoaiDuAnTheoNamId { get; set; }
        public string? LoaiDuAnTheoNamTen { get; set; }
        public int? BuocHienTaiId { get; set; }
        public string? TenBuoc { get; set; }
        public int? GiaiDoanHienTaiId { get; set; }
        public string? TenGiaiDoan { get; set; }
    }
}