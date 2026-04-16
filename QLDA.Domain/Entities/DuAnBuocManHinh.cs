using QLDA.Domain.Entities.DanhMuc;
using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;

/// <summary>
/// Cân lưu lại id để load màn hình đã chọn
/// </summary>
public class DuAnBuocManHinh : IJunctionEntity, IAggregateRoot {
    public int BuocId { get; set; }
    public int ManHinhId { get; set; }
    /// <summary>
    /// Thứ tự màn hình trong bước (để giữ lại thứ tự gốc)
    /// </summary>
    public int Stt { get; set; }

    #region Navigation Properties

    public DuAnBuoc? DuAnBuoc { get; set; }
    public DanhMucManHinh? ManHinh { get; set; }

    #endregion
}