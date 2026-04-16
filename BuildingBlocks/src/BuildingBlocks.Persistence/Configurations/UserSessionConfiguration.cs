using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingBlocks.Persistence.Configurations;

public class UserSessionConfiguration : AggregateRootConfiguration<UserSession>
{
    public override void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("UserSession");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("SessionId")
            .ValueGeneratedNever()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(e => e.UserName)
            .IsRequired();

        builder.Property(e => e.Platform)
            .IsRequired();

        builder.Property(e => e.DeviceName)
            .HasMaxLength(200);

        builder.Property(e => e.UserAgent)
            .HasMaxLength(500);

        builder.Property(e => e.RefreshToken)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.RefreshTokenExpiresAt)
            .HasColumnName("RefreshTokenExpiresAt")
            .IsRequired();

        builder.Property(e => e.IsRemembered)
            .HasDefaultValue(false);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.LastActivityAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.IpAddress)
            .HasMaxLength(100);

        builder.Property(e => e.IsRevoked)
            .HasDefaultValue(false);

        // Index để query nhanh theo username
        builder.HasIndex(e => e.UserName)
            .HasDatabaseName("IX_UserSession_UserName");

        // Index để query nhanh theo platform
        builder.HasIndex(e => e.Platform)
            .HasDatabaseName("IX_UserSession_Platform");

        // Index composite cho query theo username và platform
        builder.HasIndex(e => new { e.UserName, e.Platform })
            .HasDatabaseName("IX_UserSession_UserName_Platform");
    }
}