using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Application.Common.Mapping;

public static class MappingConfiguration
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int skip, int take, CancellationToken cancellationToken = default) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), skip, take, cancellationToken);
    public static PaginatedList<TDestination> ToPaginatedList<TDestination>(
    this IEnumerable<TDestination> items, int skip, int take) where TDestination : class
    => PaginatedList<TDestination>.Create(items, skip, take);
}
