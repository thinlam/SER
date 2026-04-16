using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class ThanhVienBanQldaConfiguration : AggregateRootConfiguration<ThanhVienBanQLDA> {
    public override void Configure(EntityTypeBuilder<ThanhVienBanQLDA> builder) {
        builder.ToTable(nameof(ThanhVienBanQLDA));
        builder.ConfigureForBase();
        builder.HasOne(e => e.QuyetDinhLapBanQLDA)
            .WithMany(e => e.ThanhViens)
            .HasForeignKey(e => e.QuyetDinhId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}