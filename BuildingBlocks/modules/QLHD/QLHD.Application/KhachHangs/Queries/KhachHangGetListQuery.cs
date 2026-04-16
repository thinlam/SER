using QLHD.Application.KhachHangs.DTOs;

namespace QLHD.Application.KhachHangs.Queries;

public record KhachHangGetListQuery(KhachHangSearchModel SearchModel) : IRequest<PaginatedList<KhachHangDto>>;

public record KhachHangSearchModel : AggregateRootSearch, ISearchString;

internal class KhachHangGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<KhachHangGetListQuery, PaginatedList<KhachHangDto>>
{
    private readonly IRepository<KhachHang, Guid> _repository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();

    public async Task<PaginatedList<KhachHangDto>> Handle(KhachHangGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.Ma, e => e.Ten, e => e.TaxCode, e => e.ContactPerson)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new KhachHangDto
            {
                Id = e.Id,
                Ma = e.Ma,
                Ten = e.Ten,
                IsPersonal = e.IsPersonal,
                DateOfBirth = e.DateOfBirth,
                TaxCode = e.TaxCode,
                ContactPerson = e.ContactPerson,
                Address = e.Address,
                Phone = e.Phone,
                Email = e.Email,
                DistrictId = e.DistrictId,
                DistrictName = e.DistrictName,
                CityId = e.CityId,
                CityName = e.CityName,
                CountryId = e.CountryId,
                CountryName = e.CountryName,
                IsDefault = e.IsDefault,
                Used = e.Used,
                DonViId = e.DonViId,
                DoanhNghiepId = e.DoanhNghiepId
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}