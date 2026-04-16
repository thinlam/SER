using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucManHinhConfiguration : AggregateRootConfiguration<DanhMucManHinh> {
    public override void Configure(EntityTypeBuilder<DanhMucManHinh> builder) {
        builder.ToTable("E_ManHinh");
        builder.ConfigureForEnumDb();

        builder.HasIndex(e => e.Ten).IsUnique();
        
        builder.HasMany(e => e.DuAnBuocManHinhs)
            .WithOne(e => e.ManHinh)
            .HasForeignKey(e => e.ManHinhId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.DanhMucBuocManHinhs)
            .WithOne(e => e.ManHinh)
            .HasForeignKey(e => e.ManHinhId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}