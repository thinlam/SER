namespace QLHD.Tests.Integration.Infrastructure.Fakers;

/// <summary>
/// Reference IDs from TestDataSeeder - used for FK relationships.
/// MUST match TestDataSeeder.cs seed values exactly.
/// </summary>
public static class FKReferenceData {
    // DanhMucLoaiHopDong (from TestDataSeeder lines 86-101)
    public const int LoaiHopDongDV = 1;  // Ma = "DV", Ten = "Dịch vụ"
    public const int LoaiHopDongKH = 2;  // Ma = "KH", Ten = "Ký gửi"

    // DanhMucLoaiChiPhi (from TestDataSeeder lines 205-224)
    public const int LoaiChiPhiNhanSu = 1;  // Ma = "CP001", IsDefault = true
    public const int LoaiChiPhiVatTu = 2;   // Ma = "CP002"

    // DanhMucLoaiThanhToan (from DanhMucLoaiThanhToanSeedData)
    public const int LoaiThanhToanDoan1 = 1; // Ma = "TT01", Ten = "Thanh toán đợt 1", IsDefault = true
    public const int LoaiThanhToanDoan2 = 2; // Ma = "TT02", Ten = "Thanh toán đợt 2"
    public const int LoaiThanhToanTamUng = 3; // Ma = "TU", Ten = "Tạm ứng"

    // Legacy aliases (for backward compatibility)
    public const int LoaiThanhToanThang = LoaiThanhToanDoan1;
    public const int LoaiThanhToanQuy = LoaiThanhToanDoan2;

    // DanhMucTrangThai (from TestDataSeeder lines 42-79) - LoaiTrangThai = "HOP_DONG"
    public const int TrangThaiMoi = 1;           // Ma = "MOI", IsDefault = true
    public const int TrangThaiDangThucHien = 2;  // Ma = "DANG_THUC_HIEN"
    public const int TrangThaiHoanThanh = 3;     // Ma = "HOAN_THANH"

    // DanhMucNguoiPhuTrach (from TestDataSeeder lines 160-168)
    public const int NguoiPhuTrachId = 1; // Ma = "NPT001"

    // DanhMucNguoiTheoDoi (from TestDataSeeder lines 174-184)
    public const int NguoiTheoDoiId = 1; // Ma = "NTD001"

    // DanhMucGiamDoc (from TestDataSeeder lines 188-199)
    public const int GiamDocId = 1; // Ma = "GD001"

    // KhachHang (from TestDataSeeder lines 144-154)
    public static readonly Guid KhachHangId = Guid.Parse("00000000-0000-0000-0000-000000000001");

    // DoanhNghiep (from TestDataSeeder lines 132-138)
    public static readonly Guid DoanhNghiepId = Guid.Parse("00000000-0000-0000-0000-000000000002");

    // DuAn (from SeedDataGuids.cs - matches DuAnSeedData)
    public static readonly Guid DuAnId = Guid.Parse("08DE8B11-66A0-889C-687A-7B2360037372"); // DuAn_20260326_06

    // DanhMucTrangThai for CongViec (LoaiTrangThai = KEHOACH)
    public const int TrangThaiKeHoachId = 5; // Ma = "CHO_XU_LY", IsDefault for KEHOACH

    // DmDonVi (legacy table - common IDs)
    public const long DonViId = 49; // Trung tâm Chuyển đổi số - TPHCM
    public const long PhongBanId = 220; // Phòng Hạ tầng số và An toàn thông tin
    public static readonly Guid HopDongId = Guid.Parse("08DE8AE2-8EB5-87C9-4BAF-8361500292E3");

}