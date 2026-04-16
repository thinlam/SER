using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucHinhThucLuaChonNhaThauConfiguration : AggregateRootConfiguration<DanhMucHinhThucLuaChonNhaThau> {
    public override void Configure(EntityTypeBuilder<DanhMucHinhThucLuaChonNhaThau> builder) {
        builder.ToTable("DmHinhThucLuaChonNhaThau");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.GoiThaus)
            .WithOne(e => e.HinhThucLuaChonNhaThau)
            .HasForeignKey(e => e.HinhThucLuaChonNhaThauId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}