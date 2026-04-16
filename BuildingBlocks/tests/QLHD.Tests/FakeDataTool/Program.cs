using System.Net.Http.Json;
using System.Text.Json;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QLHD.Application;
using QLHD.Domain.Entities;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence;
using QLHD.Tests.Integration.Infrastructure.Fakers;

namespace QLHD.Tests.FakeDataTool;

/// <summary>
/// CLI tool to generate and insert fake data.
/// Supports: JSON output, HTTP API insertion, Direct DB insertion.
/// </summary>
class Program {
    private static IConfiguration? _configuration;
    private static IServiceProvider? _serviceProvider;
    private static readonly HttpClient _httpClient = new();

    static async Task<int> Main(string[] args) {
        if (args.Length == 0 || args[0] == "--help" || args[0] == "-h") {
            PrintHelp();
            return 0;
        }

        // Build configuration - use executable directory so it works from any location
        var executablePath = AppContext.BaseDirectory;
        _configuration = new ConfigurationBuilder()
            .SetBasePath(executablePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        // Parse flags
        var seed = GetArgValue(args, "--seed", "12345");
        var insert = args.Contains("--insert") || args.Contains("-i");
        var direct = args.Contains("--direct") || args.Contains("-d");
        var apiBase = GetArgValue(args, "--api", "http://localhost:5000");
        var token = GetArgValue(args, "--token", "");
        // Parse flags (schema defaults to value from appsettings.json)
        var schema = GetArgValue(args, "--schema", _configuration["ConnectionStrings:Schema"] ?? "dbo");

        // Remove flags from args for positional parsing
        var filteredArgs = args
            .Where((a, i) => !a.StartsWith("-") && (i == 0 || !args[i - 1].StartsWith("-")))
            .ToArray();

        if (filteredArgs.Length == 0) {
            Console.Error.WriteLine("Error: Missing entity name");
            PrintHelp();
            return 1;
        }

        // Detect if first arg is module name or entity name
        // Pattern 1: fake.bat <module> <entity> [count] (e.g., "QLHD cv 5")
        // Pattern 2: fake.bat <entity> [count] (e.g., "cv 5" - uses default module)
        var validModules = new[] { "qlhd", "dvdc", "qlda", "nvtt", "bb" };
        var firstArgLower = filteredArgs[0].ToLowerInvariant();

        string module;
        string entity;
        int count;

        if (validModules.Contains(firstArgLower)) {
            // Pattern 1: Module is first arg
            module = firstArgLower;
            if (filteredArgs.Length < 2) {
                Console.Error.WriteLine("Error: Missing entity name after module");
                PrintHelp();
                return 1;
            }
            entity = filteredArgs[1].ToLowerInvariant();
            count = filteredArgs.Length > 2 && int.TryParse(filteredArgs[2], out var c) ? c : 1;
        } else {
            // Pattern 2: Module from flag or default
            module = GetArgValue(args, "-m", "--module", "qlhd").ToLowerInvariant();
            entity = firstArgLower;
            count = filteredArgs.Length > 1 && int.TryParse(filteredArgs[1], out var c) ? c : 1;
        }

        QLHDFakers.SetSeed(int.Parse(seed));

        try {
            var data = GenerateData(module, entity, count, args);

            if (direct) {
                var inserted = await InsertDirect(entity, data, schema);
                Console.WriteLine($"Inserted {inserted} record(s) directly to database (schema: {schema})");
                return 0;
            }

            if (insert) {
                _httpClient.BaseAddress = new Uri(apiBase);
                if (!string.IsNullOrEmpty(token)) {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                var inserted = await InsertViaApi(module, entity, data);
                Console.WriteLine($"Inserted {inserted} record(s) via API");
                return 0;
            }

            await OutputResult(data);
            return 0;
        } catch (Exception ex) {
            Console.Error.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null)
                Console.Error.WriteLine($"Inner: {ex.InnerException.Message}");
            return 1;
        }
    }

    static object GenerateData(string module, string entity, int count, string[] args) {
        var duAnId = GetArgValue(args, "--duan-id", FKReferenceData.DuAnId.ToString());
        var hopDongId = GetArgValue(args, "--hopdong-id", Guid.NewGuid().ToString());

        return (module, entity) switch {
            ("qlhd", "congviec" or "cv") => GenerateCongViecModels(count, Guid.Parse(duAnId)),
            ("qlhd", "khachhang" or "kh") => GenerateKhachHangModels(count),
            ("qlhd", "hopdong" or "hd") => GenerateHopDongModels(count, Guid.Parse(GetArgValue(args, "--khachhang-id", FKReferenceData.KhachHangId.ToString()))),
            ("qlhd", "hopdongthutien" or "hdtt") => GenerateHopDongThuTienModels(count, Guid.Parse(GetArgValue(args, "--hopdong-id", FKReferenceData.HopDongId.ToString())), int.Parse(GetArgValue(args, "--loaithanhtoan-id", FKReferenceData.LoaiThanhToanThang.ToString()))),
            ("qlhd", "hopdongxuathoadon" or "hdxhd") => GenerateHopDongXuatHoaDonModels(count, Guid.Parse(GetArgValue(args, "--hopdong-id", FKReferenceData.HopDongId.ToString())), int.Parse(GetArgValue(args, "--loaithanhtoan-id", FKReferenceData.LoaiThanhToanThang.ToString()))),
            ("qlhd", "khkd" or "kehoachkinhdoanhnam") => GenerateKeHoachKinhDoanhNamModels(count),
            ("qlhd", "khkdbp" or "kehoachkinhdoanhnambophan") => GenerateKeHoachKinhDoanhNamBoPhanModels(count, Guid.Parse(GetArgValue(args, "--khkd-id", Guid.NewGuid().ToString())), long.Parse(GetArgValue(args, "--donvi-id", FKReferenceData.DonViId.ToString()))),
            ("qlhd", "khkdcn" or "kehoachkinhdoanhnamcanhan") => GenerateKeHoachKinhDoanhNamCaNhanModels(count, Guid.Parse(GetArgValue(args, "--khkd-id", Guid.NewGuid().ToString()))),
            // Add more entities as needed
            _ => throw new ArgumentException($"Unknown module/entity: {module}/{entity}")
        };
    }

    static object GenerateCongViecModels(int count, Guid duAnId) {
        var entities = QLHDFakers.CongViecFaker(duAnId).Generate(count);
        return count == 1 ? entities[0] : entities;
    }

    static object GenerateKhachHangModels(int count) {
        var entities = QLHDFakers.KhachHangFaker().Generate(count);
        return count == 1 ? entities[0] : entities;
    }

    static object GenerateHopDongModels(int count, Guid khachHangId) {
        var entities = QLHDFakers.HopDongFaker(khachHangId).Generate(count);
        return count == 1 ? entities[0] : entities;
    }
    static object GenerateHopDongThuTienModels(int count, Guid hopDongId, int loaiThanhToanId) {
        var entities = QLHDFakers.HopDongThuTienFaker(hopDongId, loaiThanhToanId).Generate(count);
        return count == 1 ? entities[0] : entities;
    }
    static object GenerateHopDongXuatHoaDonModels(int count, Guid hopDongId, int loaiThanhToanId) {
        var entities = QLHDFakers.HopDongXuatHoaDonFaker(hopDongId, loaiThanhToanId).Generate(count);
        return count == 1 ? entities[0] : entities;
    }

    static object GenerateKeHoachKinhDoanhNamModels(int count) {
        var entities = QLHDFakers.KeHoachKinhDoanhNamFaker().Generate(count);
        return count == 1 ? entities[0] : entities;
    }

    static object GenerateKeHoachKinhDoanhNamBoPhanModels(int count, Guid keHoachKinhDoanhNamId, long donViId) {
        var entities = QLHDFakers.KeHoachKinhDoanhNamBoPhanFaker(keHoachKinhDoanhNamId, donViId).Generate(count);
        return count == 1 ? entities[0] : entities;
    }

    static object GenerateKeHoachKinhDoanhNamCaNhanModels(int count, Guid keHoachKinhDoanhNamId) {
        var entities = QLHDFakers.KeHoachKinhDoanhNamCaNhanFaker(keHoachKinhDoanhNamId).Generate(count);
        return count == 1 ? entities[0] : entities;
    }

    #region Direct DB Insertion

    static IServiceProvider BuildServiceProvider(string schema) {
        var services = new ServiceCollection();

        // Register IConfiguration so AppDbContext can inject it
        services.AddSingleton(_configuration!);

        // Register DateTimeProvider (required by AppDbContext audit)
        services.AddDateTimeProvider();

        // Register HttpContextAccessor (required by audit interceptor)
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        var connectionStrings = new ConnectionStrings {
            DefaultConnection = _configuration!["ConnectionStrings:DefaultConnection"]!,
            Schema = schema
        };

        services.AddQlhdPersistence(connectionStrings);
        services.AddQlhdApplication();

        return services.BuildServiceProvider();
    }

    static async Task<int> InsertDirect(string entity, object data, string schema) {
        _serviceProvider ??= BuildServiceProvider(schema);
        using var scope = _serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var count = 0;

        switch (data) {
            case CongViec cv:
                // Auto-seed DuAn if not exists
                await EnsureDuAnExists(db, cv.DuAnId);
                db.Set<CongViec>().Add(cv);
                count = 1;
                break;
            case IList<CongViec> cvList:
                // Auto-seed all DuAns if not exist
                var duAnIds = cvList.Select(c => c.DuAnId).Distinct();
                foreach (var daId in duAnIds)
                    await EnsureDuAnExists(db, daId);
                db.Set<CongViec>().AddRange(cvList);
                count = cvList.Count;
                break;
            case KhachHang kh:
                db.Set<KhachHang>().Add(kh);
                count = 1;
                break;
            case IList<KhachHang> khList:
                db.Set<KhachHang>().AddRange(khList);
                count = khList.Count;
                break;
            case HopDong hd:
                // Auto-seed KhachHang if not exists
                await EnsureKhachHangExists(db, hd.KhachHangId);
                db.Set<HopDong>().Add(hd);
                count = 1;
                break;
            case IList<HopDong> hdList:
                // Auto-seed all KhachHangs if not exist
                var khachHangIds = hdList.Select(h => h.KhachHangId).Distinct();
                foreach (var khId in khachHangIds)
                    await EnsureKhachHangExists(db, khId);
                db.Set<HopDong>().AddRange(hdList);
                count = hdList.Count;
                break;
            case HopDong_ThuTien hdtt:
                // Auto-seed dependencies (must be standalone HopDong - no DuAnId)
                await EnsureHopDongExists(db, hdtt.HopDongId, mustBeStandalone: true);
                await EnsureDanhMucLoaiThanhToanExists(db, hdtt.LoaiThanhToanId);
                db.Set<HopDong_ThuTien>().Add(hdtt);
                count = 1;
                break;
            case IList<HopDong_ThuTien> hdttList:
                // Auto-seed all dependencies (must be standalone HopDong)
                var hdIds = hdttList.Select(h => h.HopDongId).Distinct();
                foreach (var hdId in hdIds)
                    await EnsureHopDongExists(db, hdId, mustBeStandalone: true);
                var lttIds = hdttList.Select(h => h.LoaiThanhToanId).Distinct();
                foreach (var lttId in lttIds)
                    await EnsureDanhMucLoaiThanhToanExists(db, lttId);
                db.Set<HopDong_ThuTien>().AddRange(hdttList);
                count = hdttList.Count;
                break;
            case HopDong_XuatHoaDon hdxhd:
                // Auto-seed dependencies (must be standalone HopDong - no DuAnId)
                await EnsureHopDongExists(db, hdxhd.HopDongId, mustBeStandalone: true);
                await EnsureDanhMucLoaiThanhToanExists(db, hdxhd.LoaiThanhToanId);
                db.Set<HopDong_XuatHoaDon>().Add(hdxhd);
                count = 1;
                break;
            case IList<HopDong_XuatHoaDon> hdxhdList:
                // Auto-seed all dependencies (must be standalone HopDong)
                var hdxhdIds = hdxhdList.Select(h => h.HopDongId).Distinct();
                foreach (var hdId in hdxhdIds)
                    await EnsureHopDongExists(db, hdId, mustBeStandalone: true);
                var lttXhIds = hdxhdList.Select(h => h.LoaiThanhToanId).Distinct();
                foreach (var lttId in lttXhIds)
                    await EnsureDanhMucLoaiThanhToanExists(db, lttId);
                db.Set<HopDong_XuatHoaDon>().AddRange(hdxhdList);
                count = hdxhdList.Count;
                break;
            case KeHoachKinhDoanhNam khkd:
                db.Set<KeHoachKinhDoanhNam>().Add(khkd);
                count = 1;
                break;
            case IList<KeHoachKinhDoanhNam> khkdList:
                db.Set<KeHoachKinhDoanhNam>().AddRange(khkdList);
                count = khkdList.Count;
                break;
            case KeHoachKinhDoanhNam_BoPhan khkdbp:
                // Auto-seed parent if not exists
                await EnsureKeHoachKinhDoanhNamExists(db, khkdbp.KeHoachKinhDoanhNamId);
                db.Set<KeHoachKinhDoanhNam_BoPhan>().Add(khkdbp);
                count = 1;
                break;
            case IList<KeHoachKinhDoanhNam_BoPhan> khkdbpList:
                // Auto-seed all parents if not exist
                var khkdParentIds = khkdbpList.Select(b => b.KeHoachKinhDoanhNamId).Distinct();
                foreach (var parentId in khkdParentIds)
                    await EnsureKeHoachKinhDoanhNamExists(db, parentId);
                db.Set<KeHoachKinhDoanhNam_BoPhan>().AddRange(khkdbpList);
                count = khkdbpList.Count;
                break;
            case KeHoachKinhDoanhNam_CaNhan khkdcn:
                // Auto-seed parent if not exists
                await EnsureKeHoachKinhDoanhNamExists(db, khkdcn.KeHoachKinhDoanhNamId);
                db.Set<KeHoachKinhDoanhNam_CaNhan>().Add(khkdcn);
                count = 1;
                break;
            case IList<KeHoachKinhDoanhNam_CaNhan> khkdcnList:
                // Auto-seed all parents if not exist
                var khkdcnParentIds = khkdcnList.Select(c => c.KeHoachKinhDoanhNamId).Distinct();
                foreach (var parentId in khkdcnParentIds)
                    await EnsureKeHoachKinhDoanhNamExists(db, parentId);
                db.Set<KeHoachKinhDoanhNam_CaNhan>().AddRange(khkdcnList);
                count = khkdcnList.Count;
                break;
            default:
                throw new ArgumentException($"Unsupported entity type: {data.GetType()}");
        }

        await db.SaveChangesAsync();
        return count;
    }

    /// <summary>
    /// Ensure KhachHang exists, create if not. Used for FK dependency.
    /// </summary>
    static async Task EnsureKhachHangExists(AppDbContext db, Guid khachHangId) {
        var exists = await db.Set<KhachHang>().AnyAsync(k => k.Id == khachHangId);
        if (!exists) {
            var kh = QLHDFakers.KhachHangFaker().Generate();
            kh.Id = khachHangId; // Use the specified ID
            db.Set<KhachHang>().Add(kh);
            Console.WriteLine($"Auto-seeded KhachHang: {khachHangId}");
        }
    }

    /// <summary>
    /// Ensure DuAn exists, create if not. Used for FK dependency.
    /// Also auto-seeds KhachHang if needed.
    /// </summary>
    static async Task EnsureDuAnExists(AppDbContext db, Guid duAnId) {
        var exists = await db.Set<DuAn>().AnyAsync(d => d.Id == duAnId);
        if (!exists) {
            // Generate a KhachHangId for this DuAn
            var khachHangId = Guid.NewGuid();
            await EnsureKhachHangExists(db, khachHangId);

            var da = QLHDFakers.DuAnFaker(khachHangId).Generate();
            da.Id = duAnId; // Use the specified ID
            db.Set<DuAn>().Add(da);
            Console.WriteLine($"Auto-seeded DuAn: {duAnId}");
        }
    }

    /// <summary>
    /// Ensure HopDong exists, create if not. Used for FK dependency.
    /// Also auto-seeds KhachHang if needed.
    /// </summary>
    /// <param name="db">Database context</param>
    /// <param name="hopDongId">HopDong ID to ensure exists</param>
    /// <param name="mustBeStandalone">If true, validates that HopDong.DuAnId is null (for hdtt/hdxhd)</param>
    static async Task EnsureHopDongExists(AppDbContext db, Guid hopDongId, bool mustBeStandalone = false) {
        var hopDong = await db.Set<HopDong>().FirstOrDefaultAsync(h => h.Id == hopDongId);

        if (hopDong == null) {
            // Generate a KhachHangId for this HopDong
            var khachHangId = Guid.NewGuid();
            await EnsureKhachHangExists(db, khachHangId);

            // Create standalone HopDong (DuAnId = null) - always null for auto-seeded
            var hd = QLHDFakers.HopDongFaker(khachHangId, duAnId: null).Generate();
            hd.Id = hopDongId;
            db.Set<HopDong>().Add(hd);
            Console.WriteLine($"Auto-seeded HopDong (standalone): {hopDongId}");
        } else if (mustBeStandalone && hopDong.DuAnId.HasValue) {
            // Validation: HopDong has DuAnId, cannot create HopDong_ThuTien/XuatHoaDon
            throw new InvalidOperationException(
                $"HopDong '{hopDongId}' có DuAnId '{hopDong.DuAnId}'. " +
                "Hợp đồng thuộc dự án phải sử dụng DuAn_ThuTien/DuAn_XuatHoaDon thay vì HopDong_ThuTien/HopDong_XuatHoaDon.");
        }
    }

    /// <summary>
    /// Ensure DanhMucLoaiThanhToan exists, create if not. Used for FK dependency.
    /// </summary>
    static async Task EnsureDanhMucLoaiThanhToanExists(AppDbContext db, int loaiThanhToanId) {
        var exists = await db.Set<DanhMucLoaiThanhToan>().AnyAsync(l => l.Id == loaiThanhToanId);
        if (!exists) {
            var ltt = new DanhMucLoaiThanhToan {
                Id = loaiThanhToanId,
                Ma = $"LT{loaiThanhToanId:D3}",
                Ten = $"Loại thanh toán {loaiThanhToanId}",
                Used = true,
                IsDefault = loaiThanhToanId == 1,
                CreatedAt = new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero)
            };
            db.Set<DanhMucLoaiThanhToan>().Add(ltt);
            Console.WriteLine($"Auto-seeded DanhMucLoaiThanhToan: {loaiThanhToanId}");
        }
    }

