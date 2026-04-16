using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucQuyTrinhConfiguration : AggregateRootConfiguration<DanhMucQuyTrinh> {
    public override void Configure(EntityTypeBuilder<DanhMucQuyTrinh> builder) {
        builder.ToTable("DmQuyTrinh");
        builder.ConfigureForDanhMuc();

        builder.HasIndex(e => e.MacDinh).IsUnique()
            .HasFilter("[MacDinh] = 1 AND [IsDeleted] = 0");

        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.QuyTrinh)
            .HasForeignKey(e => e.QuyTrinhId);

        builder.HasMany(e => e.Buocs)
            .WithOne(e => e.QuyTrinh)
            .HasForeignKey(e => e.QuyTrinhId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}