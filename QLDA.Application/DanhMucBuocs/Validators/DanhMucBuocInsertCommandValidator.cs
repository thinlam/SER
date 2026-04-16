using QLDA.Application.DanhMucBuocs.Commands;

namespace QLDA.Application.DanhMucBuocs.Validators;

public class DanhMucBuocInsertCommandValidator : AbstractValidator<DanhMucBuocInsertCommand> {
    public DanhMucBuocInsertCommandValidator() {
        RuleFor(x => x.Dto.SoNgayThucHien)
            .GreaterThan(0)
            .WithMessage("Số ngày thực hiện phải lớn hơn hoặc bằng 1");
    }
}