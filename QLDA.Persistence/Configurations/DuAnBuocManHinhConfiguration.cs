using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class DuAnBuocManHinhConfiguration : AggregateRootConfiguration<DuAnBuocManHinh> {
    public override void Configure(EntityTypeBuilder<DuAnBuocManHinh> builder) {
        builder.ToTable(nameof(DuAnBuocManHinh));

        builder.HasKey(e => new { e.BuocId, e.ManHinhId });

        builder.Property(e => e.Stt).HasDefaultValue(0);

        builder.HasOne(e => e.DuAnBuoc)
            .WithMany(e => e.DuAnBuocManHinhs)
            .HasForeignKey(e => e.BuocId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.ManHinh)
            .WithMany(e => e.DuAnBuocManHinhs)
            .HasForeignKey(e => e.ManHinhId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}