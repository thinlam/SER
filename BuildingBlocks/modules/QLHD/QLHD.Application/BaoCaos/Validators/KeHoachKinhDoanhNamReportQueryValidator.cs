using FluentValidation;
using QLHD.Application.BaoCaos.Queries;

namespace QLHD.Application.BaoCaos.Validators;

/// <summary>
/// Validator for ke hoach kinh doanh nam report query
/// </summary>
public class KeHoachKinhDoanhNamReportQueryValidator : AbstractValidator<KeHoachKinhDoanhNamReportQuery>
{
    public KeHoachKinhDoanhNamReportQueryValidator()
    {
        RuleFor(x => x.SearchModel.KeHoachKinhDoanhNamId)
            .NotEmpty().WithMessage("ID kế hoạch kinh doanh năm là bắt buộc");

        RuleFor(x => x.SearchModel.LoaiBaoCao)
            .NotEmpty().WithMessage("Loại báo cáo là bắt buộc")
            .Must(type => type == LoaiBaoCaoConstants.BaoCaoTongHop || type == LoaiBaoCaoConstants.ChiTiet)
            .WithMessage($"Loại báo cáo phải là '{LoaiBaoCaoConstants.BaoCaoTongHop}' hoặc '{LoaiBaoCaoConstants.ChiTiet}'");

        // Validate month range: TuThang <= DenThang
        RuleFor(x => x.SearchModel)
            .Must(model => BeValidMonthRange(model.TuThang, model.DenThang))
            .WithMessage("Tháng bắt đầu phải nhỏ hơn hoặc bằng tháng kết thúc");
    }

    private static bool BeValidMonthRange(MonthYear tuThang, MonthYear denThang)
    {
        var tuDate = tuThang.ToDateOnly(1);
        var denDate = denThang.ToDateOnly(1);
        return tuDate <= denDate;
    }
}