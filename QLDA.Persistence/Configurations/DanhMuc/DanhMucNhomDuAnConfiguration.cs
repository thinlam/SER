using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucNhomDuAnConfiguration : AggregateRootConfiguration<DanhMucNhomDuAn> {
    public override void Configure(EntityTypeBuilder<DanhMucNhomDuAn> builder) {
        builder.ToTable("DmNhomDuAn");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.NhomDuAn)
            .HasForeignKey(e => e.NhomDuAnId);
    }
}
