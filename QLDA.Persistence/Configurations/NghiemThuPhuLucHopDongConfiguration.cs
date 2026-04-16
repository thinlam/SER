using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class NghiemThuPhuLucHopDongConfiguration : IEntityTypeConfiguration<NghiemThuPhuLucHopDong> {
    public void Configure(EntityTypeBuilder<NghiemThuPhuLucHopDong> builder) {
        builder.ToTable(nameof(NghiemThuPhuLucHopDong));

        builder.HasKey(e => new { e.NghiemThuId, e.PhuLucHopDongId });
        
        builder.HasOne(e => e.NghiemThu)
            .WithMany(e => e.NghiemThuPhuLucHopDongs)
            .HasForeignKey(e => e.NghiemThuId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.PhuLucHopDong)
            .WithMany(e => e.NghiemThuPhuLucHopDongs)
            .HasForeignKey(e => e.PhuLucHopDongId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}