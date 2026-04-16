namespace BuildingBlocks.Domain.Interfaces;

public interface IPagination {
    int PageIndex { get; init; }

    int PageSize { get; init; }

    int Take(bool export = false);
    int Skip(bool export = false);
}
