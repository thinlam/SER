namespace QLDA.Domain.Entities;

/// <summary>
/// Tổng mức đầu tư theo nguồn vốn - tài liệu 1
/// Quyết định duyệt dự án lần đầu - tài liệu 2
/// </summary>
public class QuyetDinhDuyetDuAnNguonVon : Entity<Guid>, IAggregateRoot {
    public Guid QuyetDinhDuyetDuAnId { get; set; }
    public int NguonVonId { get; set; }
    public long? GiaTri { get; set; }
    
    #region Navigation Properties

    public QuyetDinhDuyetDuAn? QuyetDinhDuyetDuAn { get; set; }
    public ICollection<QuyetDinhDuyetDuAnHangMuc>? QuyetDinhDuyetDuAnHangMucs { get; set; }

    #endregion
}