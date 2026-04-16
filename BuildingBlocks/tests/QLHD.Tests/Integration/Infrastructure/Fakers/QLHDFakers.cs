using Bogus;
using BuildingBlocks.Domain.ValueTypes;
using QLHD.Domain.Entities;

namespace QLHD.Tests.Integration.Infrastructure.Fakers;

/// <summary>
/// Bogus Fakers for QLHD entities with FK-aware generation.
/// Uses deterministic seed for reproducible test data.
/// </summary>
public static class QLHDFakers {
    private static int _seed = 12345;
    private static int _chiPhiCounter = 1;

    /// <summary>
    /// Set seed for deterministic generation. Call before generating data.
    /// Resets all counters to ensure reproducibility.
    /// </summary>
    public static void SetSeed(int seed) {
        _seed = seed;
        _chiPhiCounter = 1;
    }

    /// <summary>
    /// KhachHang Faker - generates customers (Level 1 entity).
    /// </summary>
    public static Faker<KhachHang> KhachHangFaker(Guid? doanhNghiepId = null) {
        return new Faker<KhachHang>("vi")
            .UseSeed(_seed)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.Ma, f => $"KH{Guid.NewGuid().ToString("N")[..8].ToUpper()}")
            .RuleFor(e => e.Ten, f => f.Company.CompanyName())
            .RuleFor(e => e.IsPersonal, f => f.Random.Bool(0.2f))
            .RuleFor(e => e.TaxCode, f => f.Random.Bool(0.7f) ? f.Finance.Account(10) : null)
            .RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(e => e.Email, f => f.Internet.Email())
            .RuleFor(e => e.ContactPerson, f => f.Person.FullName)
            .RuleFor(e => e.DoanhNghiepId, doanhNghiepId)  // Nullable FK - null by default
            .RuleFor(e => e.Used, true)
            .RuleFor(e => e.CreatedAt, f => f.Date.PastOffset(1));
    }

    /// <summary>
    /// HopDong Faker - generates contracts (Level 2 entity).
    /// IMPORTANT: SoHopDong must be unique (uses Guid-based pattern).
    /// </summary>
    public static Faker<HopDong> HopDongFaker(
        Guid khachHangId,
        Guid? duAnId = null,
        int? loaiHopDongId = null,
        int? trangThaiId = null,
        int? nguoiPhuTrachId = null,
        int? nguoiTheoDoiId = null,
        int? giamDocId = null) {
        return new Faker<HopDong>("vi")
            .UseSeed(_seed + 100)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.SoHopDong, f => $"HD-{DateTime.Now.Year}-{Guid.NewGuid().ToString("N")[..8].ToUpper()}")
            .RuleFor(e => e.Ten, f => $"Hợp đồng {f.Commerce.ProductName()}")
            .RuleFor(e => e.KhachHangId, khachHangId)
            .RuleFor(e => e.DuAnId, duAnId)
            .RuleFor(e => e.NgayKy, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.SoNgay, f => f.Random.Int(30, 365))
            .RuleFor(e => e.NgayNghiemThu, (f, e) => e.NgayKy.AddDays(e.SoNgay))
            .RuleFor(e => e.LoaiHopDongId, loaiHopDongId ?? FKReferenceData.LoaiHopDongDV)
            .RuleFor(e => e.TrangThaiId, trangThaiId ?? FKReferenceData.TrangThaiMoi)
            .RuleFor(e => e.NguoiPhuTrachChinhId, nguoiPhuTrachId ?? FKReferenceData.NguoiPhuTrachId)
            .RuleFor(e => e.NguoiTheoDoiId, nguoiTheoDoiId ?? FKReferenceData.NguoiTheoDoiId)
            .RuleFor(e => e.GiamDocId, giamDocId ?? FKReferenceData.GiamDocId)
            .RuleFor(e => e.GiaTri, f => f.Random.Decimal(10_000_000, 500_000_000))
            .RuleFor(e => e.TienThue, f => f.Random.Bool(0.7f) ? f.Random.Decimal(0, 50_000_000) : null)
            .RuleFor(e => e.GiaTriSauThue, (f, e) => e.TienThue.HasValue ? e.GiaTri + e.TienThue : null)
            .RuleFor(e => e.GiaTriBaoLanh, f => f.Random.Decimal(0, 100_000_000))
            .RuleFor(e => e.ThoiHanBaoHanh, f => f.Random.Byte(6, 24))
            .RuleFor(e => e.CreatedAt, f => f.Date.PastOffset(1));
    }

    /// <summary>
    /// HopDong_ChiPhi Faker - generates contract costs (Level 3 entity).
    /// </summary>
    public static Faker<HopDong_ChiPhi> ChiPhiFaker(
        Guid hopDongId,
        int? loaiChiPhiId = null) {
        return new Faker<HopDong_ChiPhi>("vi")
            .UseSeed(_seed + 300)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.HopDongId, hopDongId)
            .RuleFor(e => e.LoaiChiPhiId, loaiChiPhiId ?? FKReferenceData.LoaiChiPhiNhanSu)
            .RuleFor(e => e.Nam, f => (short)f.Random.Int(2024, 2026))
            .RuleFor(e => e.LanChi, _ => (byte)_chiPhiCounter++)
            .RuleFor(e => e.ThoiGianKeHoach, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.PhanTramKeHoach, f => f.Random.Decimal(5, 100))
            .RuleFor(e => e.GiaTriKeHoach, f => f.Random.Decimal(1_000_000, 50_000_000))
            .RuleFor(e => e.GhiChuKeHoach, f => f.Lorem.Sentence(5))
            .RuleFor(e => e.ThoiGianThucTe, f => f.Random.Bool(0.3f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null)
            .RuleFor(e => e.GiaTriThucTe, (f, e) => e.ThoiGianThucTe.HasValue ? f.Random.Decimal(1_000_000, 40_000_000) : null)
            .RuleFor(e => e.GhiChuThucTe, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null);
    }

    /// <summary>
    /// HopDong_ThuTien Faker - generates payment schedules (Level 3 entity).
    /// </summary>
    public static Faker<HopDong_ThuTien> ThuTienFaker(
        Guid hopDongId,
        int? loaiThanhToanId = null) {
        return new Faker<HopDong_ThuTien>("vi")
            .UseSeed(_seed + 400)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.HopDongId, hopDongId)
            .RuleFor(e => e.LoaiThanhToanId, loaiThanhToanId ?? FKReferenceData.LoaiThanhToanThang)
            .RuleFor(e => e.ThoiGianKeHoach, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.PhanTramKeHoach, f => f.Random.Decimal(5, 30))
            .RuleFor(e => e.GiaTriKeHoach, f => f.Random.Decimal(1_000_000, 50_000_000))
            .RuleFor(e => e.GhiChuKeHoach, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.GhiChuThucTe, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.ThoiGianThucTe, f => f.Random.Bool(0.3f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null)
            .RuleFor(e => e.GiaTriThucTe, (f, e) => e.ThoiGianThucTe.HasValue ? f.Random.Decimal(1_000_000, 40_000_000) : null)
            .RuleFor(e => e.SoHoaDon, f => f.Random.Bool(0.3f) ? $"HD{f.Random.Int(1000, 9999)}" : null)
            .RuleFor(e => e.KyHieuHoaDon, f => f.Random.Bool(0.3f) ? $"K${DateTime.Now.Year}" : null)
            .RuleFor(e => e.NgayHoaDon, f => f.Random.Bool(0.3f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null);
    }

    /// <summary>
    /// CongViec Faker - generates project tasks (dev schema).
    /// Uses denormalized TenDonVi/TenPhongBan/TenTrangThai pattern.
    /// </summary>
    public static Faker<CongViec> CongViecFaker(
        Guid duAnId,
        int? trangThaiId = null,
        long? donViId = null,
        long? phongBanId = null) {
        return new Faker<CongViec>("vi")
            .UseSeed(_seed + 500)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.DuAnId, duAnId)
            .RuleFor(e => e.ThoiGian, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.UserPortalId, f => f.Random.Long(1, 100))
            .RuleFor(e => e.NguoiThucHien, f => f.Person.FullName)
            .RuleFor(e => e.DonViId, donViId ?? FKReferenceData.DonViId)
            .RuleFor(e => e.TenDonVi, f => f.Company.CompanyName())
            .RuleFor(e => e.PhongBanId, phongBanId ?? FKReferenceData.PhongBanId)
            .RuleFor(e => e.TenPhongBan, f => f.Random.Bool(0.7f) ? f.Commerce.Department() : null)
            .RuleFor(e => e.KeHoachCongViec, f => f.Lorem.Paragraph(1))
            .RuleFor(e => e.NgayHoanThanh, f => f.Random.Bool(0.5f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null)
            .RuleFor(e => e.ThucTe, f => f.Random.Bool(0.6f) ? f.Lorem.Paragraph(1) : null)
            .RuleFor(e => e.TrangThaiId, trangThaiId ?? FKReferenceData.TrangThaiKeHoachId)
            .RuleFor(e => e.TenTrangThai, f => f.PickRandom("Chờ xử lý", "Đang thực hiện", "Hoàn thành"))
            .RuleFor(e => e.CreatedAt, f => f.Date.PastOffset(1));
    }

    /// <summary>
    /// KeHoachThang Faker - generates monthly planning periods.
    /// Demonstrates MonthYear string parsing (e.g., "04-2025").
    /// </summary>
    /// <example>
    /// // Parse MonthYear from string format "MM-yyyy"
    /// var tuNgay = MonthYear.Parse("04-2025");  // April 2025
    /// var denNgay = MonthYear.Parse("12-2025"); // December 2025
    /// var faker = KeHoachThangFaker(tuNgay, denNgay);
    /// </example>
    public static Faker<KeHoachThang> KeHoachThangFaker(
        MonthYear? tuNgay = null,
        MonthYear? denNgay = null) {
        return new Faker<KeHoachThang>("vi")
            .UseSeed(_seed + 600)
            .RuleFor(e => e.Id, f => f.Random.Int(1, 1000))
            .RuleFor(e => e.TuNgay, f => (tuNgay ?? MonthYear.Parse("04-2025")).ToDateOnly())
            .RuleFor(e => e.DenNgay, f => (denNgay ?? MonthYear.Parse("12-2025")).ToDateOnly())
            .RuleFor(e => e.TuThangDisplay, (f, e) => $"Tháng {e.TuNgay.Month} - {e.TuNgay.Year}")
            .RuleFor(e => e.DenThangDisplay, (f, e) => $"Tháng {e.DenNgay.Month} - {e.DenNgay.Year}")
            .RuleFor(e => e.GhiChu, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null);
    }

    /// <summary>
    /// DuAn Faker - generates projects (Level 2 entity).
    /// Has FK to KhachHang, NguoiPhuTrach, NguoiTheoDoi, GiamDoc.
    /// </summary>
    public static Faker<DuAn> DuAnFaker(
        Guid khachHangId,
        int? nguoiPhuTrachId = null,
        int? nguoiTheoDoiId = null,
        int? giamDocId = null,
        long? phongBanId = null) {
        return new Faker<DuAn>("vi")
            .UseSeed(_seed + 700)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.Ten, f => $"Dự án {f.Commerce.ProductName()}")
            .RuleFor(e => e.KhachHangId, khachHangId)
            .RuleFor(e => e.NgayLap, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.GiaTriDuKien, f => f.Random.Decimal(100_000_000, 10_000_000_000))
            .RuleFor(e => e.ThoiGianDuKien, f => DateOnly.FromDateTime(f.Date.Future(2)))
            .RuleFor(e => e.PhongBanPhuTrachChinhId, phongBanId ?? FKReferenceData.PhongBanId)
            .RuleFor(e => e.NguoiPhuTrachChinhId, nguoiPhuTrachId ?? FKReferenceData.NguoiPhuTrachId)
            .RuleFor(e => e.NguoiTheoDoiId, nguoiTheoDoiId ?? FKReferenceData.NguoiTheoDoiId)
            .RuleFor(e => e.GiamDocId, giamDocId ?? FKReferenceData.GiamDocId)
            .RuleFor(e => e.CreatedAt, f => f.Date.PastOffset(1));
    }


    /// <summary>
    /// HopDong_ThuTien Faker - generates payment schedules for standalone contracts.
    /// IMPORTANT: Only use for HopDong with DuAnId = null.
    /// If HopDong.DuAnId is set, use DuAn_ThuTien instead.
    /// </summary>
    public static Faker<HopDong_ThuTien> HopDongThuTienFaker(Guid hopDongId, int? loaiThanhToanId = null) {
        return new Faker<HopDong_ThuTien>("vi")
            .UseSeed(_seed + 800)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.HopDongId, hopDongId)
            .RuleFor(e => e.LoaiThanhToanId, loaiThanhToanId ?? FKReferenceData.LoaiThanhToanThang)
            .RuleFor(e => e.ThoiGianKeHoach, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.PhanTramKeHoach, f => f.Random.Decimal(5, 30))
            .RuleFor(e => e.GiaTriKeHoach, f => f.Random.Decimal(1_000_000, 50_000_000))
            .RuleFor(e => e.GhiChuKeHoach, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.GhiChuThucTe, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.ThoiGianThucTe, f => f.Random.Bool(0.3f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null)
            .RuleFor(e => e.GiaTriThucTe, (f, e) => e.ThoiGianThucTe.HasValue ? f.Random.Decimal(1_000_000, 40_000_000) : null);
    }

    /// <summary>
    /// HopDong_XuatHoaDon Faker - generates invoice records for contracts.
    /// </summary>
    public static Faker<HopDong_XuatHoaDon> HopDongXuatHoaDonFaker(Guid hopDongId, int? loaiThanhToanId = null) {
        return new Faker<HopDong_XuatHoaDon>("vi")
            .UseSeed(_seed + 900)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.HopDongId, hopDongId)
            .RuleFor(e => e.LoaiThanhToanId, loaiThanhToanId ?? FKReferenceData.LoaiThanhToanDoan1)
            .RuleFor(e => e.ThoiGianKeHoach, f => DateOnly.FromDateTime(f.Date.Past(1)))
            .RuleFor(e => e.PhanTramKeHoach, f => f.Random.Decimal(5, 30))
            .RuleFor(e => e.GiaTriKeHoach, f => f.Random.Decimal(1_000_000, 50_000_000))
            .RuleFor(e => e.GhiChuKeHoach, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.GhiChuThucTe, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.ThoiGianThucTe, f => f.Random.Bool(0.3f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null)
            .RuleFor(e => e.GiaTriThucTe, (f, e) => e.ThoiGianThucTe.HasValue ? f.Random.Decimal(1_000_000, 40_000_000) : null)
            .RuleFor(e => e.SoHoaDon, f => f.Random.Bool(0.3f) ? $"HD{f.Random.Int(1000, 9999)}" : null)
            .RuleFor(e => e.KyHieuHoaDon, f => f.Random.Bool(0.3f) ? $"K${DateTime.Now.Year}" : null)
            .RuleFor(e => e.NgayHoaDon, f => f.Random.Bool(0.3f) ? DateOnly.FromDateTime(f.Date.Past(1)) : null);
    }

    /// <summary>
    /// KeHoachKinhDoanhNam Faker - generates annual business plans (parent entity).
    /// BatDau/KetThuc store month/year only (day defaults to 01).
    /// </summary>
    public static Faker<KeHoachKinhDoanhNam> KeHoachKinhDoanhNamFaker(
        DateOnly? batDau = null,
        DateOnly? ketThuc = null) {
        return new Faker<KeHoachKinhDoanhNam>("vi")
            .UseSeed(_seed + 1000)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.BatDau, f => batDau ?? new DateOnly(f.Random.Int(2024, 2026), f.Random.Int(1, 12), 1))
            .RuleFor(e => e.KetThuc, f => ketThuc ?? new DateOnly(f.Random.Int(2024, 2026), f.Random.Int(1, 12), 1))
            .RuleFor(e => e.GhiChu, f => f.Random.Bool(0.5f) ? f.Lorem.Sentence(3) : null)
            .RuleFor(e => e.CreatedAt, f => f.Date.PastOffset(1));
    }

    /// <summary>
    /// KeHoachKinhDoanhNam_BoPhan Faker - generates department-level business plans (child entity).
    /// Contains financial metrics: DoanhKySo, LaiGop, ThuTien, ChiPhi, LoiNhuan.
    /// </summary>
    public static Faker<KeHoachKinhDoanhNam_BoPhan> KeHoachKinhDoanhNamBoPhanFaker(
        Guid keHoachKinhDoanhNamId,
        long? donViId = null) {
        return new Faker<KeHoachKinhDoanhNam_BoPhan>("vi")
            .UseSeed(_seed + 1100)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.KeHoachKinhDoanhNamId, keHoachKinhDoanhNamId)
            .RuleFor(e => e.DonViId, donViId ?? FKReferenceData.DonViId)
            .RuleFor(e => e.Ten, f => $"Kế hoạch bộ phận {f.Commerce.Department()}")
            .RuleFor(e => e.DoanhKySo, f => f.Random.Decimal(100_000_000, 1_000_000_000))
            .RuleFor(e => e.LaiGopKy, f => f.Random.Decimal(10_000_000, 100_000_000))
            .RuleFor(e => e.DoanhSoXuatHoaDon, f => f.Random.Decimal(50_000_000, 800_000_000))
            .RuleFor(e => e.LaiGopXuatHoaDon, f => f.Random.Decimal(5_000_000, 80_000_000))
            .RuleFor(e => e.ThuTien, f => f.Random.Decimal(30_000_000, 600_000_000))
            .RuleFor(e => e.LaiGopThuTien, f => f.Random.Decimal(3_000_000, 60_000_000))
            .RuleFor(e => e.ChiPhiTrucTiep, f => f.Random.Decimal(5_000_000, 50_000_000))
            .RuleFor(e => e.ChiPhiPhanBo, f => f.Random.Decimal(2_000_000, 20_000_000))
            .RuleFor(e => e.LoiNhuan, f => f.Random.Decimal(1_000_000, 30_000_000));
    }

    /// <summary>
    /// KeHoachKinhDoanhNam_CaNhan Faker - generates individual-level business plans (child entity).
    /// Contains financial metrics similar to BoPhan but linked to UserPortalId.
    /// </summary>
    public static Faker<KeHoachKinhDoanhNam_CaNhan> KeHoachKinhDoanhNamCaNhanFaker(
        Guid keHoachKinhDoanhNamId,
        long? userPortalId = null) {
        return new Faker<KeHoachKinhDoanhNam_CaNhan>("vi")
            .UseSeed(_seed + 1200)
            .RuleFor(e => e.Id, f => Guid.NewGuid())
            .RuleFor(e => e.KeHoachKinhDoanhNamId, keHoachKinhDoanhNamId)
            .RuleFor(e => e.UserPortalId, (f, e) => userPortalId ?? f.Random.Long(1, 100))
            .RuleFor(e => e.Ten, f => $"Kế hoạch cá nhân {f.Person.FullName}")
            .RuleFor(e => e.DoanhKySo, f => f.Random.Decimal(10_000_000, 200_000_000))
            .RuleFor(e => e.LaiGopKy, f => f.Random.Decimal(1_000_000, 20_000_000))
            .RuleFor(e => e.DoanhSoXuatHoaDon, f => f.Random.Decimal(5_000_000, 150_000_000))
            .RuleFor(e => e.LaiGopXuatHoaDon, f => f.Random.Decimal(500_000, 15_000_000))
            .RuleFor(e => e.ThuTien, f => f.Random.Decimal(3_000_000, 100_000_000))
            .RuleFor(e => e.LaiGopThuTien, f => f.Random.Decimal(300_000, 10_000_000))
            .RuleFor(e => e.ChiPhiTrucTiep, f => f.Random.Decimal(500_000, 10_000_000))
            .RuleFor(e => e.ChiPhiPhanBo, f => f.Random.Decimal(100_000, 5_000_000))
            .RuleFor(e => e.LoiNhuan, f => f.Random.Decimal(100_000, 5_000_000));
    }
}