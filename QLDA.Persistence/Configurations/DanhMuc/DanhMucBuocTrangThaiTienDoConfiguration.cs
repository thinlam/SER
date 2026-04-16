using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucBuocTrangThaiTienDoConfiguration : AggregateRootConfiguration<DanhMucBuocTrangThaiTienDo> {
    public override void Configure(EntityTypeBuilder<DanhMucBuocTrangThaiTienDo> builder) {
        builder.ToTable("DmBuocTrangThaiTienDo");
        builder.ConfigureForDanhMuc();

        builder.HasOne(e => e.Buoc)
            .WithMany(e => e.BuocTrangThaiTienDos)
            .HasForeignKey(e => e.BuocId);
        
        
        builder.HasOne(e => e.TrangThaiTienDo)
            .WithMany(e => e.DanhMucBuocTrangThaiTienDos)
            .HasForeignKey(e => e.TrangThaiId);
    }
}