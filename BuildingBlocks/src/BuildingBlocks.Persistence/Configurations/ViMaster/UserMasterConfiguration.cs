using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingBlocks.Persistence.Configurations.ViMaster;

public class UserMasterConfiguration : AggregateRootConfiguration<UserMaster>
{
    public override void Configure(EntityTypeBuilder<UserMaster> builder)
    {
        builder.HasKey(x => x.Id).HasName("PK__USER_MAS__CA9BC5E270CE69C2");
        builder.ToTable("USER_MASTER", "dbo", t => t.ExcludeFromMigrations());

        builder.Property(e => e.Id).HasColumnName("User_MasterID");
        builder.Property(e => e.CanBoId).HasColumnName("CanBoID");
        builder.Property(e => e.DonViId).HasColumnName("DonViID");
        builder.Property(e => e.HoTen).HasMaxLength(50);
        builder.Property(e => e.PhongBanId).HasColumnName("PhongBanID");
        builder.Property(e => e.UserName).HasMaxLength(50);
        builder.Property(e => e.UserPortalId).HasColumnName("User_PortalID");
    }
}