namespace QLDA.Domain.Interfaces;

public interface IMayHaveParent<TKey> {
    TKey? ParentId { get; set; }
}