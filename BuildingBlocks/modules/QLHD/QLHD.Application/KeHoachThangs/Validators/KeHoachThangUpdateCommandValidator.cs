using FluentValidation;
using QLHD.Application.KeHoachThangs.Commands;
using QLHD.Domain.Entities;

namespace QLHD.Application.KeHoachThangs.Validators;

public class KeHoachThangUpdateCommandValidator : AbstractValidator<KeHoachThangUpdateCommand>
{
    public KeHoachThangUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<KeHoachThang, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(e => e.Id == id, cancellationToken);
            })
            .WithMessage("Không tìm thấy bản ghi");

        RuleFor(x => x)
            .Must(x => x.Model.TuNgay.ToDateOnly() <= x.Model.DenNgay.ToDateOnly())
            .WithMessage("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày");

        RuleFor(x => x.Model.GhiChu)
            .MaximumLength(1000).WithMessage("Ghi chú không được vượt quá 1000 ký tự");
    }
}