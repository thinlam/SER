using QLDA.Domain.Interfaces;

namespace QLDA.Domain.Entities;
 
public class NghiemThuPhuLucHopDong : IJunctionEntity, IAggregateRoot
{
    public Guid NghiemThuId { get; set; }
    public Guid PhuLucHopDongId { get; set; }

    #region Navigation Properties

    public NghiemThu? NghiemThu { get; set; }
    public PhuLucHopDong? PhuLucHopDong { get; set; }

    #endregion
}