using FluentValidation;
using QLHD.Application.KhoKhanVuongMacs.Commands;

namespace QLHD.Application.KhoKhanVuongMacs.Validators;

public class KhoKhanVuongMacInsertCommandValidator : AbstractValidator<KhoKhanVuongMacInsertCommand>
{
    public KhoKhanVuongMacInsertCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.HopDongId)
            .NotEmpty().WithMessage("Hợp đồng là bắt buộc")
            .MustAsync(async (hopDongId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(h => h.Id == hopDongId, cancellationToken);
            }).WithMessage("Không tìm thấy hợp đồng");

        RuleFor(x => x.Model.NoiDung)
            .NotEmpty().WithMessage("Nội dung là bắt buộc")
            .MaximumLength(2000).WithMessage("Nội dung không được vượt quá 2000 ký tự");

        RuleFor(x => x.Model.MucDo)
            .MaximumLength(50).WithMessage("Mức độ không được vượt quá 50 ký tự");

        RuleFor(x => x.Model.NgayPhatHien)
            .NotEmpty().WithMessage("Ngày phát hiện là bắt buộc");

        RuleFor(x => x.Model.BienPhapKhacPhuc)
            .MaximumLength(2000).WithMessage("Biện pháp khắc phục không được vượt quá 2000 ký tự");

        When(x => x.Model.TrangThaiId.HasValue, () =>
        {
            RuleFor(x => x.Model.TrangThaiId)
                .MustAsync(async (trangThaiId, cancellationToken) =>
                {
                    var repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
                    return await repository.GetQueryableSet()
                        .AnyAsync(t => t.Id == trangThaiId && t.MaLoaiTrangThai == "KKHUAN_VUONG_MAC", cancellationToken);
                }).WithMessage("Trạng thái không hợp lệ");
        });

        // Validate TienDoId belongs to same HopDong
        When(x => x.Model.TienDoId.HasValue, () =>
        {
            RuleFor(x => x)
                .MustAsync(async (command, cancellationToken) =>
                {
                    var repository = serviceProvider.GetRequiredService<IRepository<TienDo, Guid>>();
                    var tienDo = await repository.GetQueryableSet()
                        .FirstOrDefaultAsync(t => t.Id == command.Model.TienDoId!.Value, cancellationToken);
                    return tienDo == null || tienDo.HopDongId == command.Model.HopDongId;
                }).WithMessage("Tiến độ không thuộc hợp đồng này");
        });
    }
}