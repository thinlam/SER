using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiGoiThauConfiguration : AggregateRootConfiguration<DanhMucLoaiGoiThau> {
    public override void Configure(EntityTypeBuilder<DanhMucLoaiGoiThau> builder) {
        builder.ToTable("DmLoaiGoiThau");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.KetQuaTrungThaus)
            .WithOne(e => e.LoaiGoiThau)
            .HasForeignKey(e => e.LoaiGoiThauId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}