using QLDA.Application.Common.Interfaces;
using QLDA.Application.TepDinhKems.DTOs;
using QLDA.Domain.Interfaces;

namespace QLDA.Application.BaoCaoBaoHanhSanPhams.DTOs;

public class BaoCaoBaoHanhSanPhamInsertDto : IMayHaveTepDinhKemDto, ITienDo {
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid DuAnId { get; set; }
    public int? BuocId { get; set; }
    public DateTimeOffset? Ngay { get; set; }
    public string? NoiDung { get; set; }
    public long? NguoiBaoCaoId { get; set; }
    public long? LanhDaoPhuTrachId { get; set; }
    public List<TepDinhKemDto>? DanhSachTepDinhKem { get; set; }
}