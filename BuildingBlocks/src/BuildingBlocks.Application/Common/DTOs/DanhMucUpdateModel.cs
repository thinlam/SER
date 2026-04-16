namespace BuildingBlocks.Application.Common.DTOs;

public class DanhMucUpdateModel<TKey>
{
    public virtual TKey Id { get; set; } = default!;

    /// <summary>
    /// Mã
    /// </summary>
    [DefaultValue(null)]
    public virtual string? Ma { get; set; }

    /// <summary>
    /// Tên
    /// </summary>
    [DefaultValue(null)]
    public virtual string? Ten { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    [DefaultValue(null)]
    public virtual string? MoTa { get; set; }

    // /// <summary>
    // /// Số thứ tự hiển thị trên giao diện
    // /// </summary>
    // [DefaultValue(null)]
    // public virtual int? Stt { get; set; }

    public virtual bool Used { get; set; } = true;
}
