using System.ComponentModel;

namespace QLHD.Application.KeHoachKinhDoanhNams.DTOs;

public class KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel
{
    /// <summary>
    /// If null or empty → Add new. If has value → Update existing.
    /// </summary>
    [DefaultValue("00000000-0000-0000-0000-000000000000")]
    public Guid? Id { get; set; }

    public long DonViId { get; set; }
    public decimal DoanhKySo { get; set; }
    public decimal LaiGopKy { get; set; }
    public decimal DoanhSoXuatHoaDon { get; set; }
    public decimal LaiGopXuatHoaDon { get; set; }
    public decimal ThuTien { get; set; }
    public decimal LaiGopThuTien { get; set; }
    public decimal ChiPhiTrucTiep { get; set; }
    public decimal ChiPhiPhanBo { get; set; }
    public decimal LoiNhuan { get; set; }
}