namespace QLDA.Domain.Interfaces;

public interface ITienDo {
    /// <summary>
    /// Dự án
    /// </summary>
    public Guid DuAnId { get; set; }
    /// <summary>
    /// Dự án bước id
    /// </summary>
    public int? BuocId { get; set; }
}