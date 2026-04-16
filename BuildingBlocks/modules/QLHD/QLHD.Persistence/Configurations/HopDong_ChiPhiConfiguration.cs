using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for HopDong_ChiPhi - Merged Plan+Actual entity for standalone contracts
/// </summary>
public class HopDong_ChiPhiConfiguration : AggregateRootConfiguration<HopDong_ChiPhi> {
    public override void Configure(EntityTypeBuilder<HopDong_ChiPhi> builder) {
        builder.ToTable("HopDong_ChiPhi");
        builder.ConfigureForBase();

        // Plan fields precision
        builder.Property(e => e.GiaTriKeHoach).HasPrecision(18, 2);
        builder.Property(e => e.PhanTramKeHoach).HasPrecision(5, 2);

        // Actual fields precision (nullable)
        builder.Property(e => e.GiaTriThucTe).HasPrecision(18, 2);

        // String lengths
        builder.Property(e => e.GhiChuKeHoach).HasMaxLength(2000);

        // String lengths
        builder.Property(e => e.GhiChuThucTe).HasMaxLength(2000);

        // FK to HopDong (required - owner)
        builder.HasOne(e => e.HopDong)
            .WithMany(h => h.HopDong_ChiPhis)
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK to DanhMucLoaiChiPhi
        builder.HasOne(e => e.LoaiChiPhi)
            .WithMany()
            .HasForeignKey(e => e.LoaiChiPhiId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}