using FluentValidation;
using QLHD.Application.KeHoachKinhDoanhNams.Commands;
using QLHD.Application.KeHoachKinhDoanhNams.DTOs;

namespace QLHD.Application.KeHoachKinhDoanhNams.Validators;

public class KeHoachKinhDoanhNamInsertCommandValidator : AbstractValidator<KeHoachKinhDoanhNamInsertCommand> {
    public KeHoachKinhDoanhNamInsertCommandValidator() {
        RuleFor(x => x.Model.BatDau)
            .NotEmpty().WithMessage("Ngày bắt đầu là bắt buộc");

        RuleFor(x => x.Model.GhiChu)
            .MaximumLength(1000).WithMessage("Ghi chú không được vượt quá 1000 ký tự");

        // Child collection validation
        RuleForEach(x => x.Model.BoPhans)
            .SetValidator(new KeHoachKinhDoanhNam_BoPhanInsertModelValidator());

        RuleForEach(x => x.Model.CaNhans)
            .SetValidator(new KeHoachKinhDoanhNam_CaNhanInsertModelValidator());
    }
}

public class KeHoachKinhDoanhNam_BoPhanInsertModelValidator : AbstractValidator<KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel> {
    public KeHoachKinhDoanhNam_BoPhanInsertModelValidator() {
        RuleFor(x => x.DonViId)
            .NotEmpty().WithMessage("Đơn vị là bắt buộc");
    }
}

public class KeHoachKinhDoanhNam_CaNhanInsertModelValidator : AbstractValidator<KeHoachKinhDoanhNam_CaNhanInsertOrUpdateModel> {
    public KeHoachKinhDoanhNam_CaNhanInsertModelValidator() {
        RuleFor(x => x.UserPortalId)
            .NotEmpty().WithMessage("Người dùng là bắt buộc");
    }
}