using QLHD.Domain.Entities;

namespace QLHD.Application.PhuLucHopDongs.DTOs;

/// <summary>
/// Mapping cho phụ lục hợp đồng
/// </summary>
public static class PhuLucHopDongMapping
{
    /// <summary>
    /// Maps PhuLucHopDong entity to PhuLucHopDongDto
    /// </summary>
    public static PhuLucHopDongDto ToDto(this PhuLucHopDong entity)
    {
        return new PhuLucHopDongDto
        {
            Id = entity.Id,
            HopDongId = entity.HopDongId,
            SoPhuLuc = entity.SoPhuLuc,
            NgayKy = entity.NgayKy,
            NoiDungPhuLuc = entity.NoiDungPhuLuc
        };
    }

    /// <summary>
    /// Maps PhuLucHopDong entity to PhuLucHopDongSimpleDto (for HopDongDto)
    /// </summary>
    public static PhuLucHopDongSimpleDto ToSimpleDto(this PhuLucHopDong entity)
    {
        return new PhuLucHopDongSimpleDto
        {
            Id = entity.Id,
            SoPhuLuc = entity.SoPhuLuc,
            NgayKy = entity.NgayKy,
            NoiDungPhuLuc = entity.NoiDungPhuLuc
        };
    }
}