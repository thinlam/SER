using System.ComponentModel.DataAnnotations;
using BuildingBlocks.Application.Attachments.DTOs;
using BuildingBlocks.Application.Common.Interfaces;

namespace QLHD.Application.HopDongs.DTOs;

public class HopDongUpdateModel : IMayHaveAttachmentInsertOrUpdateModel {
    public string? SoHopDong { get; set; }
    public string? Ten { get; set; }
    // DuAnId is not editable after insert - immutable
    [Required] public Guid KhachHangId { get; set; }
    [Required] public DateOnly NgayKy { get; set; }
    [Required] public int SoNgay { get; set; }
    [Required] public DateOnly NgayNghiemThu { get; set; }
    [Required] public int LoaiHopDongId { get; set; }
    [Required] public int TrangThaiHopDongId { get; set; }
    [Required] public int NguoiPhuTrachChinhId { get; set; }
    public int? NguoiTheoDoiId { get; set; }
    public int? GiamDocId { get; set; }
    public decimal GiaTri { get; set; }
    public decimal? TienThue { get; set; }
    public decimal? GiaTriSauThue { get; set; }
    [Required] public long PhongBanPhuTrachChinhId { get; set; }
    public decimal GiaTriBaoLanh { get; set; }
    public DateOnly? NgayBaoLanhTu { get; set; }
    public DateOnly? NgayBaoLanhDen { get; set; }
    public byte? ThoiHanBaoHanh { get; set; }
    public DateOnly? NgayBaoHanhTu { get; set; }
    public DateOnly? NgayBaoHanhDen { get; set; }
    public string? GhiChu { get; set; }
    public string? TienDo { get; set; }

    /// <summary>
    /// Danh sách ID phòng ban phối hợp (FK to DM_DONVI)
    /// </summary>
    public List<long>? PhongBanPhoiHopIds { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm
    /// </summary>
    public List<AttachmentInsertOrUpdateModel>? DanhSachTepDinhKem { get; set; }

    /// <summary>
    /// Danh sách tệp đính kèm (alias for IMayHaveAttachmentInsertOrUpdateModel)
    /// </summary>
    List<AttachmentInsertOrUpdateModel>? IMayHaveAttachmentInsertOrUpdateModel.DanhSachAttachment { get => DanhSachTepDinhKem; set => DanhSachTepDinhKem = value; }
}