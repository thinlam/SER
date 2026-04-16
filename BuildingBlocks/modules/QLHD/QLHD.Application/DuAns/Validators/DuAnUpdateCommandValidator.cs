using FluentValidation;
using QLHD.Application.DuAns.Commands;

namespace QLHD.Application.DuAns.Validators;

public class DuAnUpdateCommandValidator : AbstractValidator<DuAnUpdateCommand>
{
    public DuAnUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.KhachHangId)
            .NotEmpty().WithMessage("Khách hàng là bắt buộc");

        RuleFor(x => x.Model.NgayLap)
            .NotEmpty().WithMessage("Ngày lập là bắt buộc");

        RuleFor(x => x.Model.PhongBanPhuTrachChinhId)
            .NotEmpty().WithMessage("Phòng ban phụ trách chính là bắt buộc");

        RuleFor(x => x.Model.NguoiPhuTrachChinhId)
            .NotEmpty().WithMessage("Người phụ trách chính là bắt buộc");

        RuleFor(x => x.Model.TrangThaiId)
            .NotEmpty().WithMessage("Trạng thái là bắt buộc");

        RuleFor(x => x.Model.GiaTriDuKien)
            .GreaterThanOrEqualTo(0).WithMessage("Giá trị dự kiến phải lớn hơn hoặc bằng 0");

        RuleFor(x => x.Model.GiaVon)
            .GreaterThanOrEqualTo(0).WithMessage("Giá vốn phải lớn hơn hoặc bằng 0");

        RuleFor(x => x.Model.ThanhTien)
            .GreaterThanOrEqualTo(0).WithMessage("Thành tiền phải lớn hơn hoặc bằng 0");

        // Validate TrangThaiId belongs to KHOACH type
        RuleFor(x => x.Model.TrangThaiId)
            .MustAsync(async (trangThaiId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(t => t.Id == trangThaiId && t.MaLoaiTrangThai == LoaiTrangThaiConstants.KeHoach, cancellationToken);
            })
            .WithMessage($"Trạng thái phải thuộc loại kế hoạch ({LoaiTrangThaiConstants.KeHoach})");
    }
}