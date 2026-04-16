using FluentValidation;
using QLHD.Application.PhuLucHopDongs.Commands;

namespace QLHD.Application.PhuLucHopDongs.Validators;

/// <summary>
/// Validator cho command cập nhật phụ lục hợp đồng
/// </summary>
public class PhuLucHopDongUpdateCommandValidator : AbstractValidator<PhuLucHopDongUpdateCommand>
{
    public PhuLucHopDongUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        // Id is required and must exist
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID phụ lục hợp đồng là bắt buộc")
            .MustAsync(async (id, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(p => p.Id == id, cancellationToken);
            }).WithMessage("Phụ lục hợp đồng không tồn tại");

        // SoPhuLuc is required and unique per HopDong (excluding current record)
        RuleFor(x => x.Model.SoPhuLuc)
            .NotEmpty().WithMessage("Số phụ lục là bắt buộc")
            .MaximumLength(100).WithMessage("Số phụ lục không được vượt quá 100 ký tự")
            .MustAsync(async (command, soPhuLuc, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
                var phuLuc = await repository.GetQueryableSet()
                    .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);
                if (phuLuc == null) return false;

                return !await repository.GetQueryableSet()
                    .AnyAsync(p => p.HopDongId == phuLuc.HopDongId && p.SoPhuLuc == soPhuLuc && p.Id != command.Id, cancellationToken);
            }).WithMessage("Số phụ lục đã tồn tại trong hợp đồng này");

        // NgayKy is required
        RuleFor(x => x.Model.NgayKy)
            .NotEmpty().WithMessage("Ngày ký là bắt buộc");

        // NoiDungPhuLuc optional
        RuleFor(x => x.Model.NoiDungPhuLuc)
            .MaximumLength(4000).WithMessage("Nội dung phụ lục không được vượt quá 4000 ký tự");
    }
}