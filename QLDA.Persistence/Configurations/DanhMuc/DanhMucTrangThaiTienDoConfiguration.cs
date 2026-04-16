using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucTrangThaiTienDoConfiguration : AggregateRootConfiguration<DanhMucTrangThaiTienDo> {
    public override void Configure(EntityTypeBuilder<DanhMucTrangThaiTienDo> builder) {
        builder.ToTable("DmTrangThaiTienDo");
        builder.ConfigureForDanhMuc();

    }
}