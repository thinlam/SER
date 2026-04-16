using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class TepDinhKemConfiguration : AggregateRootConfiguration<TepDinhKem> {
    public override void Configure(EntityTypeBuilder<TepDinhKem> builder) {
        builder.ToTable(nameof(TepDinhKem));
        builder.ConfigureForBase();
    }
}