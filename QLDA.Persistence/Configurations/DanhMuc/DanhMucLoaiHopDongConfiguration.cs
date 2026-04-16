using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiHopDongConfiguration : AggregateRootConfiguration<DanhMucLoaiHopDong> {
    public override void Configure(EntityTypeBuilder<DanhMucLoaiHopDong> builder) {
        builder.ToTable("DmLoaiHopDong");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.HopDongs)
            .WithOne(e => e.LoaiHopDong)
            .HasForeignKey(e => e.LoaiHopDongId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasMany(e => e.GoiThaus)
            .WithOne(e => e.LoaiHopDong)
            .HasForeignKey(e => e.LoaiHopDongId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}