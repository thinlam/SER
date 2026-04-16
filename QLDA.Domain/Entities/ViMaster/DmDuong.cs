namespace QLDA.Domain.Entities.ViMaster;

public class DmDuong : IHasKey<long>, IAggregateRoot {
    public long Id { get; set; }

    public string? TenVietTat { get; set; }

    public string? TenDuong { get; set; }

    public string? MoTa { get; set; }

    public bool? Used { get; set; }
}