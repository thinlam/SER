using FluentValidation;
using QLHD.Application.DoanhNghieps.Commands;

namespace QLHD.Application.DoanhNghieps.Validators;

public class DoanhNghiepUpdateCommandValidator : AbstractValidator<DoanhNghiepUpdateCommand>
{
    public DoanhNghiepUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(e => e.Id == id, cancellationToken);
            })
            .WithMessage("Doanh nghiệp không tồn tại");

        RuleFor(x => x.Model.TaxCode)
            .MaximumLength(50).WithMessage("Mã số thuế không được vượt quá 50 ký tự")
            .MustAsync(async (command, taxCode, cancellationToken) =>
            {
                if (string.IsNullOrEmpty(taxCode)) return true;

                var repository = serviceProvider.GetRequiredService<IRepository<DoanhNghiep, Guid>>();
                return !await repository.GetQueryableSet()
                    .AnyAsync(e => e.TaxCode == taxCode && e.Id != command.Model.Id, cancellationToken);
            })
            .WithMessage(x => $"Mã số thuế '{x.Model.TaxCode}' đã tồn tại");

        RuleFor(x => x.Model.Ten)
            .MaximumLength(500).WithMessage("Tên không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.Phone)
            .MaximumLength(50).WithMessage("Số điện thoại không được vượt quá 50 ký tự");

        RuleFor(x => x.Model.Email)
            .MaximumLength(200).WithMessage("Email không được vượt quá 200 ký tự");
    }
}