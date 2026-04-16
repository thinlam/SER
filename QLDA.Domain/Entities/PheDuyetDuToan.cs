using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Domain.Entities;

/// <summary>
/// Giai đoạn chuẩn bị đầu tư
/// </summary>
public class PheDuyetDuToan : VanBanQuyetDinh {
    public int? ChucVuId { get; set; }
    public long? GiaTriDuThau { get; set; }
    public DanhMucChucVu? ChucVu { get; set; }
}