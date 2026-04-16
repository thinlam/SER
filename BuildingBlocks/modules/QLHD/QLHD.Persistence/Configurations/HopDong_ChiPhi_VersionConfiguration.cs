using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

/// <summary>
/// Configuration for HopDong_ChiPhi_Version - Plan snapshot entity
/// </summary>
public class HopDong_ChiPhi_VersionConfiguration : AggregateRootConfiguration<HopDong_ChiPhi_Version>
{
    public override void Configure(EntityTypeBuilder<HopDong_ChiPhi_Version> builder)
    {
        builder.ToTable("HopDong_ChiPhi_Version");
        builder.ConfigureForBase();

        // Plan fields precision
        builder.Property(e => e.GiaTriKeHoach).HasPrecision(18, 2);
        builder.Property(e => e.PhanTramKeHoach).HasPrecision(5, 2);

        // String lengths
        builder.Property(e => e.GhiChuKeHoach).HasMaxLength(2000);

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

        // FK to HopDong (required - owner)
        builder.HasOne(e => e.HopDong)
            .WithMany()
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK to DanhMucLoaiChiPhi
        builder.HasOne(e => e.LoaiChiPhi)
            .WithMany()
            .HasForeignKey(e => e.LoaiChiPhiId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes for FK columns
        builder.HasIndex(e => e.KeHoachThangId);
        builder.HasIndex(e => e.SourceEntityId);
        builder.HasIndex(e => e.HopDongId);
    }
}