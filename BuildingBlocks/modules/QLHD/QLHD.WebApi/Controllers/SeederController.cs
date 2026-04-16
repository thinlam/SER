// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using QLHD.Domain.Entities;
// using QLHD.Domain.Entities.DanhMuc;
// using QLHD.Persistence;
// using QLHD.Persistence.Configurations.SeedData.DanhMuc;
// using QLHD.Persistence.Configurations.SeedData.Business;
// using QLHD.Persistence.Schema;

// namespace QLHD.WebApi.Controllers;

// /// <summary>
// /// Controller for seeding data to database.
// /// Works with schema-aware migrations - seeds data to the current schema (dbo/dev).
// /// </summary>
// [ApiController]
// [Route("api/[controller]")]
// public class SeederController(AppDbContext context) : ControllerBase
// {
//     private readonly AppDbContext _context = context;


//     /// <summary>
//     /// Get current schema name.
//     /// </summary>
//     [HttpGet("schema")]
//     public IActionResult GetSchema()
//     {
//         return Ok(new { Schema = _context.Schema });
//     }

//     /// <summary>
//     /// Seed all DanhMuc data (Layer 1 - no FK dependencies).
//     /// </summary>
//     [HttpPost("danhmuc")]
//     public async Task<IActionResult> SeedDanhMuc(CancellationToken ct)
//     {
//         var results = new List<string>();

//         // DanhMucLoaiTrangThai
//         if (!await _context.Set<DanhMucLoaiTrangThai>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucLoaiTrangThai>().AddRange(DanhMucLoaiTrangThaiSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucLoaiTrangThai seeded");
//         }
//         else
//         {
//             results.Add("DanhMucLoaiTrangThai already exists");
//         }

//         // DanhMucTrangThai
//         if (!await _context.Set<DanhMucTrangThai>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucTrangThai>().AddRange(DanhMucTrangThaiSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucTrangThai seeded");
//         }
//         else
//         {
//             results.Add("DanhMucTrangThai already exists");
//         }

//         // DanhMucLoaiHopDong
//         if (!await _context.Set<DanhMucLoaiHopDong>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucLoaiHopDong>().AddRange(DanhMucLoaiHopDongSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucLoaiHopDong seeded");
//         }
//         else
//         {
//             results.Add("DanhMucLoaiHopDong already exists");
//         }

//         // DanhMucLoaiThanhToan
//         if (!await _context.Set<DanhMucLoaiThanhToan>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucLoaiThanhToan>().AddRange(DanhMucLoaiThanhToanSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucLoaiThanhToan seeded");
//         }
//         else
//         {
//             results.Add("DanhMucLoaiThanhToan already exists");
//         }

//         // DanhMucLoaiChiPhi
//         if (!await _context.Set<DanhMucLoaiChiPhi>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucLoaiChiPhi>().AddRange(DanhMucLoaiChiPhiSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucLoaiChiPhi seeded");
//         }
//         else
//         {
//             results.Add("DanhMucLoaiChiPhi already exists");
//         }

//         // DanhMucNguoiPhuTrach
//         if (!await _context.Set<DanhMucNguoiPhuTrach>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucNguoiPhuTrach>().AddRange(DanhMucNguoiPhuTrachSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucNguoiPhuTrach seeded");
//         }
//         else
//         {
//             results.Add("DanhMucNguoiPhuTrach already exists");
//         }

//         // DanhMucNguoiTheoDoi
//         if (!await _context.Set<DanhMucNguoiTheoDoi>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucNguoiTheoDoi>().AddRange(DanhMucNguoiTheoDoiSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucNguoiTheoDoi seeded");
//         }
//         else
//         {
//             results.Add("DanhMucNguoiTheoDoi already exists");
//         }

//         // DanhMucGiamDoc
//         if (!await _context.Set<DanhMucGiamDoc>().AnyAsync(ct))
//         {
//             _context.Set<DanhMucGiamDoc>().AddRange(DanhMucGiamDocSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DanhMucGiamDoc seeded");
//         }
//         else
//         {
//             results.Add("DanhMucGiamDoc already exists");
//         }

//         return Ok(new
//         {
//             Schema = _context.Schema,
//             Results = results
//         });
//     }

//     /// <summary>
//     /// Seed all business data (Layer 2+ - has FK dependencies).
//     /// Requires DanhMuc data to be seeded first.
//     /// </summary>
//     [HttpPost("business")]
//     public async Task<IActionResult> SeedBusiness(CancellationToken ct)
//     {
//         var results = new List<string>();

//         // Layer 2: DoanhNghiep
//         if (!await _context.Set<DoanhNghiep>().AnyAsync(ct))
//         {
//             _context.Set<DoanhNghiep>().AddRange(DoanhNghiepSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DoanhNghiep seeded");
//         }
//         else
//         {
//             results.Add("DoanhNghiep already exists");
//         }

