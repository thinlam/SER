using SequentialGuid;

namespace BuildingBlocks.CrossCutting.ExtensionMethods;

public static class GuidExtensions
{
    /// <summary>
    /// Guid nhưng có sắp xếp thứ tự tăng dần
    /// </summary>
    public static Guid GetId(this Guid? id) => id ?? SequentialGuidGenerator.Instance.NewGuid();
    public static Guid GetSequentialGuidId() => SequentialGuidGenerator.Instance.NewGuid();
}