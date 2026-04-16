using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class DuToanConfiguration : IEntityTypeConfiguration<DuToan> {
    public void Configure(EntityTypeBuilder<DuToan> builder) {
        builder.ToTable(nameof(DuToan));
        builder.ConfigureForBase();
        builder.Property(e => e.SoQuyetDinhDuToan)
            .HasMaxLength(50);

        builder.Property(e => e.NgayKyDuToan)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );
        builder.HasOne(e => e.DuAn)
            .WithMany(e => e.DuToans)
            .HasForeignKey(e => e.DuAnId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}