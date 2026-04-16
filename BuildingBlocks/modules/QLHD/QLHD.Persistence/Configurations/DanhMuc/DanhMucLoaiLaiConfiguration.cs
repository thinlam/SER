using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiLaiConfiguration : AggregateRootConfiguration<DanhMucLoaiLai>
{
    public override void Configure(EntityTypeBuilder<DanhMucLoaiLai> builder)
    {
        builder.ToTable("DanhMucLoaiLai");
        builder.ConfigureForDanhMuc();

        // DanhMucLoaiLai specific property (order 5)
        builder.Property(e => e.IsDefault)
            .HasColumnOrder(5)
            .HasDefaultValue(false);

        // Ensure only one IsDefault per table
        builder.HasIndex(e => e.IsDefault)
            .HasFilter("[IsDefault] = 1")
            .IsUnique();
    }
}