using FluentValidation;
using QLHD.Application.PhuLucHopDongs.Commands;

namespace QLHD.Application.PhuLucHopDongs.Validators;

/// <summary>
/// Validator cho command thêm mới phụ lục hợp đồng
/// </summary>
public class PhuLucHopDongInsertCommandValidator : AbstractValidator<PhuLucHopDongInsertCommand>
{
    public PhuLucHopDongInsertCommandValidator(IServiceProvider serviceProvider)
    {
        // HopDongId is required
        RuleFor(x => x.Model.HopDongId)
            .NotEmpty().WithMessage("Hợp đồng là bắt buộc")
            .MustAsync(async (hopDongId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(h => h.Id == hopDongId, cancellationToken);
            }).WithMessage("Hợp đồng không tồn tại");

        // SoPhuLuc is required and unique per HopDong
        RuleFor(x => x.Model.SoPhuLuc)
            .NotEmpty().WithMessage("Số phụ lục là bắt buộc")
            .MaximumLength(100).WithMessage("Số phụ lục không được vượt quá 100 ký tự")
            .MustAsync(async (command, soPhuLuc, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<PhuLucHopDong, Guid>>();
                return !await repository.GetQueryableSet()
                    .AnyAsync(p => p.HopDongId == command.Model.HopDongId && p.SoPhuLuc == soPhuLuc, cancellationToken);
            }).WithMessage("Số phụ lục đã tồn tại trong hợp đồng này");

        // NgayKy is required
        RuleFor(x => x.Model.NgayKy)
            .NotEmpty().WithMessage("Ngày ký là bắt buộc");

        // NoiDungPhuLuc optional
        RuleFor(x => x.Model.NoiDungPhuLuc)
            .MaximumLength(4000).WithMessage("Nội dung phụ lục không được vượt quá 4000 ký tự");
    }
}