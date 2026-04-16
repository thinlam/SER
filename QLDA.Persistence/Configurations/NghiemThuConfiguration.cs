using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class NghiemThuConfiguration : AggregateRootConfiguration<NghiemThu> {
    public override void Configure(EntityTypeBuilder<NghiemThu> builder) {
        builder.ToTable(nameof(NghiemThu));
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

        builder.HasOne(e => e.HopDong)
            .WithMany(e => e.NghiemThus)
            .HasForeignKey(e => e.HopDongId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(e => e.ThanhToan)
            .WithOne(e => e.NghiemThu)
            .HasForeignKey<ThanhToan>(e => e.NghiemThuId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.NghiemThuPhuLucHopDongs)
            .WithOne(e => e.NghiemThu)
            .HasForeignKey(e => e.NghiemThuId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}