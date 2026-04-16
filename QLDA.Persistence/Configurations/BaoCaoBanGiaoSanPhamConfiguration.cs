using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class BaoCaoBanGiaoSanPhamConfiguration : AggregateRootConfiguration<BaoCaoBanGiaoSanPham> {
    public override void Configure(EntityTypeBuilder<BaoCaoBanGiaoSanPham> builder) {
        builder.ToTable(nameof(BaoCaoBanGiaoSanPham));
        
        builder.HasOne(e => e.DonViBanGiao)
            .WithMany(e => e.BaoCaoBanGiaoSanPhams)
            .HasForeignKey(e => e.DonViBanGiaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}