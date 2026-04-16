using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class HopDongConfiguration : AggregateRootConfiguration<HopDong> {
    public override void Configure(EntityTypeBuilder<HopDong> builder) {
        builder.ToTable("HopDong");
        builder.ConfigureForBase();

        builder.Property(e => e.SoHopDong).HasMaxLength(50);
        builder.Property(e => e.Ten).HasMaxLength(500);
        builder.Property(e => e.GiaTri).HasPrecision(18, 2);
        builder.Property(e => e.TienThue).HasPrecision(18, 2);
        builder.Property(e => e.GiaTriSauThue).HasPrecision(18, 2);
        builder.Property(e => e.GiaTriBaoLanh).HasPrecision(18, 2);
        builder.Property(e => e.GhiChu).HasMaxLength(1000);
        builder.Property(e => e.TrangThaiId).IsRequired();
        // Unique index on SoHopDong
        builder.HasIndex(e => e.SoHopDong).IsUnique();

        // One-to-zero-or-one relationship with DuAn (optional)
        builder.HasOne(e => e.DuAn)
            .WithOne(e => e.HopDong)
            .HasForeignKey<HopDong>(e => e.DuAnId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.LoaiHopDong)
            .WithMany()
            .HasForeignKey(e => e.LoaiHopDongId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TrangThai)
            .WithMany()
            .HasForeignKey(e => e.TrangThaiId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DanhMucNguoiPhuTrach (int key)
        builder.HasOne(e => e.NguoiPhuTrach)
            .WithMany()
            .HasForeignKey(e => e.NguoiPhuTrachChinhId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DanhMucNguoiTheoDoi (int key)
        builder.HasOne(e => e.NguoiTheoDoi)
            .WithMany()
            .HasForeignKey(e => e.NguoiTheoDoiId)
            .OnDelete(DeleteBehavior.SetNull);

        // FK to DanhMucGiamDoc (int key)
        builder.HasOne(e => e.GiamDoc)
            .WithMany()
            .HasForeignKey(e => e.GiamDocId)
            .OnDelete(DeleteBehavior.SetNull);

        // FK to KhachHang (Guid key, required)
        builder.HasOne(e => e.KhachHang)
            .WithMany()
            .HasForeignKey(e => e.KhachHangId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedHopDong();
    }
}