// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using QLDA.Domain.Entities.ViMaster;
//
// namespace QLDA.Persistence.Configurations.ViMaster;
//
// public class DanhMucChucVuConfiguration : AggregateRootConfiguration<DanhMucChucVu> {
//     public override void Configure(EntityTypeBuilder<DanhMucChucVu> builder) {
//
//         builder.HasKey(e => e.ChucVuId);
//         builder.ToTable("DM_CHUCVU");
//         builder.Property(e => e.ChucVuId).HasColumnName("ChucVuID");
//         builder.Property(e => e.CapDonViId).HasColumnName("CapDonViID");
//         builder.Property(e => e.MaChucVu).HasMaxLength(5);
//         builder.Property(e => e.MoTa).HasMaxLength(4000);
//         builder.Property(e => e.TenChucVu).HasMaxLength(500);
//         builder.HasOne(d => d.CapDonVi).WithMany(p => p.ChucVus)
//             .HasForeignKey(d => d.CapDonViId);
//     }
// }