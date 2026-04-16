using FluentValidation;
using QLHD.Application.DanhMucNguoiTheoDois.Commands;

namespace QLHD.Application.DanhMucNguoiTheoDois.Validators;

public class DanhMucNguoiTheoDoiInsertCommandValidator : AbstractValidator<DanhMucNguoiTheoDoiInsertCommand>
{
    public DanhMucNguoiTheoDoiInsertCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.UserPortalId)
            .NotEmpty().WithMessage("UserPortalId là bắt buộc")
            .MustAsync(async (userPortalId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(u => u.Id == userPortalId, cancellationToken);
            })
            .WithMessage("Không tìm thấy người dùng");

        RuleFor(x => x.Model.DonViId)
            .NotEmpty().WithMessage("DonViId là bắt buộc");

        RuleFor(x => x.Model)
            .MustAsync(async (model, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
                var scopeId = model.PhongBanId ?? model.DonViId;
                return !await repository.GetQueryableSet()
                    .AnyAsync(e =>
                        e.UserPortalId == model.UserPortalId &&
                        (e.PhongBanId ?? e.DonViId) == scopeId,
                        cancellationToken);
            })
            .WithMessage("Người dùng đã được phân công trong phạm vi này");
    }
}