using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;

namespace QLDA.Application.BaoCaoBanGiaoSanPhams.DTOs;

public class BaoCaoBanGiaoSanPhamUpdateDto : IMayHaveTepDinhKemDto {
     public Guid Id { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    public long? NguoiBaoCaoId { get; set; }
    public Guid? DonViBanGiaoId { get; set; }
    public long? DonViNhanBanGiaoId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}