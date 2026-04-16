using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations.ViMaster;

public abstract class MasterRootConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class {
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}