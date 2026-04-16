namespace QLDA.Domain.Entities.DanhMuc;
/// <summary>
/// Tổ chức danh mục nhà thầu
/// </summary>
public class DanhMucNhaThau : DanhMuc<Guid>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }
    public string? DiaChi { get; set; }
    public string? MaSoThue { get; set; }
    public string? Email { get; set; }
    public string? SoDienThoai { get; set; }
    public string? NguoiDaiDien { get; set; }

    #region Navigation Properties

    public List<HopDong>? HopDongs { get; set; } = [];
    public List<KetQuaTrungThau>? KetQuaTrungThaus { get; set; } = [];
    public List<BaoCaoBanGiaoSanPham>? BaoCaoBanGiaoSanPhams { get; set; } = [];
    public List<NhaThauNguoiDung>? NhaThauNguoiDungs { get; set; } = [];

    #endregion
}