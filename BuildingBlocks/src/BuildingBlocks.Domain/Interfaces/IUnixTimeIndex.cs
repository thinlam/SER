namespace BuildingBlocks.Domain.Interfaces;

public interface IUnixTimeIndex
{
    /// <summary>
    /// Dùng Unix Time để tạo index sắp xếp các bản ghi
    /// </summary>
    long Index { get; set; }
}
