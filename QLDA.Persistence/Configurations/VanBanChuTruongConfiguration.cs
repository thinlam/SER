using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class VanBanChuTruongConfiguration : AggregateRootConfiguration<VanBanChuTruong> {
    public override void Configure(EntityTypeBuilder<VanBanChuTruong> builder) {
        builder.ToTable(nameof(VanBanChuTruong));
        
        
    }
}