using BuildingBlocks.Domain.Constants;
using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.DTOs;

public record AggregateRootPagination : IPagination {
    /// <summary>
    /// Vị trí bắt đầu trang <br/>
    /// Mặc định bắt đầu từ 0
    /// </summary>
    /// <example>0</example>
    public int PageIndex { get; init; }


    private int _pageSize;

    /// <summary>
    /// Tổng bản ghi muốn lấy <br/>
    /// Max size là 100 bản ghi <br/>
    /// Nếu lớn hơn 100 thì lấy theo mặc định là 10 bản ghi <br/>
    /// </summary>
    /// <example>10</example>
    public int PageSize {
        get => _pageSize;
        init => _pageSize = value > PaginationConstants.MAX_PAGE_SIZE
            ? PaginationConstants.DEFAULT_PAGE_SIZE
            : value;
    }


    public int Take(bool export = false) => export ? 0 : Math.Max(PageSize, 0);

    public int Skip(bool export = false) => export ? 0 : Math.Max((PageIndex - 1) * PageSize, 0);
}
