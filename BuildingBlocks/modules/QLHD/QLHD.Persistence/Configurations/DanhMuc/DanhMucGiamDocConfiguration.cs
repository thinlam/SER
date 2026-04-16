using BuildingBlocks.Persistence.Configurations;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence.Configurations.SeedData.DanhMuc;

namespace QLHD.Persistence.Configurations;

public class DanhMucGiamDocConfiguration : AggregateRootConfiguration<DanhMucGiamDoc>
{
    public override void Configure(EntityTypeBuilder<DanhMucGiamDoc> builder)
    {
        builder.ToTable("DanhMucGiamDoc");

        // Column order: Id → Ma → Ten → MoTa → Used → UserPortalId → DonViId → PhongBanId → audit fields
        builder.ConfigureForDanhMuc();

        // Derived class properties (order 5-7)
        builder.Property(e => e.UserPortalId)
            .HasColumnOrder(5)
            .HasColumnName("UserPortalId")
            .IsRequired();

        builder.Property(e => e.DonViId)
            .HasColumnOrder(6)
            .HasColumnName("DonViId")
            .IsRequired();

        builder.Property(e => e.PhongBanId)
            .HasColumnOrder(7)
            .HasColumnName("PhongBanId")
            .IsRequired(false);

        // Unique constraint: one user per scope (DonVi or PhongBan)
        // Note: COALESCE-based scope uniqueness is enforced in application layer
        // This index helps with scope-based queries
        builder.HasIndex(e => new { e.UserPortalId, e.DonViId, e.PhongBanId })
            .HasFilter("[IsDeleted] = 0");

        // Index for query performance
        builder.HasIndex(e => e.DonViId);
        builder.HasIndex(e => e.PhongBanId);

        // Seed data moved to AppDbContext.OnModelCreating for ordered insertion
        // builder.SeedDanhMucGiamDoc();
    }
}