using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class DuAnConfiguration : AggregateRootConfiguration<DuAn>
{
    public override void Configure(EntityTypeBuilder<DuAn> builder)
    {
        builder.ToTable("DuAn");
        builder.ConfigureForBase();

        builder.Property(e => e.Ten).HasMaxLength(1000);
        builder.Property(e => e.GhiChu).HasMaxLength(1000);
        builder.Property(e => e.GiaTriDuKien).HasPrecision(18, 2);
        builder.Property(e => e.GiaVon).HasPrecision(5, 2);
        builder.Property(e => e.ThanhTien).HasPrecision(18, 2);

        // FK to KhachHang (Guid key)
        builder.HasOne(e => e.KhachHang)
            .WithMany()
            .HasForeignKey(e => e.KhachHangId)
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
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DanhMucGiamDoc (int key)
        builder.HasOne(e => e.GiamDoc)
            .WithMany()
            .HasForeignKey(e => e.GiamDocId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DanhMucTrangThai (int key)
        builder.HasOne(e => e.TrangThai)
            .WithMany()
            .HasForeignKey(e => e.TrangThaiId)
            .OnDelete(DeleteBehavior.Restrict);

        // CongViecs collection - inverse navigation for CongViec.DuAn
        builder.HasMany(e => e.CongViecs)
            .WithOne(e => e.DuAn)
            .HasForeignKey(e => e.DuAnId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}