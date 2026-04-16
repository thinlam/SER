using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class VanBanPhapLyConfiguration : AggregateRootConfiguration<VanBanPhapLy> {
    public override void Configure(EntityTypeBuilder<VanBanPhapLy> builder) {
        builder.ToTable(nameof(VanBanPhapLy));

    }
}