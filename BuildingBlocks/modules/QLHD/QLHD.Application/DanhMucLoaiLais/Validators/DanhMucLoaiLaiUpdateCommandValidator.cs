using FluentValidation;
using QLHD.Application.DanhMucLoaiLais.Commands;
using QLHD.Domain.Entities.DanhMuc;

namespace QLHD.Application.DanhMucLoaiLais.Validators;

public class DanhMucLoaiLaiUpdateCommandValidator : AbstractValidator<DanhMucLoaiLaiUpdateCommand>
{
    public DanhMucLoaiLaiUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiLai, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(e => e.Id == id, cancellationToken);
            })
            .WithMessage("Không tìm thấy bản ghi");

        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên loại lãi là bắt buộc")
            .MaximumLength(500).WithMessage("Tên loại lãi không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.MoTa)
            .MaximumLength(2000).WithMessage("Mô tả không được vượt quá 2000 ký tự");
    }
}