    /// <summary>
    /// Ensure KeHoachKinhDoanhNam exists, create if not. Used for FK dependency of child entities.
    /// </summary>
    static async Task EnsureKeHoachKinhDoanhNamExists(AppDbContext db, Guid keHoachKinhDoanhNamId) {
        var exists = await db.Set<KeHoachKinhDoanhNam>().AnyAsync(k => k.Id == keHoachKinhDoanhNamId);
        if (!exists) {
            var khkd = QLHDFakers.KeHoachKinhDoanhNamFaker().Generate();
            khkd.Id = keHoachKinhDoanhNamId;
            db.Set<KeHoachKinhDoanhNam>().Add(khkd);
            Console.WriteLine($"Auto-seeded KeHoachKinhDoanhNam: {keHoachKinhDoanhNamId}");
        }
    }

    #endregion

    #region HTTP API Insertion

    static async Task<int> InsertViaApi(string module, string entity, object data) {
        var endpoint = GetApiEndpoint(module, entity);
        var models = data is IList<object> list ? list : new List<object> { data };

        var successCount = 0;
        foreach (var model in models) {
            try {
                var response = await _httpClient.PostAsJsonAsync(endpoint, model);
                response.EnsureSuccessStatusCode();
                successCount++;
            } catch (HttpRequestException ex) {
                Console.Error.WriteLine($"Failed to insert: {ex.Message}");
            }
        }

        return successCount;
    }

