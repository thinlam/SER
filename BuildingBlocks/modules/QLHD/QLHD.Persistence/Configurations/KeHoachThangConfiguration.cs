using BuildingBlocks.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLHD.Domain.Entities;

namespace QLHD.Persistence.Configurations;

public class KeHoachThangConfiguration : AggregateRootConfiguration<KeHoachThang>
{
    public override void Configure(EntityTypeBuilder<KeHoachThang> builder)
    {
        builder.ToTable("KeHoachThang");
        builder.ConfigureForBase();

        builder.Property(e => e.TuNgay).IsRequired();
        builder.Property(e => e.DenNgay).IsRequired();
        builder.Property(e => e.TuThangDisplay).IsRequired().HasMaxLength(50);
        builder.Property(e => e.DenThangDisplay).IsRequired().HasMaxLength(50);
        builder.Property(e => e.GhiChu).HasMaxLength(2000);

        // Index for filtering by date range
        builder.HasIndex(e => e.TuNgay);
        builder.HasIndex(e => e.DenNgay);
    }
}