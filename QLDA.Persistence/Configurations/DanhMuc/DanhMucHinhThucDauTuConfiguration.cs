using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucHinhThucDauTuConfiguration : AggregateRootConfiguration<DanhMucHinhThucDauTu> {
    public override void Configure(EntityTypeBuilder<DanhMucHinhThucDauTu> builder) {
        builder.ToTable("DmHinhThucDauTu");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.HinhThucDauTu)
            .HasForeignKey(e => e.HinhThucDauTuId);
    }
}
