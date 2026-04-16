using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucNhaThauConfiguration : AggregateRootConfiguration<DanhMucNhaThau> {
    public override void Configure(EntityTypeBuilder<DanhMucNhaThau> builder) {
        builder.ToTable("DmNhaThau");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.HopDongs)
            .WithOne(e => e.DonViThucHien)
            .HasForeignKey(e => e.DonViThucHienId);

        builder.HasMany(e => e.KetQuaTrungThaus)
            .WithOne(e => e.DonViTrungThau)
            .HasForeignKey(e => e.DonViTrungThauId);
    }
}