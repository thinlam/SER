using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence.Configurations.SeedData.DanhMuc;

namespace QLHD.Persistence.Configurations.DanhMuc;

public class DanhMucTrangThaiConfiguration : AggregateRootConfiguration<DanhMucTrangThai> {
    public override void Configure(EntityTypeBuilder<DanhMucTrangThai> builder) {
        builder.ToTable("DanhMucTrangThai");

        builder.ConfigureForDanhMuc();

        // DanhMucTrangThai specific properties (orders 5-9)
        builder.Property(e => e.LoaiTrangThaiId)
            .HasColumnOrder(5)
            .HasColumnName("LoaiTrangThaiId")
            .HasDefaultValue(0);
        builder.Property(e => e.MaLoaiTrangThai)
            .HasColumnOrder(6)
            .HasMaxLength(20)
            .HasColumnName("MaLoaiTrangThai")
            .HasDefaultValue("");
        builder.Property(e => e.TenLoaiTrangThai)
            .HasColumnOrder(7)
            .HasMaxLength(200)
            .HasColumnName("TenLoaiTrangThai")
            .HasDefaultValue("");

        builder.Property(e => e.ThuTu)
            .HasColumnOrder(8)
            .HasDefaultValue(0);
        builder.Property(e => e.IsDefault)
            .HasColumnOrder(9)
            .HasDefaultValue(false);

        // Override unique index: Ma must be unique within each LoaiTrangThai (active records only)
        builder.HasIndex(e => e.Ma).IsUnique(false);
        builder.HasIndex(e => new { e.Ma, e.LoaiTrangThaiId })
            .IsUnique()
            .HasFilter("[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

        builder.HasIndex(e => e.MaLoaiTrangThai);

        // Ensure only one IsDefault per LoaiTrangThaiId
        builder.HasIndex(e => new { e.LoaiTrangThaiId, e.IsDefault })
            .HasFilter("[IsDefault] = 1")
            .IsUnique();

        // Foreign key relationship
        builder.HasOne(e => e.LoaiTrangThai)
            .WithMany()
            .HasForeignKey(e => e.LoaiTrangThaiId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedDanhMucTrangThai();
    }
}