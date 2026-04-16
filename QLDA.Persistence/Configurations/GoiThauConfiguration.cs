using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class GoiThauConfiguration : AggregateRootConfiguration<GoiThau> {
    public override void Configure(EntityTypeBuilder<GoiThau> builder) {
        builder.ToTable(nameof(GoiThau));
        builder.ConfigureForBase();

        builder.Property(e => e.BuocId)
            .HasConversion(
                toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            );

        builder.HasOne(e => e.KeHoachLuaChonNhaThau)
            .WithMany(e => e.GoiThaus)
            .HasForeignKey(e => e.KeHoachLuaChonNhaThauId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.KetQuaTrungThau)
            .WithOne(e => e.GoiThau)
            .HasForeignKey<KetQuaTrungThau>(e => e.GoiThauId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}