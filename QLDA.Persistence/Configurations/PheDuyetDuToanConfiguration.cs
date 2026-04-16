using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class PheDuyetDuToanConfiguration : AggregateRootConfiguration<PheDuyetDuToan> {
    public override void Configure(EntityTypeBuilder<PheDuyetDuToan> builder) {
        builder.ToTable(nameof(PheDuyetDuToan));
        
    }
}