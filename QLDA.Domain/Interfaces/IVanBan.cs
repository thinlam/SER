namespace QLDA.Domain.Interfaces;

public interface IVanBan : ITrichYeu {
    public string? SoVanBan { get; set; }
    public DateTimeOffset? NgayVanBan { get; set; }
}