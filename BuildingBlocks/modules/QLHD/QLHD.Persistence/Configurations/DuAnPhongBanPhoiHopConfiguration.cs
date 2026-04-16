using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for DuAnPhongBanPhoiHop junction table.
/// Maps LeftId → DuAnId and RightId → PhongBanId database columns.
/// Note: No FK to DmDonVi (legacy table) - use LeftOuterJoin in queries.
/// </summary>
public class DuAnPhongBanPhoiHopConfiguration : IEntityTypeConfiguration<DuAnPhongBanPhoiHop>
{
    public void Configure(EntityTypeBuilder<DuAnPhongBanPhoiHop> builder)
    {
    builder.ToTable("DuAnPhongBanPhoiHop");

        // Composite primary key
        builder.HasKey(e => new { e.LeftId, e.RightId });

        // Map LeftId property to DuAnId column
        builder.Property(e => e.LeftId)
            .HasColumnName("DuAnId");

        // Map RightId property to PhongBanId column
        builder.Property(e => e.RightId)
            .HasColumnName("PhongBanId");

        // TenPhongBan column (denormalized from DmDonVi)
        builder.Property(e => e.TenPhongBan)
            .HasMaxLength(255);

        // FK to DuAn only (no FK to DmDonVi - legacy table)
        builder.HasOne(e => e.DuAn)
            .WithMany(e => e.PhongBanPhoiHops)
            .HasForeignKey(e => e.LeftId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed data moved to DuAnConfiguration to ensure correct INSERT order
        // builder.SeedDuAnPhongBanPhoiHop();
    }
}