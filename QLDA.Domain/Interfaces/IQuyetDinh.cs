namespace QLDA.Domain.Interfaces;

public interface IQuyetDinh {
    public string? SoQuyetDinh { get; set; }
    public DateTimeOffset? NgayQuyetDinh { get; set; }
    public string? TrichYeu { get; set; }
}
