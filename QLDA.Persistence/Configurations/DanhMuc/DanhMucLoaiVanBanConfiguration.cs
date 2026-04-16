using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiVanBanConfiguration : AggregateRootConfiguration<DanhMucLoaiVanBan> {
    public override void Configure(EntityTypeBuilder<DanhMucLoaiVanBan> builder) {
        builder.ToTable("DmLoaiVanBan");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.VanBanPhapLys)
            .WithOne(e => e.LoaiVanBan)
            .HasForeignKey(e => e.LoaiVanBanId);
        
        builder.HasMany(e => e.VanBanChuTruongs)
            .WithOne(e => e.LoaiVanBan)
            .HasForeignKey(e => e.LoaiVanBanId);
    }
}