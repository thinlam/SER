namespace QLDA.Application.NhaThauNguoiDungs.DTOs;

/// <summary>
/// DTO for bulk insert/update NhaThauNguoiDung
/// </summary>
public class NhaThauNguoiDungSyncDto {
    public Guid NhaThauId { get; set; }
    public List<long> NguoiDungIds { get; set; } = [];
}
