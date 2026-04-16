namespace QLDA.Application.QuyetDinhLapBanQLDAs.DTOs;

public class ThanhVienBanQldaDto : IHasKey<int?> {
    public int? Id { get; set; }
    public string? Ten { get; set; }
    public string? ChucVu { get; set; }
    public string? VaiTro { get; set; }
}