using Microsoft.EntityFrameworkCore;

namespace QLDA.Application.Common.Mapping;

public static class MappingConfiguration {
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int pageNumber, int pageSize,CancellationToken cancellationToken = default) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize,cancellationToken);
}