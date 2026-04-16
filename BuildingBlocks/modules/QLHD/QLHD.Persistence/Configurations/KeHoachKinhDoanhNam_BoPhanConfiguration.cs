using BuildingBlocks.Persistence.Configurations;

namespace QLHD.Persistence.Configurations;

public class KeHoachKinhDoanhNam_BoPhanConfiguration : AggregateRootConfiguration<KeHoachKinhDoanhNam_BoPhan>
{
    public override void Configure(EntityTypeBuilder<KeHoachKinhDoanhNam_BoPhan> builder)
    {
        builder.ToTable("KeHoachKinhDoanhNam_BoPhan");
        builder.ConfigureForBase();

        builder.Property(e => e.Ten).HasMaxLength(200).IsRequired();

        // Decimal precision for currency fields
        builder.Property(e => e.DoanhKySo).HasPrecision(18, 2);
        builder.Property(e => e.LaiGopKy).HasPrecision(18, 2);
        builder.Property(e => e.DoanhSoXuatHoaDon).HasPrecision(18, 2);
        builder.Property(e => e.LaiGopXuatHoaDon).HasPrecision(18, 2);
        builder.Property(e => e.ThuTien).HasPrecision(18, 2);
        builder.Property(e => e.LaiGopThuTien).HasPrecision(18, 2);
        builder.Property(e => e.ChiPhiTrucTiep).HasPrecision(18, 2);
        builder.Property(e => e.ChiPhiPhanBo).HasPrecision(18, 2);
        builder.Property(e => e.LoiNhuan).HasPrecision(18, 2);

        // Index for parent lookup
        builder.HasIndex(e => e.KeHoachKinhDoanhNamId);
    }
}