using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for HopDongPhongBanPhoiHop junction table.
/// Maps LeftId → HopDongId and RightId → PhongBanId database columns.
/// Note: No FK to DmDonVi (legacy table) - use LeftOuterJoin in queries.
/// </summary>
public class HopDongPhongBanPhoiHopConfiguration : IEntityTypeConfiguration<HopDongPhongBanPhoiHop> {
    public void Configure(EntityTypeBuilder<HopDongPhongBanPhoiHop> builder) {
        builder.ToTable("HopDongPhongBanPhoiHop");

        // Composite primary key
        builder.HasKey(e => new { e.LeftId, e.RightId });

        // Map LeftId property to HopDongId column
        builder.Property(e => e.LeftId)
            .HasColumnName("HopDongId");

        // Map RightId property to PhongBanId column
        builder.Property(e => e.RightId)
            .HasColumnName("PhongBanId");

        // TenPhongBan column (denormalized from DmDonVi)
        builder.Property(e => e.TenPhongBan)
            .HasMaxLength(255);

        // FK to HopDong only (no FK to DmDonVi - legacy table)
        builder.HasOne(e => e.HopDong)
            .WithMany(e => e.PhongBanPhoiHops)
            .HasForeignKey(e => e.LeftId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedHopDongPhongBanPhoiHop();
    }
}