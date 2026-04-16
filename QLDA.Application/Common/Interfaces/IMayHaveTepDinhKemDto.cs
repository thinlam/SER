using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.Common.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IMayHaveTepDinhKemDto {
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}
/// <summary>
/// Chỉ thêm file 
/// </summary>
public interface IMayHaveTepDinhKemInsertDto {
    public List<TepDinhKemInsertDto>? DanhSachTepDinhKem { get; set; }
}
/// <summary>
/// Thêm sửa xoá file </br>
/// - Thêm: id giá trị null hoặc default
/// - Sửa: có id
/// - Xoá: không gửi lại id từ danh sách đã trả về
/// </summary>
public interface IMayHaveTepDinhKemInsertOrUpdateDto {
    public List<TepDinhKemInsertOrUpdateDto>? DanhSachTepDinhKem { get; set; }
}