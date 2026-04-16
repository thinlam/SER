using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class BaoCaoConfiguration : AggregateRootConfiguration<BaoCao> {
    public override void Configure(EntityTypeBuilder<BaoCao> builder) {
        builder.ToTable(nameof(BaoCao));
        builder.ConfigureForBase();

        builder.Property(e => e.BuocId)
            .HasConversion(
                toDb => toDb == 0 ? null : toDb, // EF insert sẽ chuyển 0 → null
                fromDb => fromDb // Đọc giữ nguyên null/int
            );

        builder.Property(e => e.Ngay)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );
    }
}