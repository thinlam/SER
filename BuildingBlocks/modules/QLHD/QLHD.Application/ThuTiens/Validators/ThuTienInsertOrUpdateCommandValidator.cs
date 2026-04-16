using FluentValidation;
using QLHD.Application.ThuTiens.Commands;
using QLHD.Domain.Entities;

namespace QLHD.Application.ThuTiens.Validators;

/// <summary>
/// Validator cho command thêm mới/cập nhật thu tiền (unified routing)
/// </summary>
public class ThuTienInsertOrUpdateCommandValidator : AbstractValidator<ThuTienInsertOrUpdateCommand>
{
    public ThuTienInsertOrUpdateCommandValidator(IServiceProvider serviceProvider)
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

        // KeHoachId - if provided, must exist in correct table based on routing
        When(x => x.Model.Id.HasValue && x.Model.Id != Guid.Empty, () =>
        {
            RuleFor(x => x.Model)
                .MustAsync(async (model, cancellationToken) =>
                {
                    var hopDongRepo = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
                    var hopDong = await hopDongRepo.GetQueryableSet()
                        .FirstOrDefaultAsync(h => h.Id == model.HopDongId, cancellationToken);

                    if (hopDong == null) return false;

                    if (hopDong.DuAnId.HasValue)
                    {
                        // Route to DuAn_ThuTien
                        var duAnThuTienRepo = serviceProvider.GetRequiredService<IRepository<DuAn_ThuTien, Guid>>();
                        return await duAnThuTienRepo.GetQueryableSet()
                            .AnyAsync(e => e.Id == model.Id!.Value && e.DuAnId == hopDong.DuAnId.Value, cancellationToken);
                    }
                    else
                    {
                        // Route to HopDong_ThuTien
                        var hopDongThuTienRepo = serviceProvider.GetRequiredService<IRepository<HopDong_ThuTien, Guid>>();
                        return await hopDongThuTienRepo.GetQueryableSet()
                            .AnyAsync(e => e.Id == model.Id!.Value && e.HopDongId == model.HopDongId, cancellationToken);
                    }
                }).WithMessage("Kế hoạch thu tiền không tồn tại hoặc không thuộc hợp đồng này");
        });

        // KeHoach fields
        RuleFor(x => x.Model.LoaiThanhToanId)
            .NotEmpty().WithMessage("Loại thanh toán là bắt buộc");

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

        RuleFor(x => x.Model.SoHoaDon)
            .MaximumLength(50).WithMessage("Số hóa đơn không được vượt quá 50 ký tự");

        RuleFor(x => x.Model.KyHieuHoaDon)
            .MaximumLength(50).WithMessage("Ký hiệu hóa đơn không được vượt quá 50 ký tự");
    }
}