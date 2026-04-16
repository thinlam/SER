using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence.Configurations.SeedData.DanhMuc;

namespace QLHD.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiHopDongConfiguration : AggregateRootConfiguration<DanhMucLoaiHopDong>
{
    public override void Configure(EntityTypeBuilder<DanhMucLoaiHopDong> builder)
    {
        builder.ToTable("DanhMucLoaiHopDong");
        builder.ConfigureForDanhMuc();

        // DanhMucLoaiHopDong specific properties (orders 5-7)
        builder.Property(e => e.Symbol)
            .HasColumnOrder(5)
            .HasMaxLength(50)
            .IsRequired(false);
        builder.Property(e => e.Prefix)
            .HasColumnOrder(6)
            .HasDefaultValue(1);
        builder.Property(e => e.IsDefault)
            .HasColumnOrder(7)
            .HasDefaultValue(false);

        // Ensure only one IsDefault per table
        builder.HasIndex(e => e.IsDefault)
            .HasFilter("[IsDefault] = 1")
            .IsUnique();

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedDanhMucLoaiHopDong();
    }
}