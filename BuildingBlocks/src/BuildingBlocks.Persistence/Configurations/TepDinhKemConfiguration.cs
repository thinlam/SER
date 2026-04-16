using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingBlocks.Persistence.Configurations;

public class TepDinhKemConfiguration : AggregateRootConfiguration<TepDinhKem>
{
    public override void Configure(EntityTypeBuilder<TepDinhKem> builder)
    {
        builder.ToTable("TepDinhKems");
        builder.ConfigureForBase();

    }
}