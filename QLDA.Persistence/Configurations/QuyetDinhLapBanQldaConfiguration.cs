using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhLapBanQldaConfiguration : AggregateRootConfiguration<QuyetDinhLapBanQLDA> {
    public override void Configure(EntityTypeBuilder<QuyetDinhLapBanQLDA> builder) {
        builder.ToTable(nameof(QuyetDinhLapBanQLDA));
    }
}