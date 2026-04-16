using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucTinhTrangThucHienLcntConfiguration : AggregateRootConfiguration<DanhMucTinhTrangThucHienLcnt>
{
    public override void Configure(EntityTypeBuilder<DanhMucTinhTrangThucHienLcnt> builder)
    {
        builder.ToTable("DmTinhTrangThucHienLcnt");
        builder.ConfigureForDanhMuc();

        // Add navigation properties configuration here if needed
    }
}
