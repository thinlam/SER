namespace QLDA.Application.QuyetDinhDuyetDuAnNguonVons.DTOs;

public class QuyetDinhDuyetDuAnNguonVonDto {
    [DefaultValue(null)] public Guid? Id { get; set; }
    public Guid QuyetDinhDuyetDuAnId { get; set; }
    public int NguonVonId { get; set; }
    public long GiaTri { get; set; }
}