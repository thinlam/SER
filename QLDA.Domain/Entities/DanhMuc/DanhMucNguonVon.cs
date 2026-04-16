using System.Text.Json.Serialization;

namespace QLDA.Domain.Entities.DanhMuc;

public class DanhMucNguonVon : DanhMuc<int>, IAggregateRoot, IMayHaveStt {
    public int? Stt { get; set; }

    #region Navigation Properties
    [JsonIgnore]
    public ICollection<DuAnNguonVon>? DuAnNguonVons { get; set; } = [];
    [JsonIgnore]
    public ICollection<GoiThau>? GoiThaus { get; set; } = [];

    #endregion
}