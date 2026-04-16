namespace QLDA.Domain.Entities.ViMaster;

public class DmPhuongXa : IHasKey<long>, IAggregateRoot {
    public long Id { get; set; }

    public string? MaPhuongXa { get; set; }

    public string? TenPhuongXa { get; set; }

    public long? QuanHuyenId { get; set; }

    public string? MoTa { get; set; }

    public bool? Used { get; set; }
}