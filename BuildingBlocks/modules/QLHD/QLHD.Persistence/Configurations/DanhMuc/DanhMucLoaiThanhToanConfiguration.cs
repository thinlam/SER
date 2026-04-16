using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence.Configurations.SeedData.DanhMuc;

namespace QLHD.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiThanhToanConfiguration : AggregateRootConfiguration<DanhMucLoaiThanhToan> {
    public override void Configure(EntityTypeBuilder<DanhMucLoaiThanhToan> builder) {
        builder.ToTable("DanhMucLoaiThanhToan");
        builder.ConfigureForDanhMuc();

        // DanhMucLoaiThanhToan specific property (order 5)
        builder.Property(e => e.IsDefault)
            .HasColumnOrder(5)
            .HasDefaultValue(false);

        // Ensure only one IsDefault per table
        builder.HasIndex(e => e.IsDefault)
            .HasFilter("[IsDefault] = 1")
            .IsUnique();

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedDanhMucLoaiThanhToan();
    }
}