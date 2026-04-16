using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucMucDoKhoKhanConfiguration : AggregateRootConfiguration<DanhMucMucDoKhoKhan> {
    public override void Configure(EntityTypeBuilder<DanhMucMucDoKhoKhan> builder) {
        builder.ToTable("DmMucDoKhoKhan");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.BaoCaoKhoKhanVuongMacs)
            .WithOne(e => e.MucDo)
            .HasForeignKey(e => e.MucDoKhoKhanId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}