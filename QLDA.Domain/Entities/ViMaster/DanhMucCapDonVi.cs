namespace QLDA.Domain.Entities.ViMaster;
/// <summary>
/// ECapDonVi
/// </summary>
public class DanhMucCapDonVi : IHasKey<long>, IAggregateRoot
{
    public long Id { get; set; }

    public string? TenCapDonVi { get; set; }

    public string? MoTa { get; set; }

    public int? ThuTuHienThi { get; set; }

    public bool? Used { get; set; }

    // public virtual ICollection<DanhMucChucVu> ChucVus { get; set; } = new List<DanhMucChucVu>();
}
