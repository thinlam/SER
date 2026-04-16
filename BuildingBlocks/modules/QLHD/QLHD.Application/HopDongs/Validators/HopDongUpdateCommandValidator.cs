using FluentValidation;
using QLHD.Application.HopDongs.Commands;

namespace QLHD.Application.HopDongs.Validators;

public class HopDongUpdateCommandValidator : AbstractValidator<HopDongUpdateCommand>
{
    public HopDongUpdateCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Model.Ten)
            .NotEmpty().WithMessage("Tên hợp đồng là bắt buộc")
            .MaximumLength(500).WithMessage("Tên hợp đồng không được vượt quá 500 ký tự");

        RuleFor(x => x.Model.SoHopDong)
            .NotEmpty().WithMessage("Số hợp đồng là bắt buộc")
            .MaximumLength(50).WithMessage("Số hợp đồng không được vượt quá 50 ký tự")
            .MustAsync(async (command, soHopDong, cancellationToken) =>
            {
                if (string.IsNullOrEmpty(soHopDong)) return true;

                var repository = serviceProvider.GetRequiredService<IRepository<HopDong, Guid>>();
                return !await repository.GetQueryableSet()
                    .AnyAsync(h => h.SoHopDong == soHopDong && h.Id != command.Id, cancellationToken);
            })
            .WithMessage("Số hợp đồng đã tồn tại. Vui lòng sử dụng số hợp đồng khác.");

        RuleFor(x => x.Model.KhachHangId)
            .NotEmpty().WithMessage("Khách hàng là bắt buộc");

        RuleFor(x => x.Model.LoaiHopDongId)
            .NotEmpty().WithMessage("Loại hợp đồng là bắt buộc");

        RuleFor(x => x.Model.NgayKy)
            .NotEmpty().WithMessage("Ngày ký là bắt buộc");

        RuleFor(x => x.Model.SoNgay)
            .GreaterThan(0).WithMessage("Số ngày phải lớn hơn 0");

        RuleFor(x => x.Model.NgayNghiemThu)
            .NotEmpty().WithMessage("Ngày nghiệm thu là bắt buộc");

        RuleFor(x => x.Model.GiaTri)
            .GreaterThanOrEqualTo(0).WithMessage("Giá trị phải lớn hơn hoặc bằng 0");

        RuleFor(x => x.Model.GiaTriBaoLanh)
            .GreaterThanOrEqualTo(0).WithMessage("Giá trị bảo lãnh phải lớn hơn hoặc bằng 0");

        // Validate TrangThaiHopDongId belongs to HopDong type
        RuleFor(x => x.Model.TrangThaiHopDongId)
            .NotEmpty().WithMessage("Trạng thái hợp đồng là bắt buộc")
            .MustAsync(async (trangThaiId, cancellationToken) =>
            {
                var repository = serviceProvider.GetRequiredService<IRepository<DanhMucTrangThai, int>>();
                return await repository.GetQueryableSet()
                    .AnyAsync(t => t.Id == trangThaiId && t.MaLoaiTrangThai == LoaiTrangThaiConstants.HopDong, cancellationToken);
            })
            .WithMessage($"Trạng thái phải thuộc loại hợp đồng ({LoaiTrangThaiConstants.HopDong})");

        RuleFor(x => x.Model.NguoiPhuTrachChinhId)
            .NotEmpty().WithMessage("Người phụ trách chính là bắt buộc");
            
        RuleFor(x => x.Model.PhongBanPhuTrachChinhId)
            .NotEmpty().WithMessage("Phòng ban phụ trách chính là bắt buộc");
    }
}