namespace QLDA.Domain.Entities.ViMaster;

public class DuongPhuongQuan : IHasKey<long>, IAggregateRoot {
    public long Id { get; set; }

    public long? DuongId { get; set; }

    public long? PhuongXaId { get; set; }

    public long? QuanHuyenId { get; set; }
}