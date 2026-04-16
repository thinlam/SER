using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class DangTaiKeHoachLcntLenMangConfiguration : AggregateRootConfiguration<DangTaiKeHoachLcntLenMang> {
    public override void Configure(EntityTypeBuilder<DangTaiKeHoachLcntLenMang> builder) {
        builder.ToTable(nameof(DangTaiKeHoachLcntLenMang));
        builder.ConfigureForBase();

        builder.Property(e => e.BuocId)
            .HasConversion(
                toDb => toDb == 0 ? null : toDb,
                fromDb => fromDb
            );

        builder.Property(e => e.NgayEHSMT)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );

        builder.HasOne(e => e.KeHoachLuaChonNhaThau)
            .WithOne(e => e.DangTaiKeHoachLcntLenMang)
            .HasForeignKey<DangTaiKeHoachLcntLenMang>(e => e.KeHoachLuaChonNhaThauId)
            .OnDelete(DeleteBehavior.Cascade);

        // Enforce 1-1 relationship: only one non-deleted DangTaiKeHoachLcntLenMang per KeHoachLuaChonNhaThau
        builder.HasIndex(e => e.KeHoachLuaChonNhaThauId)
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");
    }
}