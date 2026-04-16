namespace QLDA.WebApi.Models.QuyetDinhLapBanQLDAs;

public class ThanhVienBanQldaModel : IHasKey<int?> {
    public int? Id { get; set; }
    public string? Ten { get; set; }
    public string? ChucVu { get; set; }
    public string? VaiTro { get; set; }
}