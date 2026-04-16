using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.DuToans.DTOs;

public class DuToanDto : IHasKey<Guid>, IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public Guid DuAnId { get; set; }
    /// <summary>
    /// Số dự toán
    /// </summary>
    public long SoDuToan { get; set; }
    /// <summary>
    /// Năm dự toán
    /// </summary>
    public int NamDuToan { get; set; }
    /// <summary>
    /// Số quyết định dự toán
    /// </summary>
    public string? SoQuyetDinhDuToan { get; set; }
    /// <summary>
    /// Ngày ký dự toán
    /// </summary>s
    public DateTimeOffset? NgayKyDuToan { get; set; }
    public string? GhiChu { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}