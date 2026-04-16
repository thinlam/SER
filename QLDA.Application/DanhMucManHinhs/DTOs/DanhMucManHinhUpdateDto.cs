namespace QLDA.Application.DanhMucManHinhs.DTOs;

public class DanhMucManHinhUpdateDto : IHasKey<int> {
    public int Id { get; set; }
    public string? Ten { get; set; }
    public string? Label { get; set; }
    public string? Title { get; set; }
    public bool Used { get; set; }
}