using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDA.Domain.Entities.DanhMuc;

namespace QLDA.Persistence.Configurations.DanhMuc;

public class DanhMucLoaiDuAnTheoNamConfiguration : AggregateRootConfiguration<DanhMucLoaiDuAnTheoNam> {
    public override void Configure(EntityTypeBuilder<DanhMucLoaiDuAnTheoNam> builder) {
        builder.ToTable("DmLoaiDuAnTheoNam");
        builder.ConfigureForDanhMuc();

        builder.HasMany(e => e.DuAns)
            .WithOne(e => e.LoaiDuAnTheoNam)
            .HasForeignKey(e => e.LoaiDuAnTheoNamId);
        builder.HasData(
            new DanhMucLoaiDuAnTheoNam {
                Id = 1, Ma = "CBDT", Ten = "Chuẩn bị đầu tư", CreatedAt = DateTimeOffset.MinValue
            },
            new DanhMucLoaiDuAnTheoNam {
                Id = 2, Ma = "CT", Ten = "Chuyển tiếp", CreatedAt = DateTimeOffset.MinValue
            },
            new DanhMucLoaiDuAnTheoNam {
                Id = 3, Ma = "KCM", Ten = "Khởi công mới", CreatedAt = DateTimeOffset.MinValue
            },
            new DanhMucLoaiDuAnTheoNam {
                Id = 4, Ma = "KLTD", Ten = "Khối lượng tồn đọng", CreatedAt = DateTimeOffset.MinValue
            }
        );
    }
}