using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class TamUngConfiguration : AggregateRootConfiguration<TamUng> {
    public override void Configure(EntityTypeBuilder<TamUng> builder) {
        builder.ToTable(nameof(TamUng));

        builder.ConfigureForBase();

        builder.Property(e => e.BuocId)
            .HasConversion(
                toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            );

        builder.Property(e => e.NgayTamUng)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );
        #region 9213
        builder.Property(e => e.SoBaoLanh)
            .HasMaxLength(50);
        #endregion
        builder.HasOne(e => e.HopDong)
            .WithOne(e => e.TamUng)
            .HasForeignKey<TamUng>(e => e.HopDongId)
            .OnDelete(DeleteBehavior.Restrict);

        // Enforce 1-1 relationship: only one non-deleted TamUng per HopDong
        builder.HasIndex(e => e.HopDongId)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");
    }
}