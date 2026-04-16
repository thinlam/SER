using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public abstract class AggregateRootConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class {
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}