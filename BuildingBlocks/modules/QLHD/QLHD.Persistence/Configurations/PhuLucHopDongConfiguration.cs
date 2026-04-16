using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class PhuLucHopDongConfiguration : AggregateRootConfiguration<PhuLucHopDong>
{
    public override void Configure(EntityTypeBuilder<PhuLucHopDong> builder)
    {
        builder.ToTable("PhuLucHopDong");
        builder.ConfigureForBase();

        builder.Property(e => e.SoPhuLuc).HasMaxLength(100).IsRequired();
        builder.Property(e => e.NoiDungPhuLuc).HasMaxLength(4000);

        // FK to HopDong (required) - Cascade delete consistent with ThuTienThucTe pattern
        builder.HasOne(e => e.HopDong)
            .WithMany(h => h.PhuLucHopDongs)
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unique index on SoPhuLuc per HopDong
        builder.HasIndex(e => new { e.HopDongId, e.SoPhuLuc })
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedPhuLucHopDong();
    }
}