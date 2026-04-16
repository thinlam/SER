using BuildingBlocks.Persistence.Configurations;
using QLHD.Persistence.Configurations.SeedData.Business;

namespace QLHD.Persistence.Configurations;

public class DoanhNghiepConfiguration : AggregateRootConfiguration<DoanhNghiep> {
    public override void Configure(EntityTypeBuilder<DoanhNghiep> builder) {
        builder.ToTable("DoanhNghiep");

        // Business identity (order 5-7)
        builder.Property(e => e.TaxCode).HasColumnOrder(5).HasMaxLength(20);
        builder.Property(e => e.Ten).HasColumnOrder(6).HasMaxLength(500);
        builder.Property(e => e.TenTiengAnh).HasColumnOrder(7).HasMaxLength(500);

        // Tax & Location (order 8-11)
        builder.Property(e => e.TaxAuthorityId).HasColumnOrder(8);
        builder.Property(e => e.CountryId).HasColumnOrder(9);
        builder.Property(e => e.CityId).HasColumnOrder(10);
        builder.Property(e => e.DistrictId).HasColumnOrder(11);

        // Contact info (order 12-18)
        builder.Property(e => e.Phone).HasColumnOrder(12).HasMaxLength(50);
        builder.Property(e => e.Fax).HasColumnOrder(13).HasMaxLength(50);
        builder.Property(e => e.AddressVN).HasColumnOrder(14).HasMaxLength(500);
        builder.Property(e => e.AddressEN).HasColumnOrder(15).HasMaxLength(500);
        builder.Property(e => e.Email).HasColumnOrder(16).HasMaxLength(200);
        builder.Property(e => e.ContactPerson).HasColumnOrder(17).HasMaxLength(200);
        builder.Property(e => e.Owner).HasColumnOrder(18).HasMaxLength(200);

        // Bank info (order 19-21)
        builder.Property(e => e.BankAccount).HasColumnOrder(19).HasMaxLength(50);
        builder.Property(e => e.AccountHolder).HasColumnOrder(20).HasMaxLength(200);
        builder.Property(e => e.BankName).HasColumnOrder(21).HasMaxLength(200);

        // Logo (order 22-23)
        builder.Property(e => e.IsLogo).HasColumnOrder(22);
        builder.Property(e => e.LogoFileName).HasColumnOrder(23).HasMaxLength(200);

        // Description & Status (order 24-25)
        builder.Property(e => e.MoTa).HasColumnOrder(24).HasMaxLength(500);
        builder.Property(e => e.IsActive).HasColumnOrder(25).HasDefaultValue(true);

        // Authorization (order 26-29)
        builder.Property(e => e.AuthorizeVolume).HasColumnOrder(26).HasMaxLength(50);
        builder.Property(e => e.AuthorizeLic).HasColumnOrder(27).HasMaxLength(200);
        builder.Property(e => e.AuthorizeDate).HasColumnOrder(28);
        builder.Property(e => e.Version).HasColumnOrder(29).HasMaxLength(20);

        // Unique index on TaxCode (MaSoThue)
        builder.HasIndex(e => e.TaxCode)
            .IsUnique()
            .HasFilter("[TaxCode] IS NOT NULL AND [TaxCode] <> ''");

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedDoanhNghiep();

    }
}