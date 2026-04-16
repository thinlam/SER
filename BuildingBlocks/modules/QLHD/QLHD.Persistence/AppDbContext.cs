using System.Data;
using BuildingBlocks.Domain.Entities;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Persistence.Configurations;
using BuildingBlocks.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using QLHD.Domain.Entities.DanhMuc;
using QLHD.Persistence.Configurations.SeedData.Business;
using QLHD.Persistence.Configurations.SeedData.DanhMuc;
using QLHD.Persistence.Schema;

namespace QLHD.Persistence;

/// <summary>
/// Schema-aware DbContext for QLHD module.
/// Supports multiple deployment environments (dbo/dev) with separate migration histories.
/// </summary>
public class AppDbContext(IConfiguration configuration, DbContextOptions<AppDbContext> options, SchemaConfig? schemaConfig = null) : DbContext(options), IUnitOfWork, ISchemaAwareDbContext {
    private IDbContextTransaction DbContextTransaction = null!;
    protected readonly string Connection = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found");

    /// <summary>
    /// Schema name for this DbContext instance.
    /// Used by HasDefaultSchema in OnModelCreating and migration history table.
    /// </summary>
    public string Schema { get; } = schemaConfig?.Schema ?? "dbo";

    public static readonly string MigrationsHistory = "__EFMigrationsHistory";
    protected readonly string _connection = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found");

    public bool HasTransaction => Database.CurrentTransaction != null;

    // Using IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() so DbSet<TEntity>() is not needed here

    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
        CancellationToken cancellationToken = default) {
        DbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        return DbContextTransaction;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) {
        await DbContextTransaction.CommitAsync(cancellationToken);
    }

    public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : class, IHasKey<TKey>, IAggregateRoot, new()
        where TKey : notnull
        => new Repository<TEntity, TKey>(this);


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Don't use HasDefaultSchema - it causes validation issues with InsertData
        // Instead, set explicit schema on each entity via ToTable()
        // if (!string.Equals(Schema, "dbo", StringComparison.OrdinalIgnoreCase))
        // {
        //     modelBuilder.HasDefaultSchema(Schema);
        // }

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName!.Contains("QLHD") || a.FullName.Contains("BuildingBlocks"));

        foreach (var assembly in assemblies) {
            // Apply AggregateRootConfiguration<> types (for aggregate roots)
            modelBuilder.ApplyConfigurationsFromAssembly(
                assembly,
                t => t.BaseType != null &&
                     t.BaseType.IsGenericType &&
                     t.BaseType.GetGenericTypeDefinition() == typeof(AggregateRootConfiguration<>)
            );

            // Apply IEntityTypeConfiguration<> types (for junction entities, etc.)
            modelBuilder.ApplyConfigurationsFromAssembly(
                assembly,
                t => t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)) &&
                     (t.BaseType == null ||
                      !t.BaseType.IsGenericType ||
                      t.BaseType.GetGenericTypeDefinition() != typeof(AggregateRootConfiguration<>))
            );
        }

        modelBuilder.Entity<TepDinhKem>(e => {
            e.ToTable(t => t.ExcludeFromMigrations());
        });

        // === SEED DATA ===
        // Note: Seed data in migrations was removed due to EF Core validation issues
        // with schema-aware migrations. Seed data should be applied at runtime.
        // The HasData here is used for model validation but actual seeding happens
        // via separate SQL scripts or runtime data seeding.
        // Layer 1: DanhMuc (no FK dependencies)
        modelBuilder.Entity<DanhMucLoaiTrangThai>(e => { e.SeedDanhMucLoaiTrangThai(); });
        modelBuilder.Entity<DanhMucTrangThai>(e => { e.SeedDanhMucTrangThai(); });
        modelBuilder.Entity<DanhMucLoaiHopDong>(e => { e.SeedDanhMucLoaiHopDong(); });
        modelBuilder.Entity<DanhMucLoaiThanhToan>(e => { e.SeedDanhMucLoaiThanhToan(); });
        modelBuilder.Entity<DanhMucLoaiChiPhi>(e => { e.SeedDanhMucLoaiChiPhi(); });
        modelBuilder.Entity<DanhMucNguoiPhuTrach>(e => { e.SeedDanhMucNguoiPhuTrach(); });
        modelBuilder.Entity<DanhMucNguoiTheoDoi>(e => { e.SeedDanhMucNguoiTheoDoi(); });
        modelBuilder.Entity<DanhMucGiamDoc>(e => { e.SeedDanhMucGiamDoc(); });
        modelBuilder.Entity<DoanhNghiep>(e => { e.SeedDoanhNghiep(); });

        // Layer 2: Business entities (depend on DanhMuc)
        modelBuilder.Entity<KhachHang>(e => { e.SeedKhachHang(); });
        modelBuilder.Entity<DuAn>(e => { e.SeedDuAn(); });
        modelBuilder.Entity<HopDong>(e => { e.SeedHopDong(); });

        // Layer 3: Junction tables (depend on DuAn/HopDong)
        modelBuilder.Entity<DuAnPhongBanPhoiHop>(e => { e.SeedDuAnPhongBanPhoiHop(); });
        modelBuilder.Entity<HopDongPhongBanPhoiHop>(e => { e.SeedHopDongPhongBanPhoiHop(); });

        // Layer 4: Child entities (depend on DuAn/HopDong/TienDo)
        modelBuilder.Entity<CongViec>(e => { e.SeedCongViec(); });
        modelBuilder.Entity<TienDo>(e => { e.SeedTienDo(); });
        modelBuilder.Entity<BaoCaoTienDo>(e => { e.SeedBaoCaoTienDo(); });
        modelBuilder.Entity<KhoKhanVuongMac>(e => { e.SeedKhoKhanVuongMac(); });
        modelBuilder.Entity<PhuLucHopDong>(e => { e.SeedPhuLucHopDong(); });

        // Apply schema to ALL entities AFTER all configurations are applied
        // This must come AFTER seed data configurations which add entities
        // Use ToTable() instead of SetSchema() to ensure proper mapping for validation
        if (!string.Equals(Schema, "dbo", StringComparison.OrdinalIgnoreCase)) {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
                var tableName = entityType.GetTableName();
                if (!string.IsNullOrEmpty(tableName) && string.IsNullOrEmpty(entityType.GetSchema())) {
                    // Use ToTable via the entity's CLR type
                    modelBuilder.Entity(entityType.ClrType, e => e.ToTable(tableName, Schema));
                }
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (optionsBuilder.IsConfigured)
            return;
        optionsBuilder.UseSqlServer(_connection, x => x.MigrationsHistoryTable(MigrationsHistory, Schema));
    }

    /// <summary>
    /// NVTT-specific: Get junction repository for entities without IAggregateRoot
    /// </summary>
    public IJunctionRepository<TEntity> GetJunctionRepository<TEntity>() where TEntity : class {
        return new JunctionRepository<TEntity>(this);
    }
}