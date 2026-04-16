namespace QLDA.Domain.Entities;

/// <summary>
/// Báo cáo bảo hành sẩn phẩm
/// <remarks>
/// CreatedBy = NguoiBaoCaoId: Người báo cáo là người tạo báo cáo
/// </remarks>
/// </summary>
public class BaoCaoBaoHanhSanPham : BaoCao {
    /// <summary>
    /// Lãnh đạo phụ trách báo cáo - UserMaster
    /// </summary>
    public long? LanhDaoPhuTrachId { get; set; }
}