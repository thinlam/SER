using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingBlocks.Persistence.Configurations;

public static class ConfigurationExtension
{
    public static void ConfigureForBase<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {
        // Id - Primary Key
        builder.HasKey("Id");

        if (typeof(Entity<Guid>).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property<Guid>("Id")
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }

        // Audit fields - match Entity<TEntity> declaration order:
        // CreatedBy → CreatedAt → UpdatedBy → UpdatedAt → IsDeleted → Index

        builder.Property<string>("CreatedBy");
        builder.Property<DateTimeOffset>("CreatedAt")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()")
            .HasConversion(
                toDb => toDb.ToUniversalTime(),
                fromDb => fromDb
            );
        builder.Property<string>("UpdatedBy");
        builder.Property<DateTimeOffset?>("UpdatedAt")
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );
        builder.Property<bool>("IsDeleted");
        builder.Property<long>("Index")
            .HasDefaultValueSql("DATEDIFF(SECOND, '19700101', GETUTCDATE())");

        builder.HasIndex("Index")
            .IsClustered(false);
    }
    public static void ConfigureForMaterializedPath<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IMaterializedPathEntity<TKey>
    {
        builder.ConfigureForBase();

        builder.Property<TKey>("ParentId")
            .IsRequired(false);
    }
    public static void ConfigureForEnumDb<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {

        builder.HasKey("Id");

        builder.HasIndex("Ma")
            .IsUnique()
            .HasFilter("[Ma] IS NOT NULL AND [Ma] <> ''");

        builder.Property("Ma")
        .HasConversion<string>()
        .HasMaxLength(100)
        .IsRequired();

        builder.Property<string>("Ten")
            .HasMaxLength(1000);
    }
    public static void ConfigureForDanhMuc<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {
        // Column order: Id → Ma → Ten → MoTa → Used → [derived properties 5-19] → audit fields 20-25
        // Using HasColumnOrder() ensures correct order regardless of entity class property order

        // Id - Primary Key (order 0)
        builder.HasKey("Id");

        if (typeof(Entity<Guid>).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property<Guid>("Id")
                .HasColumnOrder(0)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }
        else if (typeof(Entity<int>).IsAssignableFrom(typeof(TEntity)))
        {
            builder.Property<int>("Id")
                .HasColumnOrder(0)
                .UseIdentityColumn();
        }

        // DanhMuc properties: Ma → Ten → MoTa → Used (orders 1-4)
        builder.Property<string>("Ma")
            .HasColumnOrder(1)
            .HasMaxLength(100);

        builder.HasIndex("Ma")
            .IsUnique()
            .HasFilter("[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

        builder.Property<string>("Ten")
            .HasColumnOrder(2)
            .HasMaxLength(1000);

        builder.Property<string>("MoTa")
            .HasColumnOrder(3)
            .HasMaxLength(2000);

        builder.Property<bool>("Used")
            .HasColumnOrder(4);

        // Audit fields at the end (orders 20-25)
        // Derived classes can use orders 5-19 for their specific properties
        builder.Property<string>("CreatedBy")
            .HasColumnOrder(20);

        builder.Property<DateTimeOffset>("CreatedAt")
            .HasColumnOrder(21)
            .HasDefaultValueSql("SYSDATETIMEOFFSET()")
            .HasConversion(
                toDb => toDb.ToUniversalTime(),
                fromDb => fromDb
            );

        builder.Property<string>("UpdatedBy")
            .HasColumnOrder(22);

        builder.Property<DateTimeOffset?>("UpdatedAt")
            .HasColumnOrder(23)
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );

        builder.Property<bool>("IsDeleted")
            .HasColumnOrder(24);

        builder.Property<long>("Index")
            .HasColumnOrder(25)
            .HasDefaultValueSql("DATEDIFF(SECOND, '19700101', GETUTCDATE())");

        builder.HasIndex("Index")
            .IsClustered(false);
    }

    public static void ConfigureForAuditFields<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {
        // Audit fields at the end: CreatedBy → CreatedAt → UpdatedBy → UpdatedAt → IsDeleted → Index
        builder.Property<string>("CreatedBy");
        builder.Property<DateTimeOffset>("CreatedAt")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()")
            .HasConversion(
                toDb => toDb.ToUniversalTime(),
                fromDb => fromDb
            );
        builder.Property<string>("UpdatedBy");
        builder.Property<DateTimeOffset?>("UpdatedAt")
            .HasConversion(
                toDb => toDb.HasValue ? toDb.Value.ToUniversalTime() : (DateTimeOffset?)null,
                fromDb => fromDb
            );
        builder.Property<bool>("IsDeleted");
        builder.Property<long>("Index")
            .HasDefaultValueSql("DATEDIFF(SECOND, '19700101', GETUTCDATE())");

        builder.HasIndex("Index")
            .IsClustered(false);
    }
}