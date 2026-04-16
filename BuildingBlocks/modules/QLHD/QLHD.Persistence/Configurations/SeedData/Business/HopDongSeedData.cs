using static QLHD.Persistence.Configurations.SeedData.SeedDataGuids;

namespace QLHD.Persistence.Configurations.SeedData.Business;

/// <summary>
/// Seed data extension for HopDong entity.
/// Uses centralized GUIDs from SeedDataGuids.cs to prevent FK mismatches.
/// </summary>
public static class HopDongSeedData
{
    // Aliases for readability (mapping to centralized GUIDs)
    private static readonly Guid HopDong1 = HopDong_01;
    private static readonly Guid HopDong2 = HopDong_02;
    private static readonly Guid HopDong3 = HopDong_03;
    private static readonly Guid HopDong4 = HopDong_04;
    private static readonly Guid HopDong5 = HopDong_05;
    private static readonly Guid HopDong6 = HopDong_06;
    private static readonly Guid HopDong7 = HopDong_07;
    private static readonly Guid HopDong8 = HopDong_08;
    private static readonly Guid HopDong9 = HopDong_09;

    // DuAn IDs (from centralized GUIDs)
    // IMPORTANT: HopDong-DuAn is one-to-one! Each DuAn can only have ONE HopDong.
    private static readonly Guid? DuAnForHopDong1 = DuAn_20260326_05;  // DuAn5
    private static readonly Guid? DuAnForHopDong2 = DuAn_20260330_01;  // DuAn15
    private static readonly Guid? DuAnForHopDong3 = null;              // Standalone contract
    private static readonly Guid? DuAnForHopDong4 = DuAn_20260327_08;  // DuAn14
    private static readonly Guid? DuAnForHopDong5 = DuAn_20260327_07;  // DuAn13
    private static readonly Guid? DuAnForHopDong6 = DuAn_20260327_03;  // DuAn9
    private static readonly Guid? DuAnForHopDong7 = null;              // Standalone contract (was duplicate DuAn15)
    private static readonly Guid? DuAnForHopDong8 = null;              // Standalone contract (was duplicate DuAn2)
    private static readonly Guid? DuAnForHopDong9 = DuAn_20260326_01;  // DuAn1

    // KhachHang IDs (from centralized GUIDs)
    private static readonly Guid KhachHang1 = KhachHang_01;

