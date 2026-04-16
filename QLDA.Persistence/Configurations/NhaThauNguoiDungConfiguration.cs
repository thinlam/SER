using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDA.Persistence.Configurations;

public class NhaThauNguoiDungConfiguration : AggregateRootConfiguration<NhaThauNguoiDung> {
    public override void Configure(EntityTypeBuilder<NhaThauNguoiDung> builder) {
        builder.ToTable(nameof(NhaThauNguoiDung));
        builder.ConfigureForBase();

        builder.HasOne(e => e.NhaThau)
            .WithMany(e => e.NhaThauNguoiDungs)
            .HasForeignKey(e => e.NhaThauId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unique constraint: one user per contractor
        builder.HasIndex(e => new { e.NhaThauId, e.NguoiDungId }).IsUnique();
    }
}
