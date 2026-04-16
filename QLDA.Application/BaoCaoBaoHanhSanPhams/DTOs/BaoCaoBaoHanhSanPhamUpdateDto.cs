using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.BaoCaoBaoHanhSanPhams.DTOs;

public class BaoCaoBaoHanhSanPhamUpdateDto : IMayHaveTepDinhKemDto {
    public Guid Id { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    public long? NguoiBaoCaoId { get; set; }
    public long? LanhDaoPhuTrachId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}