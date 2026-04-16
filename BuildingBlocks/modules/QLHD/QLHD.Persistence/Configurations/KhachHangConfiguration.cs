using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class KhachHangConfiguration : AggregateRootConfiguration<KhachHang>
{
    public override void Configure(EntityTypeBuilder<KhachHang> builder)
    {
        builder.ToTable("KhachHang");

        builder.Property(e => e.Ma).HasMaxLength(50);
        builder.Property(e => e.Ten).HasMaxLength(500);
        builder.Property(e => e.TaxCode).HasMaxLength(50);
        builder.Property(e => e.ContactPerson).HasMaxLength(200);
        builder.Property(e => e.Address).HasMaxLength(1000);
        builder.Property(e => e.Phone).HasMaxLength(50);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.DistrictName).HasMaxLength(200);
        builder.Property(e => e.CityName).HasMaxLength(200);
        builder.Property(e => e.CountryName).HasMaxLength(200);

        // Unique index on Ma with filter for active records
        builder.HasIndex(e => e.Ma)
            .IsUnique()
            .HasFilter("[Ma] IS NOT NULL AND [Used] = 1 AND [IsDeleted] = 0");

        // FK to DoanhNghiep
        builder.HasOne(e => e.DoanhNghiep)
            .WithMany()
            .HasForeignKey(e => e.DoanhNghiepId)
            .OnDelete(DeleteBehavior.SetNull);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedKhachHang();
    }
}