namespace QLHD.Application.PhuLucHopDongs.DTOs;

/// <summary>
/// DTO đơn giản cho phụ lục hợp đồng (dùng trong HopDongDto)
/// </summary>
public class PhuLucHopDongSimpleDto : IHasKey<Guid>
{
    public Guid Id { get; set; }
    public string SoPhuLuc { get; set; } = string.Empty;
    public DateOnly NgayKy { get; set; }
    public string? NoiDungPhuLuc { get; set; }
}