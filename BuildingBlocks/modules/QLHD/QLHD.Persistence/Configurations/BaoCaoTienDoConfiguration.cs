using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class BaoCaoTienDoConfiguration : AggregateRootConfiguration<BaoCaoTienDo>
{
    public override void Configure(EntityTypeBuilder<BaoCaoTienDo> builder)
    {
        builder.ToTable("BaoCaoTienDo");
        builder.ConfigureForBase();

        builder.Property(e => e.TenNguoiBaoCao).HasMaxLength(200).IsRequired();
        builder.Property(e => e.PhanTramThucTe).HasPrecision(5, 2);
        builder.Property(e => e.NoiDungDaLam).HasMaxLength(4000);
        builder.Property(e => e.KeHoachTiepTheo).HasMaxLength(4000);
        builder.Property(e => e.GhiChu).HasMaxLength(1000);
        builder.Property(e => e.TenNguoiDuyet).HasMaxLength(200);

        // FK to TienDo (required)
        builder.HasOne(e => e.TienDo)
            .WithMany(t => t.BaoCaoTienDos)
            .HasForeignKey(e => e.TienDoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(e => e.TienDoId);
        builder.HasIndex(e => e.NgayBaoCao);
        builder.HasIndex(e => e.NguoiBaoCaoId);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedBaoCaoTienDo();
    }
}