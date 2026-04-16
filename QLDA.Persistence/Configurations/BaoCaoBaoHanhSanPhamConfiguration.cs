using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class BaoCaoBaoHanhSanPhamConfiguration : AggregateRootConfiguration<BaoCaoBaoHanhSanPham> {
    public override void Configure(EntityTypeBuilder<BaoCaoBaoHanhSanPham> builder) {
        builder.ToTable(nameof(BaoCaoBaoHanhSanPham));

    }
}