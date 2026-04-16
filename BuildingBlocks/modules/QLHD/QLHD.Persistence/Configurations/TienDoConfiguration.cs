using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class TienDoConfiguration : AggregateRootConfiguration<TienDo>
{
    public override void Configure(EntityTypeBuilder<TienDo> builder)
    {
        builder.ToTable("TienDo");
        builder.ConfigureForBase();

        builder.Property(e => e.Ten).HasMaxLength(500).IsRequired();
        builder.Property(e => e.PhanTramKeHoach).HasPrecision(5, 2);
        builder.Property(e => e.PhanTramThucTe).HasPrecision(5, 2);
        builder.Property(e => e.MoTa).HasMaxLength(2000);

        // FK to HopDong (required)
        builder.HasOne(e => e.HopDong)
            .WithMany(h => h.TienDos)
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK to DanhMucTrangThai
        builder.HasOne(e => e.TrangThai)
            .WithMany()
            .HasForeignKey(e => e.TrangThaiId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(e => e.HopDongId);
        builder.HasIndex(e => e.TrangThaiId);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedTienDo();
    }
}