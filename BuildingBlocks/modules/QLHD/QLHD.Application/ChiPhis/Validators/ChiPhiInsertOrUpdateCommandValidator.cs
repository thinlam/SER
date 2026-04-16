using FluentValidation;
using QLHD.Application.ChiPhis.Commands;

namespace QLHD.Application.ChiPhis.Validators;

/// <summary>
/// Validator cho command thêm mới/cập nhật chi phí
/// </summary>
public class ChiPhiInsertOrUpdateCommandValidator : AbstractValidator<ChiPhiInsertOrUpdateCommand>
{
    public ChiPhiInsertOrUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        // HopDongId is required
        RuleFor(x => x.Model.HopDongId)
            .NotEmpty().WithMessage("Hợp đồng là bắt buộc")
            .MustAsync(async (hopDongId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
                var hopDong = await repository.GetQueryableSet()
                    .FirstOrDefaultAsync(h => h.Id == hopDongId, cancellationToken);
                return hopDong != null;
            }).WithMessage("Hợp đồng không tồn tại");

        // Id - if provided, must exist in HopDong_ChiPhi
        When(x => x.Model.Id.HasValue && x.Model.Id != Guid.Empty, () =>
        {
            RuleFor(x => x.Model)
                .MustAsync(async (model, cancellationToken) =>
                {
                    var chiPhiRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ChiPhi, Guid>>();
                    return await chiPhiRepo.GetQueryableSet()
                        .AnyAsync(e => e.Id == model.Id!.Value && e.HopDongId == model.HopDongId, cancellationToken);
                }).WithMessage("Chi phí không tồn tại hoặc không thuộc hợp đồng này");
        });

        // KeHoach fields
        RuleFor(x => x.Model.LoaiChiPhiId)
            .NotEmpty().WithMessage("Loại chi phí là bắt buộc")
            .MustAsync(async (loaiChiPhiId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucLoaiChiPhi, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(l => l.Id == loaiChiPhiId, cancellationToken);
            }).WithMessage("Loại chi phí không tồn tại");

        RuleFor(x => x.Model.Nam)
            .GreaterThanOrEqualTo((short)2020).WithMessage("Năm phải từ 2020 trở lên")
            .LessThanOrEqualTo((short)2100).WithMessage("Năm không được vượt quá 2100");

        RuleFor(x => x.Model.LanChi)
            .GreaterThan((byte)0).WithMessage("Lần chi phải lớn hơn 0");

        RuleFor(x => x.Model.PhanTramKeHoach)
            .GreaterThanOrEqualTo(0).WithMessage("Phần trăm phải lớn hơn hoặc bằng 0")
            .LessThanOrEqualTo(100).WithMessage("Phần trăm không được vượt quá 100");

        RuleFor(x => x.Model.GiaTriKeHoach)
            .GreaterThanOrEqualTo(0).WithMessage("Giá trị kế hoạch phải lớn hơn hoặc bằng 0");

        RuleFor(x => x.Model.GhiChuKeHoach)
            .MaximumLength(2000).WithMessage("Ghi chú không được vượt quá 2000 ký tự");

        // ThucTe is optional, but if provided, validate
        When(x => x.Model.GiaTriThucTe.HasValue, () =>
        {
            RuleFor(x => x.Model.GiaTriThucTe!.Value)
                .GreaterThanOrEqualTo(0).WithMessage("Giá trị thực tế phải lớn hơn hoặc bằng 0");
        });

        RuleFor(x => x.Model.GhiChuThucTe)
            .MaximumLength(2000).WithMessage("Ghi chú thực tế không được vượt quá 2000 ký tự");
    }
}