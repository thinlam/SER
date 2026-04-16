using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.DTOs;


/// <summary>
/// Base search model cho aggregate roots với pagination và search string
/// </summary>
public record AggregateRootSearch : AggregateRootPagination, ISearchString
{
    /// <summary>
    /// Từ khoá tìm kiếm
    /// </summary>
    public string? SearchString { get; set; }
}
