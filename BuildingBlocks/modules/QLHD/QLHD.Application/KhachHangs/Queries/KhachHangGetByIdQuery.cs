using QLHD.Application.KhachHangs.DTOs;

namespace QLHD.Application.KhachHangs.Queries;

public record KhachHangGetByIdQuery(Guid Id) : IRequest<KhachHangDto>;

internal class KhachHangGetByIdQueryHandler(IServiceProvider serviceProvider) : IRequestHandler<KhachHangGetByIdQuery, KhachHangDto>
{
    private readonly IRepository<KhachHang, Guid> _repository = serviceProvider.GetRequiredService<IRepository<KhachHang, Guid>>();

    public async Task<KhachHangDto> Handle(KhachHangGetByIdQuery request, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetQueryableSet()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        ManagedException.ThrowIfNull(entity, "Không tìm thấy khách hàng");

        return new KhachHangDto
        {
            Id = entity.Id,
            Ma = entity.Ma,
            Ten = entity.Ten,
            IsPersonal = entity.IsPersonal,
            DateOfBirth = entity.DateOfBirth,
            TaxCode = entity.TaxCode,
            ContactPerson = entity.ContactPerson,
            Address = entity.Address,
            Phone = entity.Phone,
            Email = entity.Email,
            DistrictId = entity.DistrictId,
            DistrictName = entity.DistrictName,
            CityId = entity.CityId,
            CityName = entity.CityName,
            CountryId = entity.CountryId,
            CountryName = entity.CountryName,
            IsDefault = entity.IsDefault,
            Used = entity.Used,
            DonViId = entity.DonViId,
            DoanhNghiepId = entity.DoanhNghiepId
        };
    }
}