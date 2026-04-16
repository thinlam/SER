namespace QLDA.Domain.Entities.ViMaster;
/// <summary>
/// EVaiTroChucVu
/// </summary>
public class DanhMucVaiTroChucVu : IHasKey<int>, IAggregateRoot {
    public int Id { get; set; }
    public string? ChucVu { get; set; }

    public int? Cap { get; set; }

    public bool? Used { get; set; }
    public string? MoTa { get; set; }
}
