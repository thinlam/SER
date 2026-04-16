namespace BuildingBlocks.Domain.Interfaces;

public interface ICreatedAt
{

    /// <summary>
    /// Thời gian tạo
    /// </summary>
    DateTimeOffset CreatedAt { get; set; }
}
public interface ICreatedAt<TTime>
{

    /// <summary>
    /// Thời gian tạo
    /// </summary>
    TTime CreatedAt { get; set; }
}
