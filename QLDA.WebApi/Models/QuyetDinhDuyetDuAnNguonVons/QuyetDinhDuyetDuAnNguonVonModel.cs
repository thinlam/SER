using System.ComponentModel;
using SequentialGuid;

namespace QLDA.WebApi.Models.QuyetDinhDuyetDuAnNguonVons;
/// <summary>
/// QuyetDinhDuyetDuAnNguonVon
/// </summary>

public class QuyetDinhDuyetDuAnNguonVonModel : IHasKey<Guid?> {
    [DefaultValue(null)] public Guid? Id { get; set; }

    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    public int NguonVonId { get; set; }
    public long? GiaTri { get; set; }
}