using SequentialGuid;

namespace SharedKernel.CrossCuttingConcerns.ExtensionMethods;

public static class GuidExtensions {
    public static Guid GetSequentialGuidId()
        => SequentialGuidGenerator.Instance.NewGuid();
    public static Guid GetId(this Guid? id) => id ?? SequentialGuidGenerator.Instance.NewGuid();

}