using FluentValidation;
using QLHD.Application.DanhMucNguoiTheoDois.Commands;

namespace QLHD.Application.DanhMucNguoiTheoDois.Validators;

public class DanhMucNguoiTheoDoiUpdateCommandValidator : AbstractValidator<DanhMucNguoiTheoDoiUpdateCommand>
{
    public DanhMucNguoiTheoDoiUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(e => e.Id == id, cancellationToken);
            })
            .WithMessage("Không tìm thấy bản ghi");

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

        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucNguoiTheoDoi, int>>();
                var model = command.Model;
                var scopeId = model.PhongBanId ?? model.DonViId;
                return !await repository.GetQueryableSet()
                    .AnyAsync(e =>
                        e.UserPortalId == model.UserPortalId &&
                        (e.PhongBanId ?? e.DonViId) == scopeId &&
                        e.Id != command.Id,
                        cancellationToken);
            })
            .WithMessage("Người dùng đã được phân công trong phạm vi này");
    }
}