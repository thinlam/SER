using System.Text.Json.Serialization;

namespace QLDA.Application.DanhMucBuocs.DTOs;

public class DanhMucBuocDto : DanhMucDto<int> {
    [JsonIgnore] public int? BuocId { get; set; }
    public int? ParentId { get; set; }
    public string? Path { get; set; }
    public int Level { get; set; }
    public int QuyTrinhId { get; set; }
    public int? GiaiDoanId { get; set; }

    public string? PartialView { get; set; }
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

    public List<int>? DanhSachManHinh { get; set; }

    /// <summary>
    /// Tổ tiên
    /// </summary>
    public List<DanhMucBuocDto>? Ancestors { get; set; }

    /// <summary>
    /// Hậu duệ
    /// </summary>
    public List<DanhMucBuocDto>? Descendants { get; set; }
}