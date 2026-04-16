using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucChuDauTuConfiguration : AggregateRootConfiguration<DanhMucChuDauTu> {
    public override void Configure(EntityTypeBuilder<DanhMucChuDauTu> builder) {
        builder.ToTable("DmChuDauTu");
        builder.ConfigureForDanhMuc();


        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.ChuDauTu)
            .HasForeignKey(e => e.ChuDauTuId);

        
    }
}
