using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Application.Common.Behaviors;

public class UnhandledExceptionBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private const int MaxLogLength = 2000;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
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

            logger.LogError(ex, "Messenger Request: Unhandled Exception for Request {Name} {@Request}", requestName,
                json);

            throw;
        }
    }
}
