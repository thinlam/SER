using FluentValidation;
using QLHD.Application.KhachHangs.Commands;

namespace QLHD.Application.KhachHangs.Validators;

public class KhachHangInsertCommandValidator : AbstractValidator<KhachHangInsertCommand>
{
    public KhachHangInsertCommandValidator()
    {
        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên khách hàng là bắt buộc")
            .MaximumLength(500).WithMessage("Tên khách hàng không được vượt quá 500 ký tự");
    }
}