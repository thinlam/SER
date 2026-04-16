namespace QLDA.WebApi.Models.DangTaiKeHoachLcntLenMangs;

public record DangTaiKeHoachLcntLenMangSearchModel : CommonSearchModel, IFromDateToDate {
    public Guid? KeHoachLuaChonNhaThauId { get; set; }
    public ETrangThaiMoiThau? TrangThaiId { get; set; }
    public DateOnly? TuNgay { get; set; }
    public DateOnly? DenNgay { get; set; }
}