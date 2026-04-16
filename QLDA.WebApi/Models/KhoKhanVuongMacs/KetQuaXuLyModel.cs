using QLDA.WebApi.Models.TepDinhKems;

namespace QLDA.WebApi.Models.KhoKhanVuongMacs;

public class KetQuaXuLyModel : IMayHaveTepDinhKemModel {
    /// <summary>
    /// Nội dung kết quả xử lý
    /// </summary>
    public string? KetQuaXuLy { get; set; }
    /// <summary>
    /// Ngày có kết quả xử lý
    /// </summary>
    public DateTimeOffset? NgayXuLy { get; set; }
    /// <summary>
    /// Danh sách tệp đính kèm
    /// </summary>

    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}