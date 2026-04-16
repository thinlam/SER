using FluentValidation;
using QLHD.Application.KhachHangs.Commands;

namespace QLHD.Application.KhachHangs.Validators;

public class KhachHangUpdateCommandValidator : AbstractValidator<KhachHangUpdateCommand>
{
    public KhachHangUpdateCommandValidator()
    {
        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên khách hàng là bắt buộc")
            .MaximumLength(500).WithMessage("Tên khách hàng không được vượt quá 500 ký tự");
    }
}