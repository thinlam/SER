namespace QLDA.Domain.Interfaces;

public interface IVanBanQuyetDinh {
    /// <summary>
    /// Số văn bản hoặc số quyết định
    /// </summary>
    public string? So { get; set; }
    /// <summary>
    /// Ngày văn bản hoặc ngày quyết định
    /// </summary>
    public DateTimeOffset? Ngay { get; set; }
    /// <summary>
    /// Trích yếu: Tóm tắt ngắn gọn nội dung chính của một văn bản, tài liệu.
    /// </summary>
    public string? TrichYeu { get; set; }
}