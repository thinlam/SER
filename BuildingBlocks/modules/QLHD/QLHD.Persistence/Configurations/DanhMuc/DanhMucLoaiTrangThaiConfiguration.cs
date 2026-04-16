using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence.Configurations.SeedData.DanhMuc;

namespace QLHD.Persistence.Configurations;

public class DanhMucLoaiTrangThaiConfiguration : AggregateRootConfiguration<DanhMucLoaiTrangThai>
{
    public override void Configure(EntityTypeBuilder<DanhMucLoaiTrangThai> builder)
    {
        builder.ToTable("DanhMucLoaiTrangThai");

        builder.ConfigureForDanhMuc();

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedDanhMucLoaiTrangThai();
    }
}