using FluentValidation;
using QLHD.Application.TienDos.Commands;

namespace QLHD.Application.TienDos.Validators;

public class TienDoUpdateCommandValidator : AbstractValidator<TienDoUpdateCommand> {
    public TienDoUpdateCommandValidator(IServiceProvider serviceProvider) {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID là bắt buộc");

        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên tiến độ là bắt buộc")
            .MaximumLength(500).WithMessage("Tên không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.PhanTramKeHoach)
            .InclusiveBetween(0, 100).WithMessage("Phần trăm kế hoạch phải từ 0 đến 100");

        RuleFor(x => x.Model.MoTa)
            .MaximumLength(2000).WithMessage("Mô tả không được vượt quá 2000 ký tự");

        When(x => x.Model.TrangThaiId.HasValue, () => {
            RuleFor(x => x.Model.TrangThaiId)
                .MustAsync(async (trangThaiId, cancellationToken) => {
                    var repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
                    return await repository.GetQueryableSet()
                        .AnyAsync(t => t.Id == trangThaiId && t.MaLoaiTrangThai == LoaiTrangThaiConstants.TienDo, cancellationToken);
                }).WithMessage("Trạng thái không hợp lệ");
        });
    }
}