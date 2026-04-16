namespace QLDA.Domain.Entities;

/// <summary>
/// Tổng mức đầu tư theo nguồn vốn - tài liệu 1
/// Quyết định duyệt dự án lần đầu - tài liệu 2
/// </summary>
public class QuyetDinhDuyetDuAnHangMuc : Entity<int>, IAggregateRoot {
    public Guid QuyetDinhDuyetDuAnNguonVonId { get; set; }
    public string? TenHangMuc { get; set; }
    public string? QuyMoHangMuc { get; set; }
    public long? TongMucDauTu { get; set; }
    
    #region Navigation Properties

    public QuyetDinhDuyetDuAnNguonVon? QuyetDinhDuyetDuAnNguonVon { get; set; }

    #endregion
}