namespace QLHD.Persistence.Configurations.SeedData;

/// <summary>
/// Centralized GUID constants for seed data.
/// Single source of truth to prevent FK constraint errors from GUID mismatches.
/// </summary>
public static class SeedDataGuids
{
    // ============================================
    // DuAn GUIDs (Project entities)
    // ============================================
    // Ordered by creation date for clarity

    public static readonly Guid DuAn_20260326_01 = new("08DE8AE1-F818-B6FB-687A-7B0EE802F6E2");
    public static readonly Guid DuAn_20260326_02 = new("08DE8B0F-54CD-F83B-687A-7B0F440558F4");
    public static readonly Guid DuAn_20260326_03 = new("08DE8AE6-F3FA-8818-687A-7B1A0405858D");
    public static readonly Guid DuAn_20260326_04 = new("08DE8AE7-2DB9-CA71-687A-7B1A04058592");
    public static readonly Guid DuAn_20260326_05 = new("08DE8AE8-8C4D-CDA7-687A-7B1A04058597");
    public static readonly Guid DuAn_20260326_06 = new("08DE8B11-66A0-889C-687A-7B2360037372");
    public static readonly Guid DuAn_20260327_01 = new("08DE8AEE-3FC7-15F0-687A-7B2F4800AAE6");
    public static readonly Guid DuAn_20260327_02 = new("08DE8AEE-575F-03BD-687A-7B2F4800AAEB");
    public static readonly Guid DuAn_20260327_03 = new("08DE8BA7-B653-D234-687A-7B311402BFED");
    public static readonly Guid DuAn_20260327_04 = new("08DE8BA8-2569-3281-687A-7B311402BFF0");
    public static readonly Guid DuAn_20260327_05 = new("08DE8BA8-407A-7691-687A-7B311402BFFD");
    public static readonly Guid DuAn_20260327_06 = new("08DE8BA8-ECDB-8025-687A-7B311402C012");
    public static readonly Guid DuAn_20260327_07 = new("08DE8BA9-007A-9B89-687A-7B311402C017");
    public static readonly Guid DuAn_20260327_08 = new("08DE8BA9-024C-0844-687A-7B311402C01C");
    public static readonly Guid DuAn_20260330_01 = new("08DE8E03-F82D-F499-687A-7B31F0054948");
    public static readonly Guid DuAn_20260330_02 = new("08DE8E33-4B37-76DD-687A-7B2AD003CB6F"); // Was missing!

    // ============================================
    // CongViec GUIDs (Work items)
    // ============================================
    public static readonly Guid CongViec_01 = new("08DE8B1A-3426-D860-687A-7B2360037375");
    public static readonly Guid CongViec_02 = new("08DE8B1B-12B8-88B4-687A-7B2360037380");
    public static readonly Guid CongViec_03 = new("08DE8B1D-8705-A758-687A-7B23600373A1");
    public static readonly Guid CongViec_04 = new("08DE8E33-5D56-8DB5-687A-7B2AD003CB7A");
    public static readonly Guid CongViec_05 = new("08DE8BAD-246C-0EC3-687A-7B311402C058");
    public static readonly Guid CongViec_06 = new("08DE8E05-F0C7-4774-687A-7B31F0054967");

    // ============================================
    // KhachHang GUIDs
    // ============================================
    public static readonly Guid KhachHang_01 = new("12930000-0000-0000-0000-000000000001");
    public static readonly Guid KhachHang_02 = new("12940000-0000-0000-0000-000000000001");

    // ============================================
    // HopDong GUIDs (Contract entities)
    // ============================================
    public static readonly Guid HopDong_01 = new("08DE8AEC-F8DC-6A15-687A-7B1E60040EAB");
    public static readonly Guid HopDong_02 = new("08DE8E34-0E94-CBE5-687A-7B2AD003CB9E");
    public static readonly Guid HopDong_03 = new("08DE8E34-4CC7-D0C2-687A-7B2AD003CBA3");
    public static readonly Guid HopDong_04 = new("08DE8BA9-3C5F-E033-687A-7B311402C029");
    public static readonly Guid HopDong_05 = new("08DE8BA9-EC59-9CB7-687A-7B311402C046");
    public static readonly Guid HopDong_06 = new("08DE8BAA-2AFF-9D92-687A-7B311402C04C");
    public static readonly Guid HopDong_07 = new("08DE8E04-EA40-BC98-687A-7B31F0054957");
    public static readonly Guid HopDong_08 = new("08DE8BA4-93AF-0560-687A-7B374803A052");
    public static readonly Guid HopDong_09 = new("08DE8AE2-8EB5-87C9-4BAF-8361500292E3");
}