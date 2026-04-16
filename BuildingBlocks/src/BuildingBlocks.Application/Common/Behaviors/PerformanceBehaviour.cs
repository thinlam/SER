using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Application.Common.Behaviors;

public class PerformanceBehavior<TRequest, TResponse>(
    ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly Stopwatch _timer = new();
    private const int MaxLogLength = 2000;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _timer.Start();

        TResponse? response = await next(cancellationToken);

        _timer.Stop();

        long elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500) return response;
        string requestName = typeof(TRequest).Name;


        // 1. Serialize
        string json = JsonSerializer.Serialize(request, new JsonSerializerOptions
        {
            // nếu cần loại bỏ vòng lặp tham chiếu, ...
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            WriteIndented = false
        });

        // 2. Truncate nếu quá dài
        if (json.Length > MaxLogLength)
        {
            json = json[..MaxLogLength] + "...(truncated)";
        }

        logger.LogWarning(
            "Messenger Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds)  {@Request}",
            requestName, elapsedMilliseconds, json);

        return response;
    }
}
