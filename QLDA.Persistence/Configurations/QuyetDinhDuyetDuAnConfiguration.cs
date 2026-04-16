using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class QuyetDinhDuyetDuAnConfiguration : AggregateRootConfiguration<QuyetDinhDuyetDuAn> {
    public override void Configure(EntityTypeBuilder<QuyetDinhDuyetDuAn> builder) {
        builder.ToTable(nameof(QuyetDinhDuyetDuAn));


        builder.HasMany(e => e.QuyetDinhDuyetDuAnNguonVons)
            .WithOne(e => e.QuyetDinhDuyetDuAn)
            .HasForeignKey(e => e.QuyetDinhDuyetDuAnId);
    }
}