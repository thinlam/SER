using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhLapBenMoiThauConfiguration : AggregateRootConfiguration<QuyetDinhLapBenMoiThau> {
    public override void Configure(EntityTypeBuilder<QuyetDinhLapBenMoiThau> builder) {
        builder.ToTable(nameof(QuyetDinhLapBenMoiThau));
    }
}