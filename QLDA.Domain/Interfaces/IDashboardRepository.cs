using QLDA.Domain.DTOs;

namespace QLDA.Domain.Interfaces;

/// <summary>
/// Repository interface cho thống kê dashboard
/// </summary>
/// <remarks>
/// Tập trung logic truy vấn dashboard để đảm bảo consistency và dễ maintain
/// </remarks>
public interface IDashboardRepository {
    /// <summary>
    /// Lấy tất cả thống kê dashboard trong 1 lần query
    /// </summary>
    /// <param name="nam">Năm cần thống kê (bắt buộc)</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DashboardTongHopDto> GetTongHopAsync(int nam, CancellationToken cancellationToken = default);

    /// <summary>
    /// Đếm tổng số dự án trong năm
    /// </summary>
    Task<int> CountTongTheoNamAsync(int nam, CancellationToken cancellationToken = default);

    /// <summary>
    /// Đếm dự án theo loại (KCM/CT/TD)
    /// </summary>
    Task<int> CountByLoaiAsync(int nam, string ma, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lấy thống kê theo loại dự án
    /// </summary>
    Task<List<DashboardLoaiDuAnDto>> GetTheoLoaiAsync(int nam, string? ma = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lấy thống kê theo bước hiện tại
    /// </summary>
    Task<List<DashboardTheoBuocDto>> GetTheoBuocAsync(int nam, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lấy thống kê theo giai đoạn hiện tại
    /// </summary>
    Task<List<DashboardTheoGiaiDoanDto>> GetTheoGiaiDoanAsync(int nam, CancellationToken cancellationToken = default);
}