//         // Layer 2: KhachHang
//         if (!await _context.Set<KhachHang>().AnyAsync(ct))
//         {
//             _context.Set<KhachHang>().AddRange(KhachHangSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("KhachHang seeded");
//         }
//         else
//         {
//             results.Add("KhachHang already exists");
//         }

//         // Layer 2: DuAn
//         if (!await _context.Set<DuAn>().AnyAsync(ct))
//         {
//             _context.Set<DuAn>().AddRange(DuAnSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DuAn seeded");
//         }
//         else
//         {
//             results.Add("DuAn already exists");
//         }

//         // Layer 2: HopDong
//         if (!await _context.Set<HopDong>().AnyAsync(ct))
//         {
//             _context.Set<HopDong>().AddRange(HopDongSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("HopDong seeded");
//         }
//         else
//         {
//             results.Add("HopDong already exists");
//         }

//         // Layer 3: DuAnPhongBanPhoiHop
//         if (!await _context.Set<DuAnPhongBanPhoiHop>().AnyAsync(ct))
//         {
//             _context.Set<DuAnPhongBanPhoiHop>().AddRange(DuAnPhongBanPhoiHopSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DuAnPhongBanPhoiHop seeded");
//         }
//         else
//         {
//             results.Add("DuAnPhongBanPhoiHop already exists");
//         }

//         // Layer 3: HopDongPhongBanPhoiHop
//         if (!await _context.Set<HopDongPhongBanPhoiHop>().AnyAsync(ct))
//         {
//             _context.Set<HopDongPhongBanPhoiHop>().AddRange(HopDongPhongBanPhoiHopSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("HopDongPhongBanPhoiHop seeded");
//         }
//         else
//         {
//             results.Add("HopDongPhongBanPhoiHop already exists");
//         }

//         // Layer 4: CongViec
//         if (!await _context.Set<CongViec>().AnyAsync(ct))
//         {
//             _context.Set<CongViec>().AddRange(CongViecSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("CongViec seeded");
//         }
//         else
//         {
//             results.Add("CongViec already exists");
//         }

//         // Layer 4: TienDo
//         if (!await _context.Set<TienDo>().AnyAsync(ct))
//         {
//             _context.Set<TienDo>().AddRange(TienDoSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("TienDo seeded");
//         }
//         else
//         {
//             results.Add("TienDo already exists");
//         }

//         // Layer 4: BaoCaoTienDo
//         if (!await _context.Set<BaoCaoTienDo>().AnyAsync(ct))
//         {
//             _context.Set<BaoCaoTienDo>().AddRange(BaoCaoTienDoSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("BaoCaoTienDo seeded");
//         }
//         else
//         {
//             results.Add("BaoCaoTienDo already exists");
//         }

//         // Layer 4: KhoKhanVuongMac
//         if (!await _context.Set<KhoKhanVuongMac>().AnyAsync(ct))
//         {
//             _context.Set<KhoKhanVuongMac>().AddRange(KhoKhanVuongMacSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("KhoKhanVuongMac seeded");
//         }
//         else
//         {
//             results.Add("KhoKhanVuongMac already exists");
//         }

//         // Layer 4: PhuLucHopDong
//         if (!await _context.Set<PhuLucHopDong>().AnyAsync(ct))
//         {
//             _context.Set<PhuLucHopDong>().AddRange(PhuLucHopDongSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("PhuLucHopDong seeded");
//         }
//         else
//         {
//             results.Add("PhuLucHopDong already exists");
//         }

//         // Layer 4: DuAn_ThuTien
//         if (!await _context.Set<DuAn_ThuTien>().AnyAsync(ct))
//         {
//             _context.Set<DuAn_ThuTien>().AddRange(DuAn_ThuTienSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DuAn_ThuTien seeded");
//         }
//         else
//         {
//             results.Add("DuAn_ThuTien already exists");
//         }

//         // Layer 4: DuAn_XuatHoaDon
//         if (!await _context.Set<DuAn_XuatHoaDon>().AnyAsync(ct))
//         {
//             _context.Set<DuAn_XuatHoaDon>().AddRange(DuAn_XuatHoaDonSeedData.GetData());
//             await _context.SaveChangesAsync(ct);
//             results.Add("DuAn_XuatHoaDon seeded");
//         }
//         else
//         {
//             results.Add("DuAn_XuatHoaDon already exists");
//         }

//         return Ok(new
//         {
//             Schema = _context.Schema,
//             Results = results
//         });
//     }

//     /// <summary>
//     /// Seed all data (DanhMuc + Business).
//     /// </summary>
//     [HttpPost("all")]
//     public async Task<IActionResult> SeedAll(CancellationToken ct)
//     {
//         var danhmucResult = await SeedDanhMuc(ct);
//         var businessResult = await SeedBusiness(ct);

//         return Ok(new
//         {
//             Schema = _context.Schema,
//             Message = "All data seeded successfully"
//         });
//     }
// }