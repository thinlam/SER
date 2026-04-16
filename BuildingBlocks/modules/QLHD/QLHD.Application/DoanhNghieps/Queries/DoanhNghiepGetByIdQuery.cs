using QLHD.Application.DoanhNghieps.DTOs;

namespace QLHD.Application.DoanhNghieps.Queries;

public record DoanhNghiepGetByIdQuery(Guid Id) : IRequest<DoanhNghiepDto>;

internal class DoanhNghiepGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<DoanhNghiepGetByIdQuery, DoanhNghiepDto>
{
    private readonly IRepository<DoanhNghiep, Guid> _repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();

    public async Task<DoanhNghiepDto> Handle(DoanhNghiepGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .Where(e => e.Id == request.Id)
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
            })
            .FirstOrDefaultAsync(cancellationToken);

        ManagedException.ThrowIfNull(entity, "Doanh nghiệp không tồn tại");
        return entity!;
    }
}