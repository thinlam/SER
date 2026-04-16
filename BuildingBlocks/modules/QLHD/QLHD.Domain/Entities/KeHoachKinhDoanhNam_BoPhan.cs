
using QLHD.Domain.Interfaces;

namespace QLHD.Domain.Entities;

public class KeHoachKinhDoanhNam_BoPhan : Entity<Guid>, IAggregateRoot, IDuToanKinhDoanNam {
    public Guid KeHoachKinhDoanhNamId { get; set; }
    public long DonViId { get; set; }
    public string Ten { get; set; } = string.Empty;
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
