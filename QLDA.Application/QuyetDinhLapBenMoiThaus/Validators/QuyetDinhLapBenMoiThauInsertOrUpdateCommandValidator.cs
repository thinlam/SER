using QLDA.Application.QuyetDinhLapBenMoiThaus.Commands;

namespace QLDA.Application.QuyetDinhLapBenMoiThaus.Validators;

public class QuyetDinhLapBenMoiThauInsertOrUpdateCommandValidator : AbstractValidator<QuyetDinhLapBenMoiThauInsertOrUpdateCommand> {
    public QuyetDinhLapBenMoiThauInsertOrUpdateCommandValidator() {
        RuleFor(e => e.Entity.So)
            .NotEmpty().WithMessage("Số quyết định không được để trống");
    }
}