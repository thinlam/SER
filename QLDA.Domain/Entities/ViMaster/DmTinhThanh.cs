namespace QLDA.Domain.Entities.ViMaster;

public class DmTinhThanh : IHasKey<long>, IAggregateRoot {
    public long Id { get; set; }

    public long QuocGiaId { get; set; }

    public string? MaTinhThanh { get; set; }

    public string? TenTinhThanh { get; set; }

    public string? MoTa { get; set; }

    public bool? Used { get; set; }
}