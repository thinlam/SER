namespace QLDA.Application.DuAnBuocs.DTOs {
    public class DuAnBuocDuAnUpdateStateDto : IHasKey<int> {
        public int Id { get; set; }
        public int? TrangThaiId { get; set; }
        public DateTimeOffset? NgayDuKienBatDau { get; set; }
        public DateTimeOffset? NgayDuKienKetThuc { get; set; }
        public DateTimeOffset? NgayThucTeBatDau { get; set; }
        public DateTimeOffset? NgayThucTeKetThuc { get; set; }
        [DefaultValue(null)] public string? GhiChu { get; set; }
        [DefaultValue(null)] public string? TrachNhiemThucHien { get; set; }
        [DefaultValue(false)] public bool IsKetThuc { get; set; }
    }
}