namespace QLDA.Application.BaoCaoTienDos.DTOs;

public class BaoCaoTienDoImportDto {
    public string? TenDuAn { get; set; } 
    public string? TenBuoc { get; set; }
    public DateTimeOffset? NgayBaoCao { get; set; }
    public string? NoiDung { get; set; }
}