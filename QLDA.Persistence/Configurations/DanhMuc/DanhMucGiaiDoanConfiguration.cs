using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucGiaiDoanConfiguration : AggregateRootConfiguration<DanhMucGiaiDoan> {
    public override void Configure(EntityTypeBuilder<DanhMucGiaiDoan> builder) {
        builder.ToTable("DmGiaiDoan");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.DanhMucBuocs)
            .WithOne(e => e.GiaiDoan)
            .HasForeignKey(e => e.GiaiDoanId)
            .OnDelete(DeleteBehavior.SetNull);
            
        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.GiaiDoanHienTai)
            .HasForeignKey(e => e.GiaiDoanHienTaiId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}