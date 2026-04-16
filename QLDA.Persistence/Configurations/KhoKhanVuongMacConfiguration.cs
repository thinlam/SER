using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class KhoKhanVuongMacConfiguration : AggregateRootConfiguration<BaoCaoKhoKhanVuongMac> {
    public override void Configure(EntityTypeBuilder<BaoCaoKhoKhanVuongMac> builder) {
        builder.ToTable(nameof(BaoCaoKhoKhanVuongMac));

        builder.Property(e => e.TinhTrangId)
            .HasConversion(toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            );

        builder.Property(e => e.MucDoKhoKhanId)
            .HasConversion(toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            );

        builder.Property(e => e.NgayXuLy)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );
    }
}