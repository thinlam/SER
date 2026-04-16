using QLDA.Application.QuyetDinhLapBanQLDAs.Commands;

namespace QLDA.Application.QuyetDinhLapBanQLDAs.Validators;

public class QuyetDinhLapBanQldaInsertOrUpdateCommandValidator: AbstractValidator<QuyetDinhLapBanQldaInsertOrUpdateCommand>
{
    public QuyetDinhLapBanQldaInsertOrUpdateCommandValidator()
    {
        RuleForEach(x => x.Entity.ThanhViens)
            .ChildRules(thanhVien =>
            {
                thanhVien.RuleFor(tv => tv.Ten)
                    .NotEmpty().WithMessage("Tên thành viên không được để trống");
            });
    }
}