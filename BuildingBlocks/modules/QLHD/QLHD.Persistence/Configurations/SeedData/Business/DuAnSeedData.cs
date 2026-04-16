namespace QLHD.Persistence.Configurations.SeedData.Business;

using static QLHD.Persistence.Configurations.SeedData.SeedDataGuids;

/// <summary>
/// Seed data extension for DuAn entity.
/// Uses centralized GUIDs from SeedDataGuids.cs to prevent FK mismatches.
/// </summary>
public static class DuAnSeedData {
    // Aliases for readability (mapping to centralized GUIDs)
    private static readonly Guid DuAn1 = DuAn_20260326_01;
    private static readonly Guid DuAn2 = DuAn_20260326_02;
    private static readonly Guid DuAn3 = DuAn_20260326_03;
    private static readonly Guid DuAn4 = DuAn_20260326_04;
    private static readonly Guid DuAn5 = DuAn_20260326_05;
    private static readonly Guid DuAn6 = DuAn_20260326_06;
    private static readonly Guid DuAn7 = DuAn_20260327_01;
    private static readonly Guid DuAn8 = DuAn_20260327_02;
    private static readonly Guid DuAn9 = DuAn_20260327_03;
    private static readonly Guid DuAn10 = DuAn_20260327_04;
    private static readonly Guid DuAn11 = DuAn_20260327_05;
    private static readonly Guid DuAn12 = DuAn_20260327_06;
    private static readonly Guid DuAn13 = DuAn_20260327_07;
    private static readonly Guid DuAn14 = DuAn_20260327_08;
    private static readonly Guid DuAn15 = DuAn_20260330_01;
    private static readonly Guid DuAn16 = DuAn_20260330_02; // Added: was missing, referenced by CongViec, DuAn_XuatHoaDon

    // KhachHang IDs (from centralized GUIDs)
    private static readonly Guid KhachHang1 = KhachHang_01;
    private static readonly Guid KhachHang2 = KhachHang_02;

