using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.DTOs;

public static class KeHoachThangMapping
{
    /// <summary>
    /// Format DateOnly to display string "Tháng {M} - {yyyy}"
    /// </summary>
    public static string ToThangDisplay(this DateOnly date)
        => $"Tháng {date.Month} - {date.Year}";

    public static KeHoachThangDto ToDto(this KeHoachThang entity) => new()
    {
        Id = entity.Id,
        TuNgay = entity.TuNgay,
        DenNgay = entity.DenNgay,
        TuThangDisplay = entity.TuThangDisplay,
        DenThangDisplay = entity.DenThangDisplay,
        GhiChu = entity.GhiChu
    };

    public static KeHoachThang ToEntity(this KeHoachThangInsertModel model)
    {
        var tuNgay = model.TuNgay.ToDateOnly();
        var denNgay = model.DenNgay.ToDateOnly();

        return new KeHoachThang
        {
            TuNgay = tuNgay,
            DenNgay = denNgay,
            TuThangDisplay = tuNgay.ToThangDisplay(),
            DenThangDisplay = denNgay.ToThangDisplay(),
            GhiChu = model.GhiChu
        };
    }

    public static void UpdateFrom(this KeHoachThang entity, KeHoachThangUpdateModel model)
    {
        var tuNgay = model.TuNgay.ToDateOnly();
        var denNgay = model.DenNgay.ToDateOnly();

        entity.TuNgay = tuNgay;
        entity.DenNgay = denNgay;
        entity.TuThangDisplay = tuNgay.ToThangDisplay();
        entity.DenThangDisplay = denNgay.ToThangDisplay();
        entity.GhiChu = model.GhiChu;
    }
}