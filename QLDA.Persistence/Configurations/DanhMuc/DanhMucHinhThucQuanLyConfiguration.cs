using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucHinhThucQuanLyConfiguration : AggregateRootConfiguration<DanhMucHinhThucQuanLy> {
    public override void Configure(EntityTypeBuilder<DanhMucHinhThucQuanLy> builder) {
        builder.ToTable("DmHinhThucQuanLy");
        builder.ConfigureForDanhMuc();
        
        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.HinhThucQuanLy)
            .HasForeignKey(e => e.HinhThucQuanLyDuAnId);
    }
}
