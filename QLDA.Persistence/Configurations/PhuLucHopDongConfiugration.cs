using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class PhuLucHopDongConfiguration : AggregateRootConfiguration<PhuLucHopDong> {
    public override void Configure(EntityTypeBuilder<PhuLucHopDong> builder) {
        builder.ToTable(nameof(PhuLucHopDong));
        builder.ConfigureForBase();

        builder.Property(e => e.BuocId)
            .HasConversion(
                toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            );

        builder.Property(e => e.Ngay)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );

        builder.Property(e => e.NgayDuKienKetThuc)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );

        builder.HasOne(e => e.HopDong)
            .WithMany(e => e.PhuLucHopDongs)
            .HasForeignKey(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.NghiemThuPhuLucHopDongs)
            .WithOne(e => e.PhuLucHopDong)
            .HasForeignKey(e => e.PhuLucHopDongId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}