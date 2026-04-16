using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhLapHoiDongThamDinhConfiguration : AggregateRootConfiguration<QuyetDinhLapHoiDongThamDinh> {
    public override void Configure(EntityTypeBuilder<QuyetDinhLapHoiDongThamDinh> builder) {
        builder.ToTable(nameof(QuyetDinhLapHoiDongThamDinh));
    }
}