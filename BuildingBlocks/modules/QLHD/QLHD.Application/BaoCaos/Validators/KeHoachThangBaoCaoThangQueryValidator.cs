using FluentValidation;
using QLHD.Application.BaoCaos.Queries;
using QLHD.Domain.Constants;

namespace QLHD.Application.BaoCaos.Validators;

public class KeHoachThangBaoCaoThangQueryValidator : AbstractValidator<KeHoachThangReportQuery> {

    public KeHoachThangBaoCaoThangQueryValidator() {
        // LoaiBaoCao validation
        RuleFor(e => e.SearchModel.LoaiBaoCao)
            .NotEmpty().WithMessage("Loại báo cáo là bắt buộc")
            .Must(type => type == LoaiBaoCaoConstants.BaoCaoThang || type == LoaiBaoCaoConstants.ChiTiet)
            .WithMessage($"Loại báo cáo phải là '{LoaiBaoCaoConstants.BaoCaoThang}' hoặc '{LoaiBaoCaoConstants.ChiTiet}'");

        // TuThang validation - MonthYear default (0,0) is invalid
        RuleFor(e => e.SearchModel.TuThang)
            .Must(tuThang => tuThang.Month >= 1 && tuThang.Month <= 12 && tuThang.Year >= 1)
            .WithMessage("Từ tháng không hợp lệ");

        // DenThang validation
        RuleFor(e => e.SearchModel.DenThang)
            .Must(denThang => denThang.Month >= 1 && denThang.Month <= 12 && denThang.Year >= 1)
            .WithMessage("Đến tháng không hợp lệ");

        // DenThang must be >= TuThang
        RuleFor(e => e.SearchModel)
            .Must(model => model.DenThang.Year >= model.TuThang.Year &&
                          (model.DenThang.Year > model.TuThang.Year || model.DenThang.Month >= model.TuThang.Month))
            .WithMessage("Đến tháng phải lớn hơn hoặc bằng từ tháng")
            .When(e => e.SearchModel.TuThang.Month >= 1 && e.SearchModel.DenThang.Month >= 1);
    }
}