using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class DuAnChiuTrachNhiemXuLyConfiguration : AggregateRootConfiguration<DuAnChiuTrachNhiemXuLy> {
    public override void Configure(EntityTypeBuilder<DuAnChiuTrachNhiemXuLy> builder) {
        builder.ToTable(nameof(DuAnChiuTrachNhiemXuLy));
        builder.HasKey(e => new { e.DuAnId, e.ChiuTrachNhiemXuLyId });

        builder.Property(e => e.Loai)
            .HasConversion<string>();

        builder.HasOne(e => e.DuAn)
            .WithMany(e => e.DuAnChiuTrachNhiemXuLys)
            .HasForeignKey(e => e.DuAnId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}