using FluentValidation;
using QLHD.Application.CongViecs.Commands;

namespace QLHD.Application.CongViecs.Validators;

public class CongViecUpdateCommandValidator : AbstractValidator<CongViecUpdateCommand>
{
    public CongViecUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<CongViec, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(e => e.Id == id, cancellationToken);
            })
            .WithMessage("Không tìm thấy bản ghi");

        RuleFor(x => x.Model.UserPortalId)
            .NotEmpty().WithMessage("Người dùng là bắt buộc");

        RuleFor(x => x.Model.DonViId)
            .NotEmpty().WithMessage("Đơn vị là bắt buộc");

        RuleFor(x => x.Model.TrangThaiId)
            .NotEmpty().WithMessage("Trạng thái là bắt buộc")
            .MustAsync(async (trangThaiId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(t => t.Id == trangThaiId, cancellationToken);
            })
            .WithMessage("Trạng thái không tồn tại");

        RuleFor(x => x.Model.KeHoachCongViec)
            .MaximumLength(2000).WithMessage("Kế hoạch công việc không được vượt quá 2000 ký tự");

        RuleFor(x => x.Model.ThucTe)
            .MaximumLength(2000).WithMessage("Thực tế không được vượt quá 2000 ký tự");
    }
}