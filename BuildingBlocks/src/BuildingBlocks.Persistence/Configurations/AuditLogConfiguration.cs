using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingBlocks.Persistence.Configurations
{
    public class AuditLogConfiguration : AggregateRootConfiguration<AuditLog>
    {
        public override void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable(nameof(AuditLog));
            builder.ConfigureForBase();
            builder.Property(e => e.EntityName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.EntityId)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Action)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.OldValues)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.NewValues)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.ChangedColumns)
                .HasColumnType("nvarchar(max)");

            // Indexes for performance
            builder.HasIndex(e => e.EntityName);
            builder.HasIndex(e => e.EntityId);
            builder.HasIndex(e => e.Index);
            builder.HasIndex(e => new { e.EntityName, e.EntityId });
        }
    }
}