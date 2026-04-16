using QLDA.Application.DanhMucTinhTrangThucHienLcnts.Commands;

namespace QLDA.Application.DanhMucTinhTrangThucHienLcnts.Validators;

/// <summary>
/// Validator for creating new DanhMucTinhTrangThucHienLcnt
/// </summary>
public class DanhMucTinhTrangThucHienLcntInsertCommandValidator : AbstractValidator<DanhMucTinhTrangThucHienLcntInsertCommand>
{
    public DanhMucTinhTrangThucHienLcntInsertCommandValidator()
    {
        RuleFor(x => x.Dto.Ten)
            .NotEmpty().WithMessage("Tên không được để trống")
            .MaximumLength(255).WithMessage("Tên không được vượt quá 255 ký tự");

        RuleFor(x => x.Dto.Ma)
            .MaximumLength(50).WithMessage("Mã không được vượt quá 50 ký tự");

        RuleFor(x => x.Dto.MoTa)
            .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");
    }
}

/// <summary>
/// Validator for updating existing DanhMucTinhTrangThucHienLcnt
/// </summary>
public class DanhMucTinhTrangThucHienLcntUpdateCommandValidator : AbstractValidator<DanhMucTinhTrangThucHienLcntUpdateCommand>
{
    public DanhMucTinhTrangThucHienLcntUpdateCommandValidator()
    {
        RuleFor(x => x.Dto.Id)
            .NotNull().WithMessage("Id là bắt buộc")
            .GreaterThan(0).WithMessage("Id phải lớn hơn 0");

        RuleFor(x => x.Dto.Ten)
            .NotEmpty().WithMessage("Tên không được để trống")
            .MaximumLength(255).WithMessage("Tên không được vượt quá 255 ký tự");

        RuleFor(x => x.Dto.Ma)
            .MaximumLength(50).WithMessage("Mã không được vượt quá 50 ký tự");

        RuleFor(x => x.Dto.MoTa)
            .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");
    }
}
