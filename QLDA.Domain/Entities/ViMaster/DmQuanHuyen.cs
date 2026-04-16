namespace QLDA.Domain.Entities.ViMaster;

public class DmQuanHuyen : IHasKey<long>, IAggregateRoot {
    public long Id { get; set; }

    public string? MaQuanHuyen { get; set; }

    public string? TenQuanHuyen { get; set; }

    public long? TinhThanhId { get; set; }

    public string? MoTa { get; set; }

    public bool? Used { get; set; }
}