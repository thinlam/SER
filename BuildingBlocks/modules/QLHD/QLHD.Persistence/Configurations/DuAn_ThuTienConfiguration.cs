using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for DuAn_ThuTien - Merged Plan+Actual entity
/// </summary>
public class DuAn_ThuTienConfiguration : AggregateRootConfiguration<DuAn_ThuTien>
{
    public override void Configure(EntityTypeBuilder<DuAn_ThuTien> builder)
    {
        builder.ToTable("DuAn_ThuTien");
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

        // FK to DuAn (required - owner)
        builder.HasOne(e => e.DuAn)
            .WithMany(d => d.DuAn_ThuTiens)
            .HasForeignKey(e => e.DuAnId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK to HopDong (nullable - for execution tracking)
        builder.HasOne(e => e.HopDong)
            .WithMany()
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.SetNull);

        // FK to DanhMucLoaiThanhToan
        builder.HasOne(e => e.LoaiThanhToan)
            .WithMany()
            .HasForeignKey(e => e.LoaiThanhToanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}