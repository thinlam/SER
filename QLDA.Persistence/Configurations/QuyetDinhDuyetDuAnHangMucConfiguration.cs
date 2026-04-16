using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhDuyetDuAnHangMucConfiguration : AggregateRootConfiguration<QuyetDinhDuyetDuAnHangMuc> {
    public override void Configure(EntityTypeBuilder<QuyetDinhDuyetDuAnHangMuc> builder) {
        builder.ToTable(nameof(QuyetDinhDuyetDuAnHangMuc));
        builder.ConfigureForBase();



    }
}