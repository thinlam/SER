using System.Text.Json;
using BuildingBlocks.Application.Common.Converters;
using MediatR.Pipeline;

namespace BuildingBlocks.Application.Common.Behaviors;

public class LoggingBehavior<TRequest>() : IRequestPreProcessor<TRequest>
    where TRequest : notnull {
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<LoggingBehavior<TRequest>>();
    private const int MaxLogLength = 2000;

    public Task Process(TRequest request, CancellationToken cancellationToken) {
        string requestName = typeof(TRequest).Name;

        // 1. Serialize
        string json = JsonSerializer.Serialize(request, new JsonSerializerOptions {
            // nếu cần loại bỏ vòng lặp tham chiếu, ...
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            WriteIndented = false,
            Converters = { new MonthYearJsonConverter() } // nếu cần converter tùy chỉnh
        });

        // 2. Truncate nếu quá dài
        if (json.Length > MaxLogLength) {
            json = json[..MaxLogLength] + "...(truncated)";
        }

        // 3. Log với chuỗi đã truncate
        _logger.Information(
            "Messenger Request: {Name} {@Request}",
            requestName,
            json
        );

        return Task.CompletedTask;
    }
}
