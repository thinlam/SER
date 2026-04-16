using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class BaoCaoTienDoConfiguration : AggregateRootConfiguration<BaoCaoTienDo> {
    public override void Configure(EntityTypeBuilder<BaoCaoTienDo> builder) {
        builder.ToTable(nameof(BaoCaoTienDo));
    }
}