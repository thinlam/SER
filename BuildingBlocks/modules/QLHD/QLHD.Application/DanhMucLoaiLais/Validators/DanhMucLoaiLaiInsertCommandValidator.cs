using FluentValidation;
using QLHD.Application.DanhMucLoaiLais.Commands;

namespace QLHD.Application.DanhMucLoaiLais.Validators;

public class DanhMucLoaiLaiInsertCommandValidator : AbstractValidator<DanhMucLoaiLaiInsertCommand>
{
    public DanhMucLoaiLaiInsertCommandValidator()
    {
        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên loại lãi là bắt buộc")
            .MaximumLength(500).WithMessage("Tên loại lãi không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.MoTa)
            .MaximumLength(2000).WithMessage("Mô tả không được vượt quá 2000 ký tự");
    }
}