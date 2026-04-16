using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class KhoKhanVuongMacConfiguration : AggregateRootConfiguration<KhoKhanVuongMac>
{
    public override void Configure(EntityTypeBuilder<KhoKhanVuongMac> builder)
    {
        builder.ToTable("KhoKhanVuongMac");
        builder.ConfigureForBase();

        builder.Property(e => e.NoiDung).HasMaxLength(2000).IsRequired();
        builder.Property(e => e.MucDo).HasMaxLength(50);
        builder.Property(e => e.BienPhapKhacPhuc).HasMaxLength(2000);

        // FK to HopDong (required)
        builder.HasOne(e => e.HopDong)
            .WithMany(h => h.KhoKhanVuongMacs)
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Cascade);

        // FK to TienDo (optional) - NoAction to avoid multiple cascade paths with HopDong
        builder.HasOne(e => e.TienDo)
            .WithMany()
            .HasForeignKey(e => e.TienDoId)
            .OnDelete(DeleteBehavior.NoAction);

        // FK to DanhMucTrangThai
        builder.HasOne(e => e.TrangThai)
            .WithMany()
            .HasForeignKey(e => e.TrangThaiId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(e => e.HopDongId);
        builder.HasIndex(e => e.TienDoId);
        builder.HasIndex(e => e.TrangThaiId);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedKhoKhanVuongMac();
    }
}