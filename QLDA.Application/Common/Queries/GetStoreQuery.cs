using BuildingBlocks.CrossCutting.Offices;

namespace QLDA.Application.Common.Queries;

public record GetStoreQuery : IRequest<AsposeResult> {
    /// <summary>
    /// Store Procedure name
    /// </summary>
    public required string ProcName { get; set; }

    /// <summary>
    /// Params
    /// </summary>
    public object? Params { get; set; }

    public string? ConnectionName { get; set; }
    public required string PathTemplate { get; set; }
    public List<string>? HiddenColumns { get; set; }
}

internal class GetStoreQueryHandler(IServiceProvider ServiceProvider) : IRequestHandler<GetStoreQuery, AsposeResult> {
    private readonly IDapperRepository _dapperRepository = ServiceProvider.GetRequiredService<IDapperRepository>();
    private readonly IExporterHelper _exporter = ServiceProvider.GetRequiredService<IExporterHelper>();
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<GetStoreQueryHandler>();

    public async Task<AsposeResult> Handle(GetStoreQuery request, CancellationToken cancellationToken) {
        try {
            var data = await _dapperRepository.QueryStoredProcAsync<object>(request.ProcName, request.Params,
                request.ConnectionName);

            return _exporter.Export(new AsposeInstruction<dynamic> {
                TemplatePath = request.PathTemplate,
                Items = data.ToList(),
                HiddenColumns = request.HiddenColumns ?? []
            });
        } catch (Exception ex) {
            _logger.Error(ex.Message, ex);
            throw;
        }
    }
}