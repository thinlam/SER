namespace QLDA.Domain.Entities.ViMaster;

public class CanBo : IHasKey<long>, IAggregateRoot {
    public long Id { get; set; }

    public string? NgheNghiep { get; set; }

    public string? MaSoCanBo { get; set; }

    public string? SoBhxh { get; set; }

    public long? ConNguoiId { get; set; }

    public string? ChuyenMon { get; set; }

    public long? ChucDanhId { get; set; }

    public virtual ICollection<CanBoDonVi> CanBoDonVis { get; set; } = new List<CanBoDonVi>();

    // public virtual DmChucdanh? ChucDanh { get; set; }

    // public virtual Connguoi? ConNguoi { get; set; }
}
