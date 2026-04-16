using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhDuyetQuyetToanConfiguration : AggregateRootConfiguration<QuyetDinhDuyetQuyetToan> {
    public override void Configure(EntityTypeBuilder<QuyetDinhDuyetQuyetToan> builder) {
        builder.ToTable(nameof(QuyetDinhDuyetQuyetToan));

    }
}