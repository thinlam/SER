using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.ViMaster;

namespace QLDA.Persistence.Configurations.ViMaster;

public class DanhMucDuongConfiguration : AggregateRootConfiguration<DmDuong> {
    public override void Configure(EntityTypeBuilder<DmDuong> builder) {
        builder
            .HasNoKey()
            .ToTable("DM_DUONG");

        builder.Property(e => e.Id).HasColumnName("DuongID");
        builder.Property(e => e.MoTa).HasMaxLength(2000);
        builder.Property(e => e.TenDuong).HasMaxLength(200);
        builder.Property(e => e.TenVietTat).HasMaxLength(50);
    }
}