namespace QLDA.Application.NhaThauNguoiDungs.DTOs;

public class NhaThauNguoiDungDto {
    public int Id { get; set; }
    public Guid NhaThauId { get; set; }
    public long NguoiDungId { get; set; }
    public string? TenNguoiDung { get; set; }
    public string? UserName { get; set; }
}
