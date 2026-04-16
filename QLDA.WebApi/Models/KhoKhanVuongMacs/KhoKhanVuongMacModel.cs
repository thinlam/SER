using System.ComponentModel;
using QLDA.Domain.Interfaces;
using QLDA.WebApi.Models.TepDinhKems;
using SequentialGuid;

namespace QLDA.WebApi.Models.KhoKhanVuongMacs;

public class KhoKhanVuongMacModel : IHasKey<Guid?>, IMustHaveId<Guid>, IMayHaveTepDinhKemModel, ITienDo {
    /// <summary>
    /// Khoá chính
    /// </summary>
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid GetId() {
        Id ??= SequentialGuidGenerator.Instance.NewGuid();
        return (Guid)Id;
    }
    /// <summary>
    /// Dự án id - guid
    /// </summary>
    public Guid DuAnId { get; set; }
    /// <summary>
    /// Dự án bước id
    /// </summary>
    public int? BuocId { get; set; }
    /// <summary>
    /// Ngày báo cáo 
    /// </summary>
    public DateTimeOffset? Ngay { get; set; }
    /// <summary>
    /// Nội dung
    /// </summary>
    public string? NoiDung { get; set; } 
    /// <summary>
    /// Tình trạng
    /// </summary>
    public int? TinhTrangId { get; set; }
    /// <summary>
    /// Mức độ
    /// </summary>
    public int? MucDoKhoKhanId { get; set; }
    /// <summary>
    /// Hướng xử lý
    /// </summary>
    public string? HuongXuLy { get; set; }
    /// <summary>
    /// Kết quả xử lý
    /// </summary>
    public KetQuaXuLyModel? KetQua { get; set; }
    /// <summary>
    /// Danh sách tệp đính kèm
    /// </summary>
    public List<TepDinhKemModel>? DanhSachTepDinhKem { get; set; }
}