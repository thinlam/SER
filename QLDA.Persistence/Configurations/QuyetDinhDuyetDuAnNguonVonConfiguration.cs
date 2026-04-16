using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhDuyetDuAnNguonVonConfiguration : AggregateRootConfiguration<QuyetDinhDuyetDuAnNguonVon> {
    public override void Configure(EntityTypeBuilder<QuyetDinhDuyetDuAnNguonVon> builder) {
        builder.ToTable(nameof(QuyetDinhDuyetDuAnNguonVon));
        builder.ConfigureForBase();


        builder.HasMany(e => e.QuyetDinhDuyetDuAnHangMucs)
            .WithOne(e => e.QuyetDinhDuyetDuAnNguonVon)
            .HasForeignKey(e => e.QuyetDinhDuyetDuAnNguonVonId);


    }
}