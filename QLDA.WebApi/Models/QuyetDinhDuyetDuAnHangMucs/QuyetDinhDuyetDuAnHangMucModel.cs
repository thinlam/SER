using System.ComponentModel;

namespace QLDA.WebApi.Models.QuyetDinhDuyetDuAnHangMucs;

/// <summary>
/// QuyetDinhDuyetDuAnHangMuc
/// </summary>
public class QuyetDinhDuyetDuAnHangMucModel : IHasKey<int?> {
    public int? Id { get; set; }
    [DefaultValue(null)] public Guid? QuyetDinhDuyetDuAnNguonVonId { get; set; }
    public int NguonVonId { get; set; }
    public string? TenHangMuc { get; set; }
    public string? QuyMoHangMuc { get; set; }
    public long? TongMucDauTu { get; set; }
}