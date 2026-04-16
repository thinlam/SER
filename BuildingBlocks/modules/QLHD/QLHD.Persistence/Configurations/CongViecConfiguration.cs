using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Persistence.Configurations;

public class CongViecConfiguration : AggregateRootConfiguration<CongViec> {
    public override void Configure(EntityTypeBuilder<CongViec> builder) {
        builder.ToTable("CongViec");
        builder.ConfigureForBase();

        builder.Property(e => e.NguoiThucHien).HasMaxLength(500).IsRequired();
        builder.Property(e => e.KeHoachCongViec).HasMaxLength(2000);
        builder.Property(e => e.ThucTe).HasMaxLength(2000);
        builder.Property(e => e.TenTrangThai).HasMaxLength(100).IsRequired();

        // FK to DanhMucTrangThai (no navigation in entity, but FK exists)
        builder.HasOne<DanhMucTrangThai>()
            .WithMany()
            .HasForeignKey(e => e.TrangThaiId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}