    // Timestamps
    private static readonly DateTimeOffset Created1 = new(2026, 3, 26, 2, 47, 6, 788, TimeSpan.Zero);
    private static readonly DateTimeOffset Created2 = new(2026, 3, 26, 3, 22, 47, 366, TimeSpan.Zero);
    private static readonly DateTimeOffset Created3 = new(2026, 3, 26, 3, 34, 12, 420, TimeSpan.Zero);
    private static readonly DateTimeOffset Created4 = new(2026, 3, 26, 8, 11, 49, 678, TimeSpan.Zero);
    private static readonly DateTimeOffset Created5 = new(2026, 3, 26, 9, 29, 39, 414, TimeSpan.Zero);
    private static readonly DateTimeOffset Created6 = new(2026, 3, 27, 2, 22, 37, 393, TimeSpan.Zero);
    private static readonly DateTimeOffset Created7 = new(2026, 3, 27, 2, 25, 43, 287, TimeSpan.Zero);
    private static readonly DateTimeOffset Created8 = new(2026, 3, 27, 2, 26, 28, 573, TimeSpan.Zero);
    private static readonly DateTimeOffset Created9 = new(2026, 3, 27, 2, 31, 17, 779, TimeSpan.Zero);
    private static readonly DateTimeOffset Created10 = new(2026, 3, 30, 2, 28, 3, 573, TimeSpan.Zero);
    private static readonly DateTimeOffset Created11 = new(2026, 3, 30, 8, 6, 49, 308, TimeSpan.Zero);

    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DuAn[] GetData() =>
    [
        new DuAn {
            Id = DuAn1,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 21,
            HasHopDong = true,
            CreatedBy = "24",
            CreatedAt = Created1,
            UpdatedBy = "24",
            UpdatedAt = Created1,
            IsDeleted = false,
            Index = 1774493226
        },
        new DuAn {
            Id = DuAn2,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "23",
            CreatedAt = Created4,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 0, 11, 303, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774512709
        },
        new DuAn {
            Id = DuAn3,
            Ten = "dự án 01",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 1),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 5,
            HasHopDong = false,
            CreatedBy = "24",
            CreatedAt = Created2,
            IsDeleted = false,
            Index = 1774495367
        },
        new DuAn {
            Id = DuAn4,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 21,
            HasHopDong = false,
            CreatedBy = "24",
            CreatedAt = Created2,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 26, 3, 38, 42, 749, TimeSpan.Zero),
            IsDeleted = true,
            Index = 1774495464
        },
        new DuAn {
            Id = DuAn5,
            Ten = "dự án 03",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 1),
            GiaTriDuKien = 100000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 27),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 10m,
            ThanhTien = 10000000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "24",
            CreatedAt = Created3,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 26, 4, 5, 53, 205, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774496052
        },
        new DuAn {
            Id = DuAn6,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 5,
            HasHopDong = false,
            CreatedBy = "23",
            CreatedAt = Created5,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 11, 33, 509, TimeSpan.Zero),
            IsDeleted = true,
            Index = 1774513599
        },
        new DuAn {
            Id = DuAn7,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 5,
            HasHopDong = false,
            CreatedBy = "23",
            CreatedAt = Created5,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 11, 33, 509, TimeSpan.Zero),
            IsDeleted = true,
            Index = 1774513599
        },

        new DuAn {
            Id = DuAn8,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 5,
            HasHopDong = false,
            CreatedBy = "23",
            CreatedAt = Created5,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 11, 33, 509, TimeSpan.Zero),
            IsDeleted = true,
            Index = 1774513599
        },
        new DuAn {
            Id = DuAn9,
            Ten = "dự án 02",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 26),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 26),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 1,
            NguoiTheoDoiId = 1,
            GiamDocId = 1,
            GiaVon = 20m,
            ThanhTien = 400000000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "23",
            CreatedAt = Created6,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 40, 11, 555, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578157
        },
        new DuAn {
            Id = DuAn10,
            Ten = "dự án mới năm 2026",
            KhachHangId = KhachHang2,
            NgayLap = new DateOnly(2026, 3, 1),
            GiaTriDuKien = 2000000000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 31),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 10m,
            ThanhTien = 200000000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "23",
            CreatedAt = Created7,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 28, 36, 160, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578343
        },
        new DuAn {
            Id = DuAn11,
            Ten = "Dự án làm trước 20236 - Giải Phóng Mặt Bằng vành đai 3 giai đoạn 1",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2025, 3, 4),
            GiaTriDuKien = 15000000000m,
            ThoiGianDuKien = new DateOnly(2026, 1, 1),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 75m,
            ThanhTien = 11250000000m,
            TrangThaiId = 6,
            HasHopDong = true,
            CreatedBy = "24",
            CreatedAt = Created8,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 34, 49, 763, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578388
        }, new DuAn {
            Id = DuAn12,
            Ten = "Dự án làm trước 20236 - Giải Phóng Mặt Bằng vành đai 3 giai đoạn 1",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2025, 3, 4),
            GiaTriDuKien = 15000000000m,
            ThoiGianDuKien = new DateOnly(2026, 1, 1),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 75m,
            ThanhTien = 11250000000m,
            TrangThaiId = 6,
            HasHopDong = true,
            CreatedBy = "24",
            CreatedAt = Created8,
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 34, 49, 763, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578388
        },
        new DuAn {
            Id = DuAn13,
            Ten = "dự án 04",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 4, 10),
            GiaTriDuKien = 20000000000m,
            ThoiGianDuKien = new DateOnly(2026, 4, 30),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 20m,
            ThanhTien = 4000000000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "4",
            CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 50, 698, TimeSpan.Zero),
            UpdatedBy = "24",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 38, 26, 461, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578710
        },
        new DuAn {
            Id = DuAn14,
            Ten = "dự án 04",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 4, 10),
            GiaTriDuKien = 20000000000m,
            ThoiGianDuKien = new DateOnly(2026, 4, 30),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 20m,
            ThanhTien = 4000000000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "4",
            CreatedAt = new DateTimeOffset(2026, 3, 27, 2, 31, 53, 749, TimeSpan.Zero),
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 27, 2, 33, 31, 207, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774578713
        },
        new DuAn {
            Id = DuAn15,
            Ten = "Dự án triển khai vận hành hệ thống chuyển đổi số",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 31),
            GiaTriDuKien = 1234500000m,
            ThoiGianDuKien = new DateOnly(2026, 3, 31),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 20m,
            ThanhTien = 246900000m,
            TrangThaiId = 5,
            HasHopDong = true,
            CreatedBy = "23",
            CreatedAt = Created10,
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 30, 2, 34, 49, 653, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774837683
        },
        new DuAn {
            Id = DuAn16,
            Ten = "Dự án pilot chuyển đổi số giai đoạn 2",
            KhachHangId = KhachHang1,
            NgayLap = new DateOnly(2026, 3, 30),
            GiaTriDuKien = 500000000m,
            ThoiGianDuKien = new DateOnly(2026, 4, 30),
            PhongBanPhuTrachChinhId = 220,
            NguoiPhuTrachChinhId = 2,
            NguoiTheoDoiId = 2,
            GiamDocId = 2,
            GiaVon = 25m,
            ThanhTien = 125000000m,
            TrangThaiId = 5,
            HasHopDong = false,
            CreatedBy = "23",
            CreatedAt = new DateTimeOffset(2026, 3, 30, 8, 6, 49, 308, TimeSpan.Zero),
            UpdatedBy = "23",
            UpdatedAt = new DateTimeOffset(2026, 3, 30, 8, 7, 19, 432, TimeSpan.Zero),
            IsDeleted = false,
            Index = 1774858009
        }
    ];

    public static void SeedDuAn(this EntityTypeBuilder<DuAn> builder) => builder.HasData(GetData());
}