using FluentValidation;
using QLHD.Application.BaoCaoTienDos.Commands;

namespace QLHD.Application.BaoCaoTienDos.Validators;

public class BaoCaoTienDoInsertCommandValidator : AbstractValidator<BaoCaoTienDoInsertCommand>
{
    public BaoCaoTienDoInsertCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.TienDoId)
            .NotEmpty().WithMessage("Tiến độ là bắt buộc")
            .MustAsync(async (tienDoId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(t => t.Id == tienDoId, cancellationToken);
            }).WithMessage("Không tìm thấy tiến độ");

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

        // Validate NguoiBaoCaoId exists in USER_MASTER
        RuleFor(x => x.Model.NguoiBaoCaoId)
            .MustAsync(async (nguoiBaoCaoId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(u => u.Id == nguoiBaoCaoId, cancellationToken);
            }).WithMessage("Không tìm thấy người báo cáo");

        // Approval flow validation
        When(x => x.Model.CanDuyet, () =>
        {
            RuleFor(x => x.Model.NguoiDuyetId)
                .NotNull().WithMessage("Phải chọn người duyệt khi bật yêu cầu duyệt")
                .MustAsync(async (nguoiDuyetId, cancellationToken) =>
                {
                    var repository = serviceProvider.GetRequiredService<IRepository<UserMaster, long>>();
                    return await repository.GetQueryableSet()
                        .AnyAsync(u => u.Id == nguoiDuyetId, cancellationToken);
                }).WithMessage("Không tìm thấy người duyệt");
        });
    }
}