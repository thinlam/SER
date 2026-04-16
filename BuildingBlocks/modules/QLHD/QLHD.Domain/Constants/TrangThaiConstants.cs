namespace QLHD.Domain.Constants;

/// <summary>
/// Constants for DanhMucTrangThai (Status) - Mã trạng thái
/// </summary>
public static class TrangThaiConstants {
    #region Hợp đồng (HDONG) Statuses

    /// <summary>
    /// Đang thực hiện (Hợp đồng)
    /// </summary>
    public const string HopDongDangThucHien = "OPEN";

    /// <summary>
    /// Tạm dừng (Hợp đồng)
    /// </summary>
    public const string HopDongTamDung = "PENDING";

    /// <summary>
    /// Hủy (Hợp đồng)
    /// </summary>
    public const string HopDongHuy = "CANCEL";

    /// <summary>
    /// Nghiệm thu (Hợp đồng)
    /// </summary>
    public const string HopDongNghiemThu = "COMPLETE";

    /// <summary>
    /// Hoàn tất (Hợp đồng)
    /// </summary>
    public const string HopDongHoanTat = "CLOSED";

    /// <summary>
    /// Bảo trì (Hợp đồng)
    /// </summary>
    public const string HopDongBaoTri = "MAINTENANCE";

    #endregion

    #region Kế hoạch (KHOACH) Statuses

    /// <summary>
    /// Đang thực hiện (Kế hoạch)
    /// </summary>
    public const string KeHoachDangThucHien = "RUNNING";

    /// <summary>
    /// Theo dõi (Chưa rõ ràng) (Kế hoạch)
    /// </summary>
    public const string KeHoachTheoDoi = "WS.01";

    /// <summary>
    /// Hoàn tất (Kế hoạch)
    /// </summary>
    public const string KeHoachHoanTat = "SIGNED";

    /// <summary>
    /// Có chủ trương/có KH thực hiện (Kế hoạch)
    /// </summary>
    public const string KeHoachCoChuTruong = "WS03";

    /// <summary>
    /// Có QĐ phê duyệt (Kế hoạch)
    /// </summary>
    public const string KeHoachCoQuyetDinh = "WS05";

    /// <summary>
    /// Đấu thầu, đàm phán (Kế hoạch)
    /// </summary>
    public const string KeHoachDauThau = "WS06";

    /// <summary>
    /// Tạm dừng/Không thực hiện (Kế hoạch)
    /// </summary>
    public const string KeHoachTamDung = "WS07";

    /// <summary>
    /// Tái ký (Kế hoạch)
    /// </summary>
    public const string KeHoachTaiKy = "TK";

    /// <summary>
    /// Nghiệm thu (Kế hoạch)
    /// </summary>
    public const string KeHoachNghiemThu = "DONE";

    #endregion

    #region Cuộc họp (CHOP) Statuses

    /// <summary>
    /// Chưa diễn ra (Cuộc họp)
    /// </summary>
    public const string CuocHopChuaDienRa = "OPEN";

    /// <summary>
    /// Chưa duyệt (Cuộc họp)
    /// </summary>
    public const string CuocHopChuaDuyet = "WAITING";

    /// <summary>
    /// Đã kết thúc (Cuộc họp)
    /// </summary>
    public const string CuocHopDaKetThuc = "CLOSED";

    /// <summary>
    /// Đang diễn ra (Cuộc họp)
    /// </summary>
    public const string CuocHopDangDienRa = "GOINGON";

    /// <summary>
    /// Hủy (Cuộc họp)
    /// </summary>
    public const string CuocHopHuy = "CANCEL";

    /// <summary>
    /// Tạm hoãn (Cuộc họp)
    /// </summary>

    public const string CuocHopTamHoan = "PENDING";

    #endregion
}