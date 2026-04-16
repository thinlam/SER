using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucPhuongThucLuaChonNhaThauConfiguration : AggregateRootConfiguration<DanhMucPhuongThucLuaChonNhaThau> {
    public override void Configure(EntityTypeBuilder<DanhMucPhuongThucLuaChonNhaThau> builder) {
        builder.ToTable("DmPhuongThucLuaChonNhaThau");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.GoiThaus)
            .WithOne(e => e.PhuongThucLuaChonNhaThau)
            .HasForeignKey(e => e.PhuongThucLuaChonNhaThauId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}