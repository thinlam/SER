using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Domain.Entities;

/// <summary>
/// Báo cáo bàn giao sẩn phẩm
/// <remarks>
/// CreatedBy = NguoiBaoCaoId: Người báo cáo là người tạo báo cáo
/// </remarks>
/// </summary>
public class BaoCaoBanGiaoSanPham : BaoCao {
    /// <summary>
    /// Nhà thầu
    /// </summary>
    public Guid? DonViBanGiaoId { get; set; }

    /// <summary>
    /// Danh mục đơn vị
    /// </summary>
    public long? DonViNhanBanGiaoId { get; set; }

    #region Navigation Properties

    public DanhMucNhaThau? DonViBanGiao { get; set; }

    #endregion
}