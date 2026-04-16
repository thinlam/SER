namespace BuildingBlocks.Domain.Interfaces;

public interface IMayHaveUpdate
{
    /// <summary>
    /// Người cập nhật <br/>
    /// Kết hợp với IsDeleted = Người xoá
    /// </summary>
    string UpdatedBy { get; set; }
    /// <summary>
    /// Thời gian cập nhật
    /// </summary>
    DateTimeOffset? UpdatedAt { get; set; }
}

public interface IUpdatedAt<TTime>
{
    /// <summary>
    /// Thời gian cập nhật
    /// </summary>
    TTime? UpdatedAt { get; set; }
}
