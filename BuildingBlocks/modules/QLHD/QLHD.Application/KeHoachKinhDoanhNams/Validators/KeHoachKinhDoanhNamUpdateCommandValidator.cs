using FluentValidation;
using QLHD.Application.KeHoachKinhDoanhNams.Commands;

namespace QLHD.Application.KeHoachKinhDoanhNams.Validators;

public class KeHoachKinhDoanhNamUpdateCommandValidator : AbstractValidator<KeHoachKinhDoanhNamUpdateCommand> {
    public KeHoachKinhDoanhNamUpdateCommandValidator(IServiceProvider serviceProvider) {
        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) => {
                var repository = serviceProvider.GetRequiredService<IRepository<KeHoachKinhDoanhNam, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(e => e.Id == id, cancellationToken);
            })
            .WithMessage("Không tìm thấy bản ghi");

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