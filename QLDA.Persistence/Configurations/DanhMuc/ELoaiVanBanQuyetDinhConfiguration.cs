using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class ELoaiVanBanQuyetDinhConfiguration : AggregateRootConfiguration<ELoaiVanBanQuyetDinh> {
    public override void Configure(EntityTypeBuilder<ELoaiVanBanQuyetDinh> builder) {
        builder.ToTable("E_LoaiVanBanQuyetDinh");
        builder.ConfigureForEnumDb();
    }
}