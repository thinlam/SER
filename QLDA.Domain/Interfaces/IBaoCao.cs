namespace QLDA.Domain.Interfaces;

public interface IBaoCao {
    /// <summary>
    /// Ngày báo cáo
    /// </summary>
    public DateTimeOffset? Ngay { get; set; }
    /// <summary>
    /// Nội dung báo cáo
    /// </summary>
    public string? NoiDung { get; set; }
}