using QLHD.Application.DoanhNghieps.DTOs;

namespace QLHD.Application.DoanhNghieps.Queries;

public record DoanhNghiepGetListQuery(DoanhNghiepSearchModel SearchModel) : IRequest<PaginatedList<DoanhNghiepDto>>;

public record DoanhNghiepSearchModel : AggregateRootSearch, ISearchString;

internal class DoanhNghiepGetListQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DoanhNghiepGetListQuery, PaginatedList<DoanhNghiepDto>>
{
    private readonly IRepository<DoanhNghiep, Guid> _repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();

    public async Task<PaginatedList<DoanhNghiepDto>> Handle(DoanhNghiepGetListQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.SearchModel;

        var query = _repository.GetQueryableSet()
            .WhereSearchString(model, e => e.TaxCode, e => e.Ten, e => e.TenTiengAnh, e => e.Owner)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new DoanhNghiepDto
            {
                Id = e.Id,
                TaxCode = e.TaxCode,
                Ten = e.Ten,
                TenTiengAnh = e.TenTiengAnh,
                TaxAuthorityId = e.TaxAuthorityId,
                Phone = e.Phone,
                Fax = e.Fax,
                AddressVN = e.AddressVN,
                AddressEN = e.AddressEN,
                CountryId = e.CountryId,
                CityId = e.CityId,
                DistrictId = e.DistrictId,
                Email = e.Email,
                ContactPerson = e.ContactPerson,
                Owner = e.Owner,
                BankAccount = e.BankAccount,
                AccountHolder = e.AccountHolder,
                BankName = e.BankName,
                IsLogo = e.IsLogo,
                LogoFileName = e.LogoFileName,
                MoTa = e.MoTa,
                IsActive = e.IsActive,
                AuthorizeVolume = e.AuthorizeVolume,
                AuthorizeLic = e.AuthorizeLic,
                AuthorizeDate = e.AuthorizeDate,
                Version = e.Version
            });

        return await query.PaginatedListAsync(model.Skip(), model.Take(), cancellationToken: cancellationToken);
    }
}