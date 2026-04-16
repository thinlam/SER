using System.ComponentModel;
using QLDA.Domain.Interfaces;
using QLDA.WebApi.Models.TepDinhKems;
using SequentialGuid;

namespace QLDA.WebApi.Models.BaoCaoBanGiaoSanPhams;

public class BaoCaoBanGiaoSanPhamModel : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemModel, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; } 
    [System.Text.Json.Serialization.JsonIgnoreAttribute]
    public long? NguoiBaoCaoId { get; set; }
    public Guid? DonViBanGiaoId { get; set; }
    /// <summary>
    /// Danh mục đơn vị
    /// </summary>
    public long? DonViNhanBanGiaoId { get; set; }
    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}