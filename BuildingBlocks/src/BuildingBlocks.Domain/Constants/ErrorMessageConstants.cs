namespace BuildingBlocks.Domain.Constants;

/// <summary>
/// Constants cho các thông báo lỗi trong hệ thống
/// </summary>
public static class ErrorMessageConstants
{


    public const string MissingParent = "Vui lòng nhập địa chỉ tham chiếu";
    public const string SelfReference = "Liên kết không hợp lệ";
    public const string CircleReference = "Liên kết không hợp lệ";
    public const string InternalServerError = "Lỗi hệ thống, vui lòng thử lại sau";

    /// <summary>
    /// Dữ liệu không tồn tại
    /// </summary>
    public const string DataNotFound = "Dữ liệu không tồn tại";

    /// <summary>
    /// Không có quyền truy cập
    /// </summary>
    public const string AccessDenied = "Không có quyền truy cập";

    /// <summary>
    /// Dữ liệu không hợp lệ
    /// </summary>
    public const string InvalidData = "Dữ liệu không hợp lệ";
    public const string EntityNotFound = "Không tìm thấy dữ liệu";
    public const string AlreadyLinked = "Dữ liệu đã được liên kết";
    public const string UnauthorizedAccess = "Truy cập không được phép";



    #region Business Validation Messages


    /// <summary>
    /// Yêu cầu đã được tiếp nhận
    /// </summary>
    public const string YeuCauDaTiepNhan = "Yêu cầu đã được tiếp nhận";


    /// <summary>
    /// Người dùng không có phòng ban không được phép tiếp nhận
    /// </summary>
    public const string NguoiDungKhongCoPhongBan = "Người dùng không có phòng ban không được phép tiếp nhận";

    /// <summary>
    /// Kiểu dữ liệu phải là số
    /// </summary>
    public const string KieuDuLieuPhaiLaSo = "Kiểu dữ liệu phải là số";

    /// <summary>
    /// Chỉ được phép cập nhật khi yêu cầu đang ở trạng thái 'Đang xử lý'
    /// </summary>
    public const string ChiDuocCapNhatKhiDangXuLy = "Chỉ được phép cập nhật khi yêu cầu đang ở trạng thái 'Đang xử lý'";

    /// <summary>
    /// Chỉ được phép xóa khi yêu cầu đang ở trạng thái 'Đang xử lý'
    /// </summary>
    public const string ChiDuocXoaKhiDangXuLy = "Chỉ được phép xóa khi yêu cầu đang ở trạng thái 'Đang xử lý'";

    public const string Unknown = "Không rõ";
    #endregion
}
