namespace BuildingBlocks.CrossCutting.DateTimes;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
    DateTimeOffset OffsetNow { get; }
    DateTimeOffset OffsetUtcNow { get; }
    DateTimeOffset StartOfYearUtc { get; }
    DateTimeOffset EndOfYearUtc { get; }
}