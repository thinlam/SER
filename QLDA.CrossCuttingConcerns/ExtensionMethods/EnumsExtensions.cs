using System.ComponentModel;

namespace SharedKernel.CrossCuttingConcerns.ExtensionMethods;

public static class EnumsExtensions {
    public static string GetDescription(this Enum enumValue) {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        if (fieldInfo == null)
            return enumValue.ToString();
        var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
        return attribute is DescriptionAttribute descriptionAttribute
            ? descriptionAttribute.Description
            : enumValue.ToString();
    }


    public class EnumDto {
        public object Id { get; set; } = 0;
        public int Index { get; set; } = 0;
        public string RawName { get; set; } = null!;
        public string Ten { get; set; } = null!;
    }

    public static List<EnumDto> EnumAll<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>().Select((v, index) =>
        new EnumDto {
            Id = v,
            Index = index,
            RawName = v.ToString(),
            Ten = v.GetDescription(),
        }).ToList();

    public static IEnumerable<EnumDto> ViewEnumAll<T1, T2>()
        where T1 : Enum
        where T2 : Enum {
        var destinationList = EnumAll<T1>();
        var originList = EnumAll<T2>();

        foreach (var destinationItem in destinationList) {
            var matchingOriginItem = originList.FirstOrDefault(item => item.RawName == destinationItem.RawName);
            if (matchingOriginItem != null)
                destinationItem.Id = matchingOriginItem.Id;
        }

        var firstItem =  destinationList.FirstOrDefault(i => !originList.Select(ii => ii.RawName).Contains(i.RawName));
        if (firstItem != null) {
            firstItem.Id = -1;
            yield return firstItem;
        }

        foreach (var item in destinationList.Where(i => originList.Select(ii => ii.RawName).Contains(i.RawName)).OrderBy(i=>i.Id))
            yield return item;
    }
}