    // Timestamps
    private static readonly DateTimeOffset Created1 = new(2026, 3, 26, 4, 5, 52, 779, TimeSpan.Zero);
    private static readonly DateTimeOffset Created2 = new(2026, 3, 30, 8, 12, 16, 779, TimeSpan.Zero);
    private static readonly DateTimeOffset Created3 = new(2026, 3, 30, 8, 14, 1, 86, TimeSpan.Zero);
    private static readonly DateTimeOffset Created4 = new(2026, 3, 27, 2, 33, 31, 184, TimeSpan.Zero);
    private static readonly DateTimeOffset Created5 = new(2026, 3, 27, 2, 38, 26, 440, TimeSpan.Zero);
    private static readonly DateTimeOffset Created6 = new(2026, 3, 27, 2, 40, 11, 531, TimeSpan.Zero);
    private static readonly DateTimeOffset Created7 = new(2026, 3, 30, 2, 34, 49, 457, TimeSpan.Zero);
    private static readonly DateTimeOffset Created8 = new(2026, 3, 27, 2, 0, 10, 569, TimeSpan.Zero);
    private static readonly DateTimeOffset Created9 = new(2026, 3, 26, 2, 51, 19, 506, TimeSpan.Zero);

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static HopDong[] GetData() =>
    [
        new HopDong
        {
            Id = HopDong1,
            DuAnId = DuAnForHopDong1,
            Ten = "dự án 03",
            SoHopDong = "HĐ/003",
            NgayKy = new DateOnly(2026, 3, 1),
            SoNgay = 30,
            NgayNghiemThu = new DateOnly(2026, 3, 30),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            LoaiHopDongId = 3,
            GiaTri = 100000000m,
            TienThue = 10000000m,
            GiaTriSauThue = 110000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 110000000m,
            NgayBaoLanhTu = new DateOnly(2026, 3, 6),
            NgayBaoLanhDen = new DateOnly(2026, 3, 31),
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 3, 30),
            NgayBaoHanhDen = new DateOnly(2027, 3, 30),
            GhiChu = "GHI CHÚ",
            TienDo = "TIẾN ĐỘ",
            TrangThaiId = 1,
            CreatedBy = "24",
            CreatedAt = Created1,
            UpdatedBy = "24",
            UpdatedAt = Created1,
            IsDeleted = false,
            Index = 1774497952
        },
        new HopDong
        {
            Id = HopDong2,
            DuAnId = DuAnForHopDong2,
            Ten = "Dự án chiến dịch tình nguyện xanh năm 2026",
            SoHopDong = "HĐ/TNX2026",
            NgayKy = new DateOnly(2026, 4, 4),
            SoNgay = 120,
            NgayNghiemThu = new DateOnly(2026, 8, 1),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            LoaiHopDongId = 3,
            GiaTri = 3801000000m,
            TienThue = 200000000m,
            GiaTriSauThue = 4001000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 4001000000m,
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 8, 1),
            NgayBaoHanhDen = new DateOnly(2027, 8, 1),
            GhiChu = "4.001.000.000",
            TienDo = "4.001.000.000",
            TrangThaiId = 1,
            CreatedBy = "23",
            CreatedAt = Created2,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 12, 31, 558, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774858336
        },
        new HopDong
        {
            Id = HopDong3,
            DuAnId = DuAnForHopDong3,
            Ten = "Hợp đồng năm 2026",
            SoHopDong = "HĐ/2026-05",
            NgayKy = new DateOnly(2026, 3, 31),
            SoNgay = 40,
            NgayNghiemThu = new DateOnly(2026, 5, 9),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            LoaiHopDongId = 3,
            GiaTri = 300000000m,
            TienThue = 10000000m,
            GiaTriSauThue = 310000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 310000000m,
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 5, 9),
            NgayBaoHanhDen = new DateOnly(2027, 5, 9),
            GhiChu = "310.000.000",
            TienDo = "310.000.000",
            TrangThaiId = 1,
            CreatedBy = "23",
            CreatedAt = Created3,
            IsDeleted = false,
            Index = 1774858441
        },
        new HopDong
        {
            Id = HopDong4,
            DuAnId = DuAnForHopDong4,
            Ten = "dự án 04",
            SoHopDong = "HĐ-04/01",
            NgayKy = new DateOnly(2026, 4, 10),
            SoNgay = 20,
            NgayNghiemThu = new DateOnly(2026, 4, 29),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            LoaiHopDongId = 3,
            GiaTri = 20000000000m,
            TienThue = 100000000m,
            GiaTriSauThue = 20100000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 20100000000m,
            NgayBaoLanhTu = new DateOnly(2026, 3, 13),
            NgayBaoLanhDen = new DateOnly(2026, 3, 31),
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 4, 29),
            NgayBaoHanhDen = new DateOnly(2027, 4, 29),
            GhiChu = "20.100.000.000",
            TienDo = "20.100.000.000",
            TrangThaiId = 1,
            CreatedBy = "24",
            CreatedAt = Created4,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 33, 52, 381, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578811
        },
        new HopDong
        {
            Id = HopDong5,
            DuAnId = DuAnForHopDong5,
            Ten = "dự án 04",
            SoHopDong = "HĐ/004",
            NgayKy = new DateOnly(2026, 4, 10),
            SoNgay = 50,
            NgayNghiemThu = new DateOnly(2026, 5, 29),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            LoaiHopDongId = 6,
            GiaTri = 20000000000m,
            TienThue = 100000000m,
            GiaTriSauThue = 20100000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 0m,
            ThoiHanBaoHanh = 0,
            NgayBaoHanhTu = new DateOnly(2026, 5, 29),
            NgayBaoHanhDen = new DateOnly(2026, 5, 29),
            TrangThaiId = 1,
            CreatedBy = "24",
            CreatedAt = Created5,
            IsDeleted = false,
            Index = 1774579106
        },
        new HopDong
        {
            Id = HopDong6,
            DuAnId = DuAnForHopDong6,
            Ten = "dự án 02",
            SoHopDong = "HĐ/2026",
            NgayKy = new DateOnly(2026, 3, 26),
            SoNgay = 50,
            NgayNghiemThu = new DateOnly(2026, 5, 14),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            LoaiHopDongId = 4,
            GiaTri = 2000000000m,
            TienThue = 0m,
            GiaTriSauThue = 2000000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 0m,
            ThoiHanBaoHanh = 0,
            NgayBaoHanhTu = new DateOnly(2026, 5, 14),
            NgayBaoHanhDen = new DateOnly(2026, 5, 14),
            TrangThaiId = 1,
            CreatedBy = "23",
            CreatedAt = Created6,
            IsDeleted = false,
            Index = 1774579211
        },
        new HopDong
        {
            Id = HopDong7,
            DuAnId = DuAnForHopDong7, // null - standalone contract (HopDong2 already uses DuAn_20260330_01)
            Ten = "Dự án triển khai vận hành hệ thống chuyển đổi số",
            SoHopDong = "HĐ/2026-30",
            NgayKy = new DateOnly(2026, 3, 31),
            SoNgay = 50,
            NgayNghiemThu = new DateOnly(2026, 5, 19),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            LoaiHopDongId = 4,
            GiaTri = 1234500000m,
            TienThue = 20000000m,
            GiaTriSauThue = 1254500000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 1254500000m,
            NgayBaoLanhTu = new DateOnly(2026, 3, 25),
            NgayBaoLanhDen = new DateOnly(2026, 3, 31),
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 5, 19),
            NgayBaoHanhDen = new DateOnly(2027, 5, 19),
            GhiChu = "1.254.500.000 - GHI CHÚ",
            TienDo = "1.254.500.000 - TIẾN ĐỘ",
            TrangThaiId = 1,
            CreatedBy = "23",
            CreatedAt = Created7,
            IsDeleted = false,
            Index = 1774838089
        },
        new HopDong
        {
            Id = HopDong8,
            DuAnId = DuAnForHopDong8, // null - standalone contract
            Ten = "dự án hợp đồng 02",
            SoHopDong = "HĐ -002",
            NgayKy = new DateOnly(2026, 3, 26),
            SoNgay = 50,
            NgayNghiemThu = new DateOnly(2026, 5, 14),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            LoaiHopDongId = 6,
            GiaTri = 2000000000m,
            TienThue = 20000000m,
            GiaTriSauThue = 2020000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 2020000000m,
            NgayBaoLanhTu = new DateOnly(2026, 3, 19),
            NgayBaoLanhDen = new DateOnly(2026, 3, 27),
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 5, 14),
            NgayBaoHanhDen = new DateOnly(2027, 5, 14),
            GhiChu = "2.020.000.000",
            TienDo = "2.020.000.000",
            TrangThaiId = 1,
            CreatedBy = "24",
            CreatedAt = Created8,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 2, 5, 740, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774576810
        },
        new HopDong
        {
            Id = HopDong9,
            DuAnId = DuAnForHopDong9,
            Ten = "dự án 03",
            SoHopDong = "HĐ-001",
            NgayKy = new DateOnly(2026, 3, 27),
            SoNgay = 20,
            NgayNghiemThu = new DateOnly(2026, 4, 15),
            KhachHangId = KhachHang1,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            LoaiHopDongId = 3,
            GiaTri = 500000000m,
            TienThue = 20000000m,
            GiaTriSauThue = 520000000m,
            PhongBanPhuTrachChinhId = 220,
            GiaTriBaoLanh = 520000000m,
            NgayBaoLanhTu = new DateOnly(2026, 3, 25),
            NgayBaoLanhDen = new DateOnly(2026, 3, 31),
            ThoiHanBaoHanh = 12,
            NgayBaoHanhTu = new DateOnly(2026, 4, 14),
            NgayBaoHanhDen = new DateOnly(2027, 4, 14),
            GhiChu = "520.000.000",
            TienDo = "520.000.000",
            TrangThaiId = 1,
            CreatedBy = "24",
            CreatedAt = Created9,
            IsDeleted = false,
            Index = 1774493479
        }
    ];

    public static void SeedHopDong(this EntityTypeBuilder<HopDong> builder) => builder.HasData(GetData());
}