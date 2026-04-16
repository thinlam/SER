using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiDuAnConfiguration : AggregateRootConfiguration<DanhMucLoaiDuAn> {
    public override void Configure(EntityTypeBuilder<DanhMucLoaiDuAn> builder) {
        builder.ToTable("DmLoaiDuAn");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.LoaiDuAn)
            .HasForeignKey(e => e.LoaiDuAnId);
    }
}
