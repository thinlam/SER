namespace QLHD.Domain.Interfaces;

public interface IDuToanKinhDoanNam {
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