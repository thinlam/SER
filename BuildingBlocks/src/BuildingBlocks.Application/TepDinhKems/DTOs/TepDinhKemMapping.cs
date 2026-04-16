
namespace BuildingBlocks.Application.TepDinhKems.DTOs;

public static class TepDinhKemMapping
{
    public static List<TepDinhKemDto> ToListDto(this IEnumerable<TepDinhKem> danhSachTepDinhKem)
        => [.. danhSachTepDinhKem.Select(o => o.ToDto())];

    public static TepDinhKemDto ToDto(this TepDinhKem entity)
        => new()
        {
            Id = entity.Id,
            ParentId = entity.ParentId,
            GroupId = entity.GroupId,
            GroupType = entity.GroupType,
            Path = entity.Path,
            Size = entity.Size,
            Type = entity.Type,
            FileName = entity.FileName,
            OriginalName = entity.OriginalName,
        };
    private static TepDinhKem ToEntity(this TepDinhKemInsertModel model, string groupId, string? groupType = null)
    => new()
    {
        Id = GuidExtensions.GetSequentialGuidId(),
        ParentId = model.ParentId,
        GroupId = groupId,
        GroupType = groupType ?? string.Empty,
        Type = model.Type,
        FileName = model.FileName,
        OriginalName = model.OriginalName,
        Path = model.Path,
        Size = model.Size,
    };
    private static TepDinhKem ToEntity(this TepDinhKemInsertOrUpdateModel model, string groupId, string? groupType = null)
    => new()
    {
        Id = model.Id.GetId(),
        ParentId = model.ParentId,
        GroupId = groupId,
        GroupType = groupType ?? string.Empty,
        Type = model.Type,
        FileName = model.FileName,
        OriginalName = model.OriginalName,
        Path = model.Path,
        Size = model.Size,
    };

    /// <summary>
    /// Nếu groupId là một chuỗi số (number) thì bắt buộc phải truyền groupType.
    /// </summary>
    /// <param name="data">Danh sách các model đầu vào.</param>
    /// <param name="groupId">ID của nhóm, có thể là số hoặc chuỗi.</param>
    /// <param name="groupType">Loại nhóm (tên bảng), bắt buộc nếu groupId là số.</param>
    /// <returns>Một IEnumerable chứa các entity TepDinhKem.</returns>
    /// <exception cref="ArgumentException">Ném ra khi groupId là số nhưng groupType không được cung cấp (null hoặc empty).</exception>
    public static IEnumerable<TepDinhKem> ToEntities(
        this List<TepDinhKemInsertModel> data,
        string groupId,
        string? groupType = null)
    {
        // Kiểm tra xem groupId có phải là một chuỗi số hay không.
        // Nếu đúng, và groupType vẫn là null/empty,
        if (long.TryParse(groupId, out _) && string.IsNullOrEmpty(groupType))
        {
            throw new ArgumentException("Bắt buộc phải truyền giá trị cho 'groupType' khi 'groupId' là một số.", nameof(groupType));
        }

        return data.Select(m => ToEntity(m, groupId, groupType));
    }

    /// <summary>
    /// Nếu groupId là một chuỗi số (number) thì bắt buộc phải truyền groupType.
    /// </summary>
    /// <param name="data">Danh sách các model đầu vào.</param>
    /// <param name="groupId">ID của nhóm, có thể là số hoặc chuỗi.</param>
    /// <param name="groupType">Loại nhóm (tên bảng), bắt buộc nếu groupId là số.</param>
    /// <returns>Một IEnumerable chứa các entity TepDinhKem.</returns>
    /// <exception cref="ArgumentException">Ném ra khi groupId là số nhưng groupType không được cung cấp (null hoặc empty).</exception>
    public static IEnumerable<TepDinhKem> ToEntities(
        this List<TepDinhKemInsertOrUpdateModel> data,
        string groupId,
        string? groupType = null)
    {
        // Kiểm tra xem groupId có phải là một chuỗi số hay không.
        // Nếu đúng, và groupType vẫn là null/empty,
        if (long.TryParse(groupId, out _) && string.IsNullOrEmpty(groupType))
        {
            throw new ArgumentException("Bắt buộc phải truyền giá trị cho 'groupType' khi 'groupId' là một số.", nameof(groupType));
        }

        return data.Select(m => ToEntity(m, groupId, groupType));
    }
}
