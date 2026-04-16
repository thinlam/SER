using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for HopDong_XuatHoaDon - Merged Plan+Actual entity for standalone contracts
/// </summary>
public class HopDong_XuatHoaDonConfiguration : AggregateRootConfiguration<HopDong_XuatHoaDon>
{
    public override void Configure(EntityTypeBuilder<HopDong_XuatHoaDon> builder)
    {
        builder.ToTable("HopDong_XuatHoaDon");
        builder.ConfigureForBase();

        // Plan fields precision
        builder.Property(e => e.GiaTriKeHoach).HasPrecision(18, 2);
        builder.Property(e => e.PhanTramKeHoach).HasPrecision(5, 2);

        // Actual fields precision (nullable)
        builder.Property(e => e.GiaTriThucTe).HasPrecision(18, 2);

        // String lengths
        builder.Property(e => e.GhiChuKeHoach).HasMaxLength(1000);
        builder.Property(e => e.GhiChuThucTe).HasMaxLength(1000);
        builder.Property(e => e.SoHoaDon).HasMaxLength(50);
        builder.Property(e => e.KyHieuHoaDon).HasMaxLength(50);

        // FK to HopDong (required - owner)
        builder.HasOne(e => e.HopDong)
            .WithMany(h => h.HopDong_XuatHoaDons)
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK to DanhMucLoaiThanhToan
        builder.HasOne(e => e.LoaiThanhToan)
            .WithMany()
            .HasForeignKey(e => e.LoaiThanhToanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}