using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucTrangThaiDuAnConfiguration : AggregateRootConfiguration<DanhMucTrangThaiDuAn> {
    public override void Configure(EntityTypeBuilder<DanhMucTrangThaiDuAn> builder) {
        builder.ToTable("DmTrangThaiDuAn");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.TrangThaiDuAn)
            .HasForeignKey(e => e.TrangThaiDuAnId);

        builder.HasData(
            new DanhMucTrangThaiDuAn {
                Id = 1, Ma = "DTH", Ten = "Đang thực hiện", CreatedAt = DateTimeOffset.MinValue
            },
            new DanhMucTrangThaiDuAn {
                Id = 2, Ma = "PDDT", Ten = "Đã phê duyệt đầu tư", CreatedAt = DateTimeOffset.MinValue
            },
            new DanhMucTrangThaiDuAn {
                Id = 3, Ma = "HT", Ten = "Đã hoàn thành", CreatedAt = DateTimeOffset.MinValue
            },
            new DanhMucTrangThaiDuAn {
                Id = 4, Ma = "TD", Ten = "Tạm dừng", CreatedAt = DateTimeOffset.MinValue
            }
        );
    }
}