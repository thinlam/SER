using BuildingBlocks.Application.TepDinhKems.DTOs;

namespace BuildingBlocks.Application.Common.Interfaces;

/// <summary>
///
/// </summary>
public interface IMayHaveTepDinhKemDto
{
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}
/// <summary>
/// Chỉ thêm file
/// </summary>
public interface IMayHaveTepDinhKemInsertModel
{
    public List<TepDinhKemInsertModel>? DanhSachTepDinhKem { get; set; }
}
/// <summary>
/// Thêm sửa xoá file <br/>
/// - Thêm: id giá trị null hoặc default
/// - Sửa: có id
/// - Xoá: không gửi lại id từ danh sách đã trả về
/// </summary>
public interface IMayHaveTepDinhKemInsertOrUpdateModel
{
    public List<TepDinhKemInsertOrUpdateModel>? DanhSachTepDinhKem { get; set; }
}
