namespace QLDA.WebApi.Models.Common;

public record CommonSearchModel : AggregateRootPagination, IMayNeedHiddenColumns {
    public Guid? DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? GlobalFilter { get; set; }
    public List<string>? HiddenColumns { get; set; }
}