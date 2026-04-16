using FluentValidation;
using QLHD.Application.BaoCaoTienDos.Commands;

namespace QLHD.Application.BaoCaoTienDos.Validators;

public class BaoCaoTienDoUpdateCommandValidator : AbstractValidator<BaoCaoTienDoUpdateCommand>
{
    public BaoCaoTienDoUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID là bắt buộc");

        RuleFor(x => x.Model.NgayBaoCao)
            .NotEmpty().WithMessage("Ngày báo cáo là bắt buộc");

        RuleFor(x => x.Model.PhanTramThucTe)
            .InclusiveBetween(0, 100).WithMessage("Phần trăm thực tế phải từ 0 đến 100");

        RuleFor(x => x.Model.NoiDungDaLam)
            .MaximumLength(4000).WithMessage("Nội dung đã làm không được vượt quá 4000 ký tự");

        RuleFor(x => x.Model.KeHoachTiepTheo)
            .MaximumLength(4000).WithMessage("Kế hoạch tiếp theo không được vượt quá 4000 ký tự");

        RuleFor(x => x.Model.GhiChu)
            .MaximumLength(1000).WithMessage("Ghi chú không được vượt quá 1000 ký tự");
    }
}