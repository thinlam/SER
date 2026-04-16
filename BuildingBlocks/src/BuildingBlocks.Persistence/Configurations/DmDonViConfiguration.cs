using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingBlocks.Persistence.Configurations;

public class DmDonViConfiguration : AggregateRootConfiguration<DmDonVi> {
    public override void Configure(EntityTypeBuilder<DmDonVi> builder) {
        builder.HasKey(e => e.Id)
            .HasName("PK__DM_DONVI__1CB88576D84B4D4C")
            .IsClustered(false);

        builder.ToTable("DM_DONVI", "dbo", t => t.ExcludeFromMigrations());

        builder.HasIndex(e => e.DonViCapChaId, "IDX_DM_DONVI_01");

        builder.Property(e => e.Id).HasColumnName("DonViID");
        builder.Property(e => e.CapDonViId).HasColumnName("CapDonViID");
        builder.Property(e => e.DiaChiDayDu).HasMaxLength(1000);
        builder.Property(e => e.DienThoai).HasMaxLength(50);
        builder.Property(e => e.DonViCapChaId).HasColumnName("DonViCapChaID");
        builder.Property(e => e.DuongId).HasColumnName("DuongID");
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Fax).HasMaxLength(50);
        builder.Property(e => e.Latitude).HasMaxLength(20);
        builder.Property(e => e.LoaiDonViId).HasColumnName("LoaiDonViID");
        builder.Property(e => e.Longitude).HasMaxLength(20);
        builder.Property(e => e.MaDonVi).HasMaxLength(20);
        builder.Property(e => e.MoTa).HasMaxLength(4000);
        builder.Property(e => e.PhuongXaId).HasColumnName("PhuongXaID");
        builder.Property(e => e.QuanHuyenId).HasColumnName("QuanHuyenID");
        builder.Property(e => e.SoNha).HasMaxLength(100);
        builder.Property(e => e.TenDonVi).HasMaxLength(2000);
        builder.Property(e => e.TenVietTat).HasMaxLength(100);
        builder.Property(e => e.TinhThanhId).HasColumnName("TinhThanhID");
        builder.Property(e => e.Website).HasMaxLength(100);
    }
}