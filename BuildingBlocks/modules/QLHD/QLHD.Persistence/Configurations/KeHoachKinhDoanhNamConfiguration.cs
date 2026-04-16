using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

public class KeHoachKinhDoanhNamConfiguration : AggregateRootConfiguration<KeHoachKinhDoanhNam> {
    public override void Configure(EntityTypeBuilder<KeHoachKinhDoanhNam> builder) {
        builder.ToTable("KeHoachKinhDoanhNam");
        builder.ConfigureForBase();

        builder.Property(e => e.BatDau).IsRequired();
        builder.Property(e => e.GhiChu).HasMaxLength(2000);

        // Navigation properties
        builder.HasMany(e => e.KeHoachKinhDoanhNam_BoPhans)
            .WithOne()
            .HasForeignKey(e => e.KeHoachKinhDoanhNamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.KeHoachKinhDoanhNam_CaNhans)
            .WithOne()
            .HasForeignKey(e => e.KeHoachKinhDoanhNamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}