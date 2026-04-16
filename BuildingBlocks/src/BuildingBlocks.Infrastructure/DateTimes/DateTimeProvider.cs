namespace BuildingBlocks.Infrastructure.DateTimes;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTimeOffset OffsetNow => DateTimeOffset.Now;
    public DateTimeOffset OffsetUtcNow => DateTimeOffset.UtcNow;
    public DateTimeOffset StartOfYearUtc => new(DateTime.UtcNow.Year, 1, 1, 0, 0, 0, TimeSpan.Zero);
    public DateTimeOffset EndOfYearUtc => new(DateTime.UtcNow.Year, 12, 31, 23, 59, 59, 999, TimeSpan.Zero);
}