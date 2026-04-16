using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for DuAn_XuatHoaDon_Version - Plan snapshot entity
/// </summary>
public class DuAn_XuatHoaDon_VersionConfiguration : AggregateRootConfiguration<DuAn_XuatHoaDon_Version>
{
    public override void Configure(EntityTypeBuilder<DuAn_XuatHoaDon_Version> builder)
    {
        builder.ToTable("DuAn_XuatHoaDon_Version");
        builder.ConfigureForBase();

        // Plan fields precision
        builder.Property(e => e.GiaTriKeHoach).HasPrecision(18, 2);
        builder.Property(e => e.PhanTramKeHoach).HasPrecision(5, 2);

        // String lengths
        builder.Property(e => e.GhiChuKeHoach).HasMaxLength(1000);

        // FK to KeHoachThang (required)
        builder.HasOne(e => e.KeHoachThang)
            .WithMany()
            .HasForeignKey(e => e.KeHoachThangId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to Source Entity (required)
        builder.HasOne(e => e.SourceEntity)
            .WithMany()
            .HasForeignKey(e => e.SourceEntityId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DuAn (required - owner)
        builder.HasOne(e => e.DuAn)
            .WithMany()
            .HasForeignKey(e => e.DuAnId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DanhMucLoaiThanhToan
        builder.HasOne(e => e.LoaiThanhToan)
            .WithMany()
            .HasForeignKey(e => e.LoaiThanhToanId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for FK columns
        builder.HasIndex(e => e.KeHoachThangId);
        builder.HasIndex(e => e.SourceEntityId);
        builder.HasIndex(e => e.DuAnId);
    }
}