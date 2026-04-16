using QLDA.WebApi.Models.TepDinhKems;

namespace QLDA.WebApi.Models.Common.Interfaces;

public interface IMayHaveTepDinhKemModel {
    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}