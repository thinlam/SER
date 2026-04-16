using BuildingBlocks.Application.Attachments.DTOs;
using BuildingBlocks.Application.Common.Interfaces;
using QLHD.Application.PhuLucHopDongs.DTOs;

namespace QLHD.Application.HopDongs.DTOs;

public class HopDongDto : IHasKey<Guid>, IMayHaveAttachmentDto {
    public Guid Id { get; set; }
    public string? SoHopDong { get; set; }
    public string? Ten { get; set; }
    public Guid? DuAnId { get; set; }
    public Guid KhachHangId { get; set; }
    public DateOnly NgayKy { get; set; }
    public int SoNgay { get; set; }
    public DateOnly NgayNghiemThu { get; set; }
    public int LoaiHopDongId { get; set; }
    public int TrangThaiHopDongId { get; set; }
    public int NguoiPhuTrachChinhId { get; set; }
    public int? NguoiTheoDoiId { get; set; }
    public int? GiamDocId { get; set; }
    public decimal GiaTri { get; set; }
    public decimal? TienThue { get; set; }
    public decimal? GiaTriSauThue { get; set; }
    public long? PhongBanPhuTrachChinhId { get; set; }
    public decimal GiaTriBaoLanh { get; set; }
    public DateOnly? NgayBaoLanhTu { get; set; }
    public DateOnly? NgayBaoLanhDen { get; set; }
    public byte ThoiHanBaoHanh { get; set; }
    public DateOnly? NgayBaoHanhTu { get; set; }
    public DateOnly? NgayBaoHanhDen { get; set; }
    public string? GhiChu { get; set; }
    public string? TienDo { get; set; }

    // Navigation names for display
    public string? TenKhachHang { get; set; }
    public string? TenDuAn { get; set; }
    public string? TenLoaiHopDong { get; set; }
    public string? TenTrangThai { get; set; }
    public string? TenNguoiPhuTrach { get; set; }
    public string? TenNguoiTheoDoi { get; set; }
    public string? TenGiamDoc { get; set; }
    public string? TenPhongBan { get; set; }

    /// <summary>
    /// Danh sách ID phòng ban phối hợp
    /// </summary>
    public List<long>? PhongBanPhoiHopIds { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm
    /// </summary>
    public List<AttachmentDto>? DanhSachTepDinhKem { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm (alias for IMayHaveAttachmentDto)
    /// </summary>
    List<AttachmentDto>? IMayHaveAttachmentDto.DanhSachAttachment { get => DanhSachTepDinhKem; set => DanhSachTepDinhKem = value; }

    /// <summary>
    /// Danh sách thu tiền (gộp kế hoạch + thực tế) - standalone contracts only
    /// </summary>
    public List<HopDong_ThuTienSimpleDto>? HopDong_ThuTiens { get; set; }

    /// <summary>
    /// Danh sách xuất hóa đơn (gộp kế hoạch + thực tế) - standalone contracts only
    /// </summary>
    public List<HopDong_XuatHoaDonSimpleDto>? HopDong_XuatHoaDons { get; set; }

    /// <summary>
    /// Danh sách phụ lục hợp đồng
    /// </summary>
    public List<PhuLucHopDongSimpleDto>? PhuLucHopDongs { get; set; }

    #region Computed Financial Summary Fields

    /// <summary>
    /// Tổng chi phí = Sum(HopDong_ChiPhi.GiaTriKeHoach)
    /// </summary>
    public decimal TongChiPhi { get; set; }

    /// <summary>
    /// Phần trăm lợi nhuận = 100 - Sum(HopDong_ChiPhi.PhanTramKeHoach)
    /// </summary>
    public decimal PhanTramLoiNhuan { get; set; }

    /// <summary>
    /// Lợi nhuận trước thuế = HopDong.GiaTri - TongChiPhi
    /// </summary>
    public decimal LoiNhuanTruocThue { get; set; }

    /// <summary>
    /// Tổng tiền đã thu:
    /// - Nếu DuAnId == null: Sum(HopDong_ThuTien.GiaTriThucTe)
    /// - Nếu DuAnId != null: Sum(DuAn_ThuTien.GiaTriThucTe) for that DuAn
    /// </summary>
    public decimal TongTienDaThu { get; set; }


    #endregion
}