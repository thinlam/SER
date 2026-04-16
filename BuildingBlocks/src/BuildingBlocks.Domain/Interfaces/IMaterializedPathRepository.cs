namespace BuildingBlocks.Domain.Interfaces;

public interface IMaterializedPathRepository<TEntity, TKey>
    where TEntity : class, IHasKey<TKey>, IAggregateRoot, new()
    where TKey : notnull
{
    bool IsMaterializedPath();
    /// <summary>
    /// Tổ tiên
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<IMaterializedPathEntity<TKey>>> GetAncestorsAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Con cháu / hậu duệ
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<IMaterializedPathEntity<TKey>>> GetDescendantsAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reset sửa lỗi TreeNode
    /// </summary>
    /// <param name="allNodes"></param>
    /// <param name="getId"></param>
    /// <param name="getParentId"></param>
    /// <param name="setPath"></param>
    /// <param name="setLevel"></param>
    /// <param name="setParentId"></param>
    void ResetMaterializedPathsInMemory(
        List<TEntity> allNodes,
        Func<TEntity, TKey> getId,
        Func<TEntity, TKey?> getParentId,
        Action<TEntity, string> setPath,
        Action<TEntity, int> setLevel,
        Action<TEntity, TKey?> setParentId
    );
    void InitializeNode(TEntity entity, TEntity? parent);
    Task MoveNodeAsync(TEntity entity, TEntity? parent, CancellationToken cancellationToken = default);
}
