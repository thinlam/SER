namespace QLDA.Application.DanhMucBuocs.DTOs;

public class DanhMucBuocMaterializedDto {
    public DanhMucBuoc Entity { get; set; } = null!;
    /// <summary>
    /// Tổ tiên
    /// </summary>
    public List<DanhMucBuoc>? Ancestors { get; set; }
    
    /// <summary>
    /// Hậu duệ
    /// </summary>
    public List<DanhMucBuoc>? Descendants { get; set; }
}