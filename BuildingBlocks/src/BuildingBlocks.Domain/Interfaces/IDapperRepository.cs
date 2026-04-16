namespace BuildingBlocks.Domain.Interfaces;

public interface IDapperRepository
{
    public Task<IEnumerable<T>> QueryStoredProcAsync<T>(string procName, object? param = null, string? connectionName = "DefaultConnection");
}
