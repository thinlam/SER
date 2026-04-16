
using QLDA.Application.QuyetDinhLapHoiDongThamDinhs.Commands;

namespace QLDA.Application.QuyetDinhLapHoiDongThamDinhs.Validators;

public class QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommandValidator : AbstractValidator<QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommand> {
    public QuyetDinhLapHoiDongThamDinhInsertOrUpdateCommandValidator() {
        RuleFor(e => e.Entity.So)
            .NotEmpty().WithMessage("Số quyết định không được để trống");
    }
}