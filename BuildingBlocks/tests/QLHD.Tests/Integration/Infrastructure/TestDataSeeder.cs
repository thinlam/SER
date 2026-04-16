using QLHD.Domain.Entities.DanhMuc;
using QLHD.Domain.Entities;

namespace QLHD.Tests.Integration.Infrastructure;

/// <summary>
/// Seeds minimal test data for integration tests.
/// Provides required DanhMuc entities for referential integrity.
/// </summary>
public static class TestDataSeeder
{
    private static readonly DateTimeOffset SeedCreatedAt = new(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static void Seed(AppDbContext db)
    {
        // Seed DanhMucLoaiTrangThai
        if (!db.Set<DanhMucLoaiTrangThai>().Any())
        {
            db.Set<DanhMucLoaiTrangThai>().AddRange(
                new DanhMucLoaiTrangThai
                {
                    Id = 1,
                    Ma = "HOP_DONG",
                    Ten = "Hợp đồng",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                },
                new DanhMucLoaiTrangThai
                {
                    Id = 2,
                    Ma = "TIEN_DO",
                    Ten = "Tiến độ",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucTrangThai (with LoaiTrangThaiId)
        if (!db.Set<DanhMucTrangThai>().Any())
        {
            db.Set<DanhMucTrangThai>().AddRange(
                new DanhMucTrangThai
                {
                    Id = 1,
                    Ma = "MOI",
                    Ten = "Mới",
                    LoaiTrangThaiId = 1,
                    MaLoaiTrangThai = "HOP_DONG",
                    TenLoaiTrangThai = "Hợp đồng",
                    Used = true,
                    IsDefault = true,
                    CreatedAt = SeedCreatedAt
                },
                new DanhMucTrangThai
                {
                    Id = 2,
                    Ma = "DANG_THUC_HIEN",
                    Ten = "Đang thực hiện",
                    LoaiTrangThaiId = 1,
                    MaLoaiTrangThai = "HOP_DONG",
                    TenLoaiTrangThai = "Hợp đồng",
                    Used = true,
                    IsDefault = false,
                    CreatedAt = SeedCreatedAt
                },
                new DanhMucTrangThai
                {
                    Id = 3,
                    Ma = "HOAN_THANH",
                    Ten = "Hoàn thành",
                    LoaiTrangThaiId = 1,
                    MaLoaiTrangThai = "HOP_DONG",
                    TenLoaiTrangThai = "Hợp đồng",
                    Used = true,
                    IsDefault = false,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucLoaiHopDong
        if (!db.Set<DanhMucLoaiHopDong>().Any())
        {
            db.Set<DanhMucLoaiHopDong>().AddRange(
                new DanhMucLoaiHopDong
                {
                    Id = 1,
                    Ma = "DV",
                    Ten = "Dịch vụ",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                },
                new DanhMucLoaiHopDong
                {
                    Id = 2,
                    Ma = "KH",
                    Ten = "Ký gửi",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucLoaiThanhToan
        if (!db.Set<DanhMucLoaiThanhToan>().Any())
        {
            db.Set<DanhMucLoaiThanhToan>().AddRange(
                new DanhMucLoaiThanhToan
                {
                    Id = 1,
                    Ma = "THANG",
                    Ten = "Theo tháng",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                },
                new DanhMucLoaiThanhToan
                {
                    Id = 2,
                    Ma = "QUY",
                    Ten = "Theo quý",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DoanhNghiep (required for KhachHang)
        if (!db.Set<DoanhNghiep>().Any())
        {
            db.Set<DoanhNghiep>().Add(
                new DoanhNghiep
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Ten = "Doanh nghiệp test",
                    IsActive = true
                }
            );
        }

        // Seed KhachHang (required for HopDong)
        if (!db.Set<KhachHang>().Any())
        {
            db.Set<KhachHang>().Add(
                new KhachHang
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Ma = "KH001",
                    Ten = "Khách hàng test",
                    DoanhNghiepId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucNguoiPhuTrach (required for DuAn)
        if (!db.Set<DanhMucNguoiPhuTrach>().Any())
        {
            db.Set<DanhMucNguoiPhuTrach>().Add(
                new DanhMucNguoiPhuTrach
                {
                    Id = 1,
                    Ma = "NPT001",
                    Ten = "Người phụ trách test",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucNguoiTheoDoi (required for DuAn)
        if (!db.Set<DanhMucNguoiTheoDoi>().Any())
        {
            db.Set<DanhMucNguoiTheoDoi>().Add(
                new DanhMucNguoiTheoDoi
                {
                    Id = 1,
                    Ma = "NTD001",
                    Ten = "Người theo dõi test",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucGiamDoc (required for DuAn)
        if (!db.Set<DanhMucGiamDoc>().Any())
        {
            db.Set<DanhMucGiamDoc>().Add(
                new DanhMucGiamDoc
                {
                    Id = 1,
                    Ma = "GD001",
                    Ten = "Giám đốc test",
                    Used = true,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        // Seed DanhMucLoaiChiPhi
        if (!db.Set<DanhMucLoaiChiPhi>().Any())
        {
            db.Set<DanhMucLoaiChiPhi>().AddRange(
                new DanhMucLoaiChiPhi
                {
                    Id = 1,
                    Ma = "CP001",
                    Ten = "Chi phí nhân sự",
                    Used = true,
                    IsDefault = true,
                    CreatedAt = SeedCreatedAt
                },
                new DanhMucLoaiChiPhi
                {
                    Id = 2,
                    Ma = "CP002",
                    Ten = "Chi phí vật tư",
                    Used = true,
                    IsDefault = false,
                    CreatedAt = SeedCreatedAt
                }
            );
        }

        db.SaveChanges();
    }
}