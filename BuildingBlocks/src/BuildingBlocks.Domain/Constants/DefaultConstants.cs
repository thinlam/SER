namespace BuildingBlocks.Domain.Constants;

/// <summary>
/// Constants cho các giá trị mặc định của hệ thống BuildingBlocks
/// </summary>
public static class DefaultConstants {
    /// <summary>
    /// ID mặc định cho entity mới tạo
    /// </summary>
    public const int DEFAULT_NEW_ENTITY_ID = 1;

    /// <summary>
    /// Giá trị mặc định cho soft delete
    /// </summary>
    public const bool DEFAULT_IS_DELETED = false;

    /// <summary>
    /// Giá trị mặc định cho Used property
    /// </summary>
    public const bool DEFAULT_USED = true;

    /// <summary>
    /// Level mặc định cho root node trong materialized path
    /// </summary>
    public const int DEFAULT_ROOT_LEVEL = 0;

    public const string UNKNOWN = "Không rõ";
}