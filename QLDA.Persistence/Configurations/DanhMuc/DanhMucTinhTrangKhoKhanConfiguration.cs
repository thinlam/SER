using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucTinhTrangKhoKhanConfiguration : AggregateRootConfiguration<DanhMucTinhTrangKhoKhan> {
    public override void Configure(EntityTypeBuilder<DanhMucTinhTrangKhoKhan> builder) {
        builder.ToTable("DmTinhTrangKhoKhan");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.KhoKhanVuongMacs)
            .WithOne(e => e.TinhTrang)
            .HasForeignKey(e => e.TinhTrangId);
    }
}
