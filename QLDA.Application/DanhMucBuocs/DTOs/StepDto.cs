namespace QLDA.Application.DanhMucBuocs.DTOs;

public class StepDto {
    public int Id { get; set; }

    /// <summary>
    /// ID bước cha (nếu có)
    /// </summary>
    public int ParentId { get; set; }

    public string? Path { get; set; }

    /// <summary>
    /// Có thể là Khoá logic để truy vấn liên quan đến bước
    /// </summary>
    public int? BuocId { get; set; }

    /// <summary>
    /// Cấp phân cấp của bước (0 là gốc)
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Thứ tự hiển thị trong danh sách
    /// </summary>
    public int Stt { get; set; }

    public bool Used { get; set; }

    /// <summary>
    /// Tên bước (sẽ được gán prefix trong Tree)
    /// </summary>
    public string Ten { get; set; } = string.Empty;

    /// <summary>
    /// Tên chưa thêm vị trí
    /// </summary>
    public string? OriginalTen { get; set; } = string.Empty;
    public string? PartialView { get; set; } = string.Empty;
    /// <summary>
    /// Giai đoạn
    /// </summary>
    public PhaseDto? Phase { get; set; }
    public ICollection<DanhMucBuocManHinh>? BuocManHinhs { get; set; } = [];

    /*
     * Số ngày thực hiện dự kiến mỗi bước
     * Là một trường quan trọng kết hợp với ngày bắt đầu NgayBatDau ở bảng DuAn để tính và thứ tự treelist của bảng này
     * => tính ngày bắt đầu - kết thúc dự kiến trong dự án bước (DuAnBuoc)
     * Chú giải:
     * + bước đầu tiên ngày bắt đầu dự kiến là ngày bắt đầu dự kiến
     * + các bước tiếp theo, ngày bắt đầu dự kiến là ngày kết thúc dự kiến của bước trước đó cộng thêm 1 ngày
     * + ngày kết thúc bằng ngày dự kiến cộng ngày theo số ngày dự kiến
     * Lưu ý: Khi tính phải sắp xếp vị trí chúng dưới dạng treelist - sắp xếp theo level, số thứ  tự
     * ==================================================================
     * Ví dụ dự án có ngày bắt đầu: 20/11
     * duAnBuoc thứ 1 (sau khi sắp xếp treelist):
     * - duAnBuoc.ngayBatDauDuKien = duAn.ngayBatDau
     * - duAnBuoc.ngayKetThucDuKien = duAn.ngayBatDau.AddDays(dmBuoc.SoNgayThucHien)
     * duAnBuoc thứ n
     * - duAnBuoc.ngayBatDauDuKien = duAnBuoc[n-1].ngayKetThucDuKien.AddDays(1)
     * - duAnBuoc.ngayKetThucDuKien = duAn.ngayBatDau.AddDays(dmBuoc.SoNgayThucHien)
     */
    /// <summary>
    /// go to declaration để xem comment nhé 
    /// </summary>
    public int SoNgayThucHien { get; set; }
}