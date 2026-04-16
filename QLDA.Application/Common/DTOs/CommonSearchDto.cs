namespace QLDA.Application.Common.Interfaces;

public record CommonSearchDto : AggregateRootPagination, IFromDateToDate, IMayHaveGlobalFilter, IMayNeedHiddenColumns {
    /// <summary>
    /// Tìm trong khoảng thời gian
    /// </summary>
    /// <remarks>
    /// Pmis #9121
    /// </remarks>
    public DateOnly? TuNgay { get; set; }
    /// <summary>
    /// Tìm trong khoảng thời gian
    /// </summary>
    /// <remarks>
    /// Pmis #9121
    /// </remarks>
    public DateOnly? DenNgay { get; set; }
    /// <summary>
    public Guid? DuAnId { get; set; }
    public int? BuocId { get; set; }
    public string? GlobalFilter { get; set; }
    public List<string>? HiddenColumns { get; set; }
}
