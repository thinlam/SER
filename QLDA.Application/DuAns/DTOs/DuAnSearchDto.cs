using QLDA.Application.Common.Interfaces;

namespace QLDA.Application.DuAns.DTOs;

public record DuAnSearchDto : CommonSearchDto {
    ///<summary>
    /// Tên dự án       
    ///</summary>
    /// <example>Dự án</example>
    public string? TenDuAn { get; set; }
    ///<summary>
    /// Mã dự án
    ///</summary>
    /// <example>DA</example>
    public string? MaDuAn { get; set; }
    ///<summary>
    /// Lĩnh vực
    ///</summary>
    public int? LinhVucId { get; set; }
    ///<summary>
    /// Nguồn vốn
    ///</summary>
    public int? NguonVonId { get; set; }
    ///<summary>
    /// Nhóm dự án
    ///</summary>
    public int? NhomDuAnId { get; set; }
    ///<summary>
    /// Đơn vị phụ trách chính
    ///</summary>
    public long? DonViPhuTrachChinhId { get; set; }
    ///<summary>
    /// Đơn vị phối hợp 
    ///</summary>
    public long? DonViPhoiHopId { get; set; }
    ///<summary>
    /// Giai đoaạn thực hiện dự án
    ///</summary>
    public int? GiaiDoanId { get; set; }
    ///<summary>
    /// Năm khởi công
    ///</summary>
    public int? ThoiGianKhoiCong { get; set; }
    ///<summary>
    /// Năm hoàn thành
    ///</summary>
    public int? ThoiGianHoanThanh { get; set; }
    ///<summary>
    /// Lãnh đạo phụ trách - UserPortalId
    ///</summary>
    public long? LanhDaoPhuTrachId { get; set; }
    ///<summary>
    /// Mã ngân sách
    ///</summary>
    public string? MaNganSach { get; set; }
    ///<summary>
    /// Loại dự án
    ///</summary>
    public int? LoaiDuAnId { get; set; }
    ///<summary>
    /// Quy trình
    ///</summary>
    public int? QuyTrinhId { get; set; }
    ///<summary>
    /// Trạng thái dự án
    /// * Đang thực hiện 
    /// * Đã phê duyệt đầu tư 
    /// * Đã hoàn thành 
    /// * Tạm dừng
    ///</summary>
    public int? TrangThaiDuAnId { get; set; }

    /// Tìm theo loại thời gian là năm
    /// </summary>
    /// <remarks>
    /// Pmis #9121
    /// </remarks>
    public int? NamBatDau { get; set; }
    /// <summary>
    /// Năm dự án
    /// ThoiGianKhoiCong &lt;= NamDuAn &lt;= ThoiGianHoanThanh
    /// </summary>
    /// <remarks>
    /// Pmis #9121
    /// </remarks>
    public int? NamDuAn { get; set; }

    /// <summary>
    /// Loại dự án theo năm - tài chính
    /// * Chuẩn bị đầu tư
    /// * Chuyển tiếp 
    /// * Khởi công mới 
    /// * Khối lượng tồn đọng 
    /// </summary>
    /// <remarks>
    /// Pmis #9121
    /// </remarks>
    public int? LoaiDuAnTheoNamId { get; set; }
    /// <summary>
    /// Hình thức đầu tư
    /// </summary>
    /// <remarks>
    /// Pmis #9121
    /// </remarks>
    public int? HinhThucDauTuId { get; set; }
}