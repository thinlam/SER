using QLDA.Application.DanhMucQuyTrinhs.DTOs;

namespace QLDA.Application.DanhMucQuyTrinhs.Commands;

public record DanhMucQuyTrinhInsertCommand(DanhMucQuyTrinhDto Dto) : IRequest<DanhMucQuyTrinhDto>;

internal class DanhMucQuyTrinhInsertCommandHandler : IRequestHandler<DanhMucQuyTrinhInsertCommand, DanhMucQuyTrinhDto> {
    private readonly IRepository<DanhMucQuyTrinh, int> DanhMucQuyTrinh;
    private readonly IUnitOfWork UnitOfWork;

    public DanhMucQuyTrinhInsertCommandHandler(IServiceProvider serviceProvider) {
        DanhMucQuyTrinh = serviceProvider.GetRequiredService<IRepository<DanhMucQuyTrinh, int>>();
        UnitOfWork = DanhMucQuyTrinh.UnitOfWork;
    }

    public async Task<DanhMucQuyTrinhDto> Handle(DanhMucQuyTrinhInsertCommand request, CancellationToken cancellationToken) {
        var entity = new DanhMucQuyTrinh {
            Ma = request.Dto.Ma,
            Ten = request.Dto.Ten,
            MoTa = request.Dto.MoTa,
            Stt = request.Dto.Stt,
            Used = request.Dto.Used,
            MacDinh = request.Dto.MacDinh,
        };

        await DanhMucQuyTrinh.AddAsync(entity, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return entity.ToDto();
    }
}