using FluentValidation;
using QLHD.Application.KeHoachThangs.Commands;

namespace QLHD.Application.KeHoachThangs.Validators;

public class KeHoachThangChotCommandValidator : AbstractValidator<KeHoachThangChotCommand>
{
    public KeHoachThangChotCommandValidator()
    {
        RuleFor(x => x.KeHoachThangId)
            .GreaterThan(0)
            .WithMessage("ID kế hoạch tháng không hợp lệ");
    }
}