    static string GetApiEndpoint(string module, string entity) {
        return (module, entity) switch {
            ("qlhd", "congviec" or "cv") => "api/cong-viec/them-moi",
            ("qlhd", "khachhang" or "kh") => "api/khach-hang/them-moi",
            ("qlhd", "hopdong" or "hd") => "api/hop-dong/them-moi",
            // Add more endpoints as needed
            _ => throw new ArgumentException($"No API endpoint for: {module}/{entity}")
        };
    }

    #endregion

    static async Task OutputResult(object data) {
        var options = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var json = JsonSerializer.Serialize(data, options);
        await Console.Out.WriteLineAsync(json);
    }

    static string GetArgValue(string[] args, string flag1, string flag2, string defaultValue) {
        var idx1 = Array.IndexOf(args, flag1);
        var idx2 = Array.IndexOf(args, flag2);
        var flagIndex = idx1 >= 0 ? idx1 : idx2;
        return flagIndex >= 0 && flagIndex + 1 < args.Length ? args[flagIndex + 1] : defaultValue;
    }

    static string GetArgValue(string[] args, string flag, string defaultValue)
        => GetArgValue(args, flag, flag, defaultValue);

    static void PrintHelp() {
        Console.WriteLine(@"
Fake Data Generator
===================

Usage:
  fake.bat [module] <entity> [count] [options]
  fake.bat <entity> [count] [options]  (uses default module: qlhd)

Modules:
  QLHD   Quản lý hợp đồng (default)
  DVDC   Dịch vụ dùng chung
  QLDA   Quản lý dự án
  NVTT   Nhiệm vụ trọng tâm
  BB     BuildingBlocks

Modes:
  Default          JSON output only
  -i, --insert     Insert via HTTP API (requires --api)
  -d, --direct     Insert directly to database (no API required)

Options:
  --schema <name>       Database schema: dbo or dev (default: from appsettings.json)
  --seed <value>        Random seed (default: 12345)
  --api <url>           API base URL (default: http://localhost:5000)
  --token <string>      Bearer token for authentication

QLHD Entity Aliases:
  cv, congviec            Công việc (dev schema)
  kh, khachhang           Khách hàng
  hd, hopdong             Hợp đồng
  hdtt, hopdongthutien    Thu tiền hợp đồng
  hdxhd, hopdongxuathoadon Xuất hóa đơn hợp đồng
  khkd, kehoachkinhdoanhnam Kế hoạch kinh doanh năm (parent)
  khkdbp, kehoachkinhdoanhnambophan Kế hoạch KD năm - Bộ phận
  khkdcn, kehoachkinhdoanhnamcanhan Kế hoạch KD năm - Cá nhân

FK Options:
  --khachhang-id <guid>       KhachHangId for hd (default: seed data)
  --hopdong-id <guid>         HopDongId for hdtt/hdxhd (default: seed data)
  --loaithanhtoan-id <int>    LoaiThanhToanId for hdtt/hdxhd (default: 1)
  --khkd-id <guid>            KeHoachKinhDoanhNamId for khkdbp/khkdcn (default: new Guid)
  --donvi-id <long>           DonViId for khkdbp (default: 49)

Examples:
  # JSON output only (default module: QLHD)
  fake.bat kh 5

  # Explicit module + entity
  fake.bat QLHD kh 5

  # Direct insert with dev schema
  fake.bat QLHD kh 5 --direct --schema dev

  # Direct insert to dev schema (schema from appsettings.json)
  fake.bat QLHD cv 5 --direct

  # HopDong_ThuTien with custom FK
  fake.bat QLHD hdtt 3 --direct --hopdong-id <guid> --loaithanhtoan-id 2

  # HopDong_XuatHoaDon with custom FK
  fake.bat QLHD hdxhd 3 --direct --hopdong-id <guid> --loaithanhtoan-id 2

  # API insert (requires running API + token)
  fake.bat QLHD kh 5 -i --api http://localhost:5000 --token ""your-jwt-token""

  # Generate with custom FK
  fake.bat QLHD hd 3 --khachhang-id 00000000-0000-0000-0000-000000000001

  # KeHoachKinhDoanhNam (annual business plan)
  fake.bat QLHD khkd 5 --direct

  # KeHoachKinhDoanhNam_BoPhan with custom parent FK
  fake.bat QLHD khkdbp 3 --direct --khkd-id <guid> --donvi-id 220

  # KeHoachKinhDoanhNam_CaNhan with custom parent FK
  fake.bat QLHD khkdcn 3 --direct --khkd-id <guid>
");
    }
}