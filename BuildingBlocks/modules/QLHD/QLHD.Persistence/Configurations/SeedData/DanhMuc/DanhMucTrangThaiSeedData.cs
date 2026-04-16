using QLHD.Domain.Constants;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.SeedData.DanhMuc;

/// <summary>
/// Seed data extension for DanhMucTrangThai entity.
/// </summary>
public static class DanhMucTrangThaiSeedData
{
    /// <summary>
    /// Get seed data array for runtime seeding.
    /// </summary>
    public static DanhMucTrangThai[] GetData() =>
    [
        // Hợp đồng statuses (HDONG)
        new DanhMucTrangThai {
            Id = 1,
            Ma = "OPEN",
            Ten = "Đang thực hiện",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 1,
            MaLoaiTrangThai = LoaiTrangThaiConstants.HopDong,
            TenLoaiTrangThai = "Hợp đồng",
            IsDefault = true,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 2,
            Ma = "PENDING",
            Ten = "Tạm dừng",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 1,
            MaLoaiTrangThai = LoaiTrangThaiConstants.HopDong,
            TenLoaiTrangThai = "Hợp đồng",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 3,
            Ma = "CANCEL",
            Ten = "Hủy",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 1,
            MaLoaiTrangThai = LoaiTrangThaiConstants.HopDong,
            TenLoaiTrangThai = "Hợp đồng",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 4,
            Ma = "COMPLETE",
            Ten = "Nghiệm thu",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 1,
            MaLoaiTrangThai = LoaiTrangThaiConstants.HopDong,
            TenLoaiTrangThai = "Hợp đồng",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 12,
            Ma = "CLOSED",
            Ten = "Hoàn tất",
            MoTa = "Hoàn tất Nghiệm thu, thu tiền, xuất hóa đơn.",
            Used = true,
            LoaiTrangThaiId = 1,
            MaLoaiTrangThai = LoaiTrangThaiConstants.HopDong,
            TenLoaiTrangThai = "Hợp đồng",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 13,
            Ma = "MAINTENANCE",
            Ten = "Bảo trì",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 1,
            MaLoaiTrangThai = LoaiTrangThaiConstants.HopDong,
            TenLoaiTrangThai = "Hợp đồng",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        // Kế hoạch statuses (KHOACH)
        new DanhMucTrangThai {
            Id = 5,
            Ma = "RUNNING",
            Ten = "Đang thực hiện",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = true,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 6,
            Ma = "WS.01",
            Ten = "Theo dõi (Chưa rõ ràng)",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 7,
            Ma = "SIGNED",
            Ten = "Hoàn tất",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 8,
            Ma = "WS03",
            Ten = "Có chủ trương/có KH thực hiện",
            MoTa = null,
            Used = false,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 9,
            Ma = "WS05",
            Ten = "Có QĐ phê duyệt.",
            MoTa = null,
            Used = false,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 10,
            Ma = "WS06",
            Ten = "Đấu thầu, đàm phán",
            MoTa = null,
            Used = false,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 11,
            Ma = "WS07",
            Ten = "Tạm dừng/Không thực hiện",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 14,
            Ma = "TK",
            Ten = "Tái ký",
            MoTa = "HĐ bảo trì, thuê vi.his, vi.Office, hóa đơn điện tử",
            Used = true,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 21,
            Ma = "DONE",
            Ten = "Nghiệm thu",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 2,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KeHoach,
            TenLoaiTrangThai = "Kế hoạch",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        // Cuộc họp statuses (CHOP)
        new DanhMucTrangThai {
            Id = 15,
            Ma = "OPEN",
            Ten = "Chưa diễn ra",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 3,
            MaLoaiTrangThai = LoaiTrangThaiConstants.CuocHop,
            TenLoaiTrangThai = "Cuộc họp",
            IsDefault = true,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 16,
            Ma = "WAITING",
            Ten = "Chưa duyệt",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 3,
            MaLoaiTrangThai = LoaiTrangThaiConstants.CuocHop,
            TenLoaiTrangThai = "Cuộc họp",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 17,
            Ma = "CLOSED",
            Ten = "Đã kết thúc",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 3,
            MaLoaiTrangThai = LoaiTrangThaiConstants.CuocHop,
            TenLoaiTrangThai = "Cuộc họp",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 18,
            Ma = "GOINGON",
            Ten = "Đang diễn ra",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 3,
            MaLoaiTrangThai = LoaiTrangThaiConstants.CuocHop,
            TenLoaiTrangThai = "Cuộc họp",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 19,
            Ma = "CANCEL",
            Ten = "Hủy",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 3,
            MaLoaiTrangThai = LoaiTrangThaiConstants.CuocHop,
            TenLoaiTrangThai = "Cuộc họp",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 20,
            Ma = "PENDING",
            Ten = "Tạm hoãn",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 3,
            MaLoaiTrangThai = LoaiTrangThaiConstants.CuocHop,
            TenLoaiTrangThai = "Cuộc họp",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        // Tiến độ statuses (TIENDO)
        new DanhMucTrangThai {
            Id = 24,
            Ma = "CHUA_BAT_DAU",
            Ten = "Chưa bắt đầu",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 4,
            MaLoaiTrangThai = LoaiTrangThaiConstants.TienDo,
            TenLoaiTrangThai = "Tiến độ",
            IsDefault = true,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 25,
            Ma = "DANG_THUC_HIEN",
            Ten = "Đang thực hiện",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 4,
            MaLoaiTrangThai = LoaiTrangThaiConstants.TienDo,
            TenLoaiTrangThai = "Tiến độ",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 26,
            Ma = "HOAN_THANH",
            Ten = "Hoàn thành",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 4,
            MaLoaiTrangThai = LoaiTrangThaiConstants.TienDo,
            TenLoaiTrangThai = "Tiến độ",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 27,
            Ma = "TAM_DUNG",
            Ten = "Tạm dừng",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 4,
            MaLoaiTrangThai = LoaiTrangThaiConstants.TienDo,
            TenLoaiTrangThai = "Tiến độ",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 28,
            Ma = "HUY",
            Ten = "Hủy",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 4,
            MaLoaiTrangThai = LoaiTrangThaiConstants.TienDo,
            TenLoaiTrangThai = "Tiến độ",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        // Khó khăn vướng mắc statuses (KKHUAN_VUONG_MAC)
        new DanhMucTrangThai {
            Id = 29,
            Ma = "MOI",
            Ten = "Mới",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 5,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KhoKhanVuongMac,
            TenLoaiTrangThai = "Khó khăn vướng mắc",
            IsDefault = true,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 30,
            Ma = "DANG_XU_LY",
            Ten = "Đang xử lý",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 5,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KhoKhanVuongMac,
            TenLoaiTrangThai = "Khó khăn vướng mắc",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 31,
            Ma = "DA_GIAI_QUYET",
            Ten = "Đã giải quyết",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 5,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KhoKhanVuongMac,
            TenLoaiTrangThai = "Khó khăn vướng mắc",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        },
        new DanhMucTrangThai {
            Id = 32,
            Ma = "KHONG_THE_GIAI_QUYET",
            Ten = "Không thể giải quyết",
            MoTa = null,
            Used = true,
            LoaiTrangThaiId = 5,
            MaLoaiTrangThai = LoaiTrangThaiConstants.KhoKhanVuongMac,
            TenLoaiTrangThai = "Khó khăn vướng mắc",
            IsDefault = false,
            CreatedAt = SeedDataConstants.SeedCreatedAt
        }
    ];

    public static void SeedDanhMucTrangThai(this EntityTypeBuilder<DanhMucTrangThai> builder) => builder.HasData(GetData());
}