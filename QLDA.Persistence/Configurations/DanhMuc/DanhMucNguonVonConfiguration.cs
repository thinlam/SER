using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucNguonVonConfiguration : AggregateRootConfiguration<DanhMucNguonVon> {
    public override void Configure(EntityTypeBuilder<DanhMucNguonVon> builder) {
        builder.ToTable("DmNguonVon");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.DuAnNguonVons)
            .WithOne(e => e.NguonVon)
            .HasForeignKey(e => e.NguonVonId);
        
        builder.HasMany(e => e.GoiThaus)    
            .WithOne(e => e.NguonVon)
            .HasForeignKey(e => e.NguonVonId);
    }
}
