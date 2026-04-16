namespace BuildingBlocks.Domain.Interfaces;

public interface IMayHaveCreated : ICreatedAt
{
    /// <summary>
    /// Người tạo
    /// </summary>
    string CreatedBy { get; set; }
}
