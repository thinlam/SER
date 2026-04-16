using BuildingBlocks.Domain.ValueTypes;
using QLHD.Application.ChiPhis.DTOs;
using QLHD.Application.CongViecs.DTOs;
using QLHD.Application.HopDongs.DTOs;
using QLHD.Application.ThuTiens.DTOs;
using QLHD.Domain.Entities;

namespace QLHD.Tests.Integration.Infrastructure.Fakers;

/// <summary>
/// Generates fake test data with proper FK relationships.
/// Use in integration tests for quick test data creation.
/// </summary>
public class FakeDataGenerator
{
    /// <summary>
    /// Generate complete test dataset: KhachHang + HopDong + ChiPhi + ThuTien.
    /// Respects FK dependencies and unique constraints.
    /// </summary>
    public static GeneratedData Generate(
        int seed = 12345,
        int khachHangCount = 2,
        int hopDongPerKhachHang = 3,
        int chiPhiPerHopDong = 2,
        int thuTienPerHopDong = 3)
    {
        QLHDFakers.SetSeed(seed);

        var result = new GeneratedData();

        // Level 1: Generate KhachHangs
        var khachHangs = QLHDFakers.KhachHangFaker()
            .Generate(khachHangCount);
        result.KhachHangs = khachHangs;

        // Level 2: Generate HopDongs for each KhachHang
        var hopDongs = new List<HopDong>();
        foreach (var kh in khachHangs)
        {
            var contracts = QLHDFakers.HopDongFaker(kh.Id)
                .Generate(hopDongPerKhachHang);
            hopDongs.AddRange(contracts);
        }
        result.HopDongs = hopDongs;

        // Level 3: Generate ChiPhi and ThuTien for each HopDong
        var chiPhis = new List<HopDong_ChiPhi>();
        var thuTiens = new List<HopDong_ThuTien>();

        foreach (var hd in hopDongs)
        {
            chiPhis.AddRange(QLHDFakers.ChiPhiFaker(hd.Id).Generate(chiPhiPerHopDong));
            thuTiens.AddRange(QLHDFakers.ThuTienFaker(hd.Id).Generate(thuTienPerHopDong));
        }
        result.ChiPhis = chiPhis;
        result.ThuTiens = thuTiens;

        return result;
    }

    /// <summary>
    /// Generate a single HopDong InsertModel for quick API testing.
    /// Uses seeded KhachHang (FKReferenceData.KhachHangId).
    /// </summary>
    public static HopDongInsertModel GenerateSingleHopDongModel(int seed = 12345)
    {
        QLHDFakers.SetSeed(seed);

        var hopDong = QLHDFakers.HopDongFaker(FKReferenceData.KhachHangId)
            .Generate();

        return new HopDongInsertModel
        {
            SoHopDong = hopDong.SoHopDong,
            Ten = hopDong.Ten,
            KhachHangId = hopDong.KhachHangId,
            DuAnId = hopDong.DuAnId,
            NgayKy = hopDong.NgayKy,
            SoNgay = hopDong.SoNgay,
            NgayNghiemThu = hopDong.NgayNghiemThu,
            LoaiHopDongId = hopDong.LoaiHopDongId,
            TrangThaiHopDongId = hopDong.TrangThaiId,
            NguoiPhuTrachChinhId = hopDong.NguoiPhuTrachChinhId,
            NguoiTheoDoiId = hopDong.NguoiTheoDoiId,
            GiamDocId = hopDong.GiamDocId,
            GiaTri = hopDong.GiaTri,
            TienThue = hopDong.TienThue,
            GiaTriSauThue = hopDong.GiaTriSauThue,
            PhongBanPhuTrachChinhId = hopDong.PhongBanPhuTrachChinhId,
            GiaTriBaoLanh = hopDong.GiaTriBaoLanh,
            ThoiHanBaoHanh = hopDong.ThoiHanBaoHanh,
            GhiChu = hopDong.GhiChu
        };
    }

    /// <summary>
    /// Generate ChiPhi InsertModel for API testing.
    /// </summary>
    public static ChiPhiInsertOrUpdateModel GenerateChiPhiModel(Guid hopDongId, int seed = 12345)
    {
        QLHDFakers.SetSeed(seed);

        var chiPhi = QLHDFakers.ChiPhiFaker(hopDongId).Generate();

        return new ChiPhiInsertOrUpdateModel
        {
            HopDongId = chiPhi.HopDongId,
            LoaiChiPhiId = chiPhi.LoaiChiPhiId,
            Nam = chiPhi.Nam,
            LanChi = chiPhi.LanChi,
            ThoiGianKeHoach = MonthYear.FromDateOnly(chiPhi.ThoiGianKeHoach),
            PhanTramKeHoach = chiPhi.PhanTramKeHoach,
            GiaTriKeHoach = chiPhi.GiaTriKeHoach,
            GhiChuKeHoach = chiPhi.GhiChuKeHoach
        };
    }

    /// <summary>
    /// Generate ThuTien InsertModel for API testing.
    /// </summary>
    public static ThuTienInsertOrUpdateModel GenerateThuTienModel(Guid hopDongId, int seed = 12345)
    {
        QLHDFakers.SetSeed(seed);

        var thuTien = QLHDFakers.ThuTienFaker(hopDongId).Generate();

        return new ThuTienInsertOrUpdateModel
        {
            HopDongId = thuTien.HopDongId,
            LoaiThanhToanId = thuTien.LoaiThanhToanId,
            ThoiGianKeHoach = MonthYear.FromDateOnly(thuTien.ThoiGianKeHoach),
            PhanTramKeHoach = thuTien.PhanTramKeHoach,
            GiaTriKeHoach = thuTien.GiaTriKeHoach,
            GhiChuKeHoach = thuTien.GhiChuKeHoach
        };
    }

    /// <summary>
    /// Generate CongViec InsertModel for API testing.
    /// Uses seeded DuAn (FKReferenceData.DuAnId).
    /// </summary>
    public static CongViecInsertModel GenerateCongViecModel(Guid? duAnId = null, int seed = 12345)
    {
        QLHDFakers.SetSeed(seed);

        var congViec = QLHDFakers.CongViecFaker(duAnId ?? FKReferenceData.DuAnId)
            .Generate();

        return new CongViecInsertModel
        {
            DuAnId = congViec.DuAnId,
            ThoiGian = MonthYear.FromDateOnly(congViec.ThoiGian),
            UserPortalId = congViec.UserPortalId,
            DonViId = congViec.DonViId,
            PhongBanId = congViec.PhongBanId,
            KeHoachCongViec = congViec.KeHoachCongViec,
            NgayHoanThanh = congViec.NgayHoanThanh,
            ThucTe = congViec.ThucTe,
            TrangThaiId = congViec.TrangThaiId
        };
    }
}

/// <summary>
/// Container for generated test data.
/// </summary>
public class GeneratedData
{
    public List<KhachHang> KhachHangs { get; set; } = [];
    public List<HopDong> HopDongs { get; set; } = [];
    public List<HopDong_ChiPhi> ChiPhis { get; set; } = [];
    public List<HopDong_ThuTien> ThuTiens { get; set; } = [];
}