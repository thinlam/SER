using FluentValidation;
using QLHD.Application.KeHoachThangs.Commands;

namespace QLHD.Application.KeHoachThangs.Validators;

public class KeHoachThangInsertCommandValidator : AbstractValidator<KeHoachThangInsertCommand>
{
    public KeHoachThangInsertCommandValidator()
    {
        RuleFor(x => x.Model.TuNgay)
            .Must(BeValidMonthYear)
            .WithMessage("Từ ngày không hợp lệ");

        RuleFor(x => x.Model.DenNgay)
            .Must(BeValidMonthYear)
            .WithMessage("Đến ngày không hợp lệ");

        RuleFor(x => x)
            .Must(x => x.Model.TuNgay.ToDateOnly() <= x.Model.DenNgay.ToDateOnly())
            .WithMessage("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày");

        RuleFor(x => x.Model.GhiChu)
            .MaximumLength(1000).WithMessage("Ghi chú không được vượt quá 1000 ký tự");
    }

    private static bool BeValidMonthYear(BuildingBlocks.Domain.ValueTypes.MonthYear monthYear)
    {
        // MonthYear struct validates itself in constructor
        return true;
    }
}