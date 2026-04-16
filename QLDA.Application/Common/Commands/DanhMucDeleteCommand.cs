using QLDA.Application.Common.Enums;

namespace QLDA.Application.Common.Commands;

public record DanhMucDeleteCommand(object Entity, EDanhMuc DanhMuc, bool IsEnum = false) : IRequest {
}

internal class DanhMucDeleteCommandHandler : IRequestHandler<DanhMucDeleteCommand> {
    private readonly ICrudService<DanhMucBuoc, int> DanhMucBuoc;
    private readonly ICrudService<DanhMucBuocTrangThaiTienDo, int> DanhMucBuocTrangThaiTienDo;
    private readonly ICrudService<DanhMucChuDauTu, int> DanhMucChuDauTu;
    private readonly ICrudService<DanhMucHinhThucDauTu, int> DanhMucHinhThucDauTu;
    private readonly ICrudService<DanhMucHinhThucQuanLy, int> DanhMucHinhThucQuanLy;
    private readonly ICrudService<DanhMucLinhVuc, int> DanhMucLinhVuc;
    private readonly ICrudService<DanhMucLoaiDuAn, int> DanhMucLoaiDuAn;
    private readonly ICrudService<DanhMucLoaiDuAnTheoNam, int> DanhMucLoaiDuAnTheoNam;
    private readonly ICrudService<DanhMucNguonVon, int> DanhMucNguonVon;
    private readonly ICrudService<DanhMucNhomDuAn, int> DanhMucNhomDuAn;
    private readonly ICrudService<DanhMucQuyTrinh, int> DanhMucQuyTrinh;
    private readonly ICrudService<DanhMucTrangThaiTienDo, int> DanhMucTrangThaiTienDo;
    private readonly ICrudService<DanhMucTrangThaiDuAn, int> DanhMucTrangThaiDuAn;
    private readonly ICrudService<DanhMucLoaiVanBan, int> DanhMucLoaiVanBan;
    private readonly ICrudService<DanhMucChucVu, int> DanhMucChucVu;
    private readonly ICrudService<DanhMucManHinh, int> DanhMucManHinh;
    private readonly ICrudService<DanhMucMucDoKhoKhan, int> DanhMucMucDoKhoKhan;

    public DanhMucDeleteCommandHandler(IServiceProvider serviceProvider) {
        DanhMucBuoc = serviceProvider.GetRequiredService<ICrudService<DanhMucBuoc, int>>();
        DanhMucBuocTrangThaiTienDo =
            serviceProvider.GetRequiredService<ICrudService<DanhMucBuocTrangThaiTienDo, int>>();
        DanhMucChuDauTu = serviceProvider.GetRequiredService<ICrudService<DanhMucChuDauTu, int>>();
        DanhMucHinhThucDauTu = serviceProvider.GetRequiredService<ICrudService<DanhMucHinhThucDauTu, int>>();
        DanhMucHinhThucQuanLy = serviceProvider.GetRequiredService<ICrudService<DanhMucHinhThucQuanLy, int>>();
        DanhMucLinhVuc = serviceProvider.GetRequiredService<ICrudService<DanhMucLinhVuc, int>>();
        DanhMucLoaiDuAn = serviceProvider.GetRequiredService<ICrudService<DanhMucLoaiDuAn, int>>();
        DanhMucLoaiDuAnTheoNam = serviceProvider.GetRequiredService<ICrudService<DanhMucLoaiDuAnTheoNam, int>>();
        DanhMucNguonVon = serviceProvider.GetRequiredService<ICrudService<DanhMucNguonVon, int>>();
        DanhMucNhomDuAn = serviceProvider.GetRequiredService<ICrudService<DanhMucNhomDuAn, int>>();
        DanhMucQuyTrinh = serviceProvider.GetRequiredService<ICrudService<DanhMucQuyTrinh, int>>();
        DanhMucTrangThaiDuAn = serviceProvider.GetRequiredService<ICrudService<DanhMucTrangThaiDuAn, int>>();
        DanhMucTrangThaiTienDo = serviceProvider.GetRequiredService<ICrudService<DanhMucTrangThaiTienDo, int>>();
        DanhMucChucVu = serviceProvider.GetRequiredService<ICrudService<DanhMucChucVu, int>>();
        DanhMucLoaiVanBan = serviceProvider.GetRequiredService<ICrudService<DanhMucLoaiVanBan, int>>();
        DanhMucManHinh = serviceProvider.GetRequiredService<ICrudService<DanhMucManHinh, int>>();
        DanhMucMucDoKhoKhan = serviceProvider.GetRequiredService<ICrudService<DanhMucMucDoKhoKhan, int>>();
    }


    public async Task Handle(DanhMucDeleteCommand request, CancellationToken cancellationToken) {
        switch (request.DanhMuc) {
            case EDanhMuc.DanhMucBuoc: {
                await DanhMucBuoc.DeleteAsync((DanhMucBuoc)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucBuocTrangThaiTienDo: {
                await DanhMucBuocTrangThaiTienDo.DeleteAsync((DanhMucBuocTrangThaiTienDo)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucChuDauTu: {
                await DanhMucChuDauTu.DeleteAsync((DanhMucChuDauTu)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucHinhThucDauTu: {
                await DanhMucHinhThucDauTu.DeleteAsync((DanhMucHinhThucDauTu)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucHinhThucQuanLy: {
                await DanhMucHinhThucQuanLy.DeleteAsync((DanhMucHinhThucQuanLy)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucLinhVuc: {
                await DanhMucLinhVuc.DeleteAsync((DanhMucLinhVuc)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucLoaiDuAn: {
                await DanhMucLoaiDuAn.DeleteAsync((DanhMucLoaiDuAn)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucLoaiDuAnTheoNam: {
                await DanhMucLoaiDuAnTheoNam.DeleteAsync((DanhMucLoaiDuAnTheoNam)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucNguonVon: {
                await DanhMucNguonVon.DeleteAsync((DanhMucNguonVon)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucNhomDuAn: {
                await DanhMucNhomDuAn.DeleteAsync((DanhMucNhomDuAn)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucQuyTrinh: {
                await DanhMucQuyTrinh.DeleteAsync((DanhMucQuyTrinh)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucTrangThaiTienDo: {
                await DanhMucTrangThaiTienDo.DeleteAsync((DanhMucTrangThaiTienDo)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucTrangThaiDuAn: {
                await DanhMucTrangThaiDuAn.DeleteAsync((DanhMucTrangThaiDuAn)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucManHinh: {
                await DanhMucManHinh.DeleteAsync((DanhMucManHinh)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucChucVu: {
                await DanhMucChucVu.DeleteAsync((DanhMucChucVu)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucLoaiVanBan: {
                await DanhMucLoaiVanBan.DeleteAsync((DanhMucLoaiVanBan)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            case EDanhMuc.DanhMucMucDoKhoKhan: {
                await DanhMucMucDoKhoKhan.DeleteAsync((DanhMucMucDoKhoKhan)request.Entity,
                    cancellationToken: cancellationToken);
                break;
            }
            default:
                break;
        }
    }
}