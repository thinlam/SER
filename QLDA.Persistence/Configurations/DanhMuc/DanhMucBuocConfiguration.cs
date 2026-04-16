using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucBuocConfiguration : AggregateRootConfiguration<DanhMucBuoc> {
    public override void Configure(EntityTypeBuilder<DanhMucBuoc> builder) {
        builder.ToTable("DmBuoc");
        builder.ConfigureForDanhMuc();

        builder.Property(e => e.SoNgayThucHien).HasDefaultValueSql("1");

        builder.Property(e => e.ParentId)
            .HasConversion(
                toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            )
            .IsRequired(false);

        builder.HasOne(e => e.QuyTrinh)
            .WithMany(e => e.Buocs)
            .HasForeignKey(e => e.QuyTrinhId);

    }
}