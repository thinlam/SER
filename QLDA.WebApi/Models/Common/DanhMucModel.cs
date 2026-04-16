namespace QLDA.WebApi.Models.Common;

public class DanhMucModel : DanhMucDto<int?>, IMustHaveId<int> {
    public int GetId() => Id ?? throw new ManagedException();
}
