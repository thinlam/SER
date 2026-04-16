using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucLinhVucConfiguration : AggregateRootConfiguration<DanhMucLinhVuc> {
    public override void Configure(EntityTypeBuilder<DanhMucLinhVuc> builder) {
        builder.ToTable("DmLinhVuc");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.LinhVuc)
            .HasForeignKey(e => e.LinhVucId);
    }
}
