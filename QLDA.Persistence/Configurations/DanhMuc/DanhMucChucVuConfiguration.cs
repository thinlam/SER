using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucChucVuConfiguration : AggregateRootConfiguration<DanhMucChucVu> {
    public override void Configure(EntityTypeBuilder<DanhMucChucVu> builder) {
        builder.ToTable("DmChucVu");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.VanBanPhapLys)
            .WithOne(e => e.ChucVu)
            .HasForeignKey(e => e.ChucVuId);
        
        builder.HasMany(e => e.VanBanChuTruongs)
            .WithOne(e => e.ChucVu)
            .HasForeignKey(e => e.ChucVuId);
        
        builder.HasMany(e => e.PheDuyetDuToans)
            .WithOne(e => e.ChucVu)
            .HasForeignKey(e => e.ChucVuId);
    }
}