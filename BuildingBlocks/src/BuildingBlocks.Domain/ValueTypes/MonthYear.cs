namespace BuildingBlocks.Domain.ValueTypes;

/// <summary>
/// Value type representing a month-year combination (MM-yyyy format).
/// Used for UI input where day is not significant, converts to DateOnly for database storage.
/// </summary>
public readonly struct MonthYear
{
    /// <summary>
    /// Month component (1-12)
    /// </summary>
    public int Month { get; }

    /// <summary>
    /// Year component
    /// </summary>
    public int Year { get; }

    /// <summary>
    /// Creates a new MonthYear instance
    /// </summary>
    /// <param name="month">Month (1-12)</param>
    /// <param name="year">Year (1-9999)</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when month is not between 1 and 12, or year is not between 1 and 9999</exception>
    public MonthYear(int month, int year)
    {
        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12");
        if (year < 1 || year > 9999)
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 1 and 9999");
        Month = month;
        Year = year;
    }

    /// <summary>
    /// Parses a "MM-yyyy" formatted string to MonthYear
    /// </summary>
    /// <param name="value">String in "MM-yyyy" format (e.g., "03-2025")</param>
    /// <returns>MonthYear instance</returns>
    /// <exception cref="FormatException">Thrown when format is invalid</exception>
    public static MonthYear Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new FormatException("Value cannot be null or empty");

        var parts = value.Split('-');
        if (parts.Length != 2)
            throw new FormatException("Format must be MM-yyyy");

        if (!int.TryParse(parts[0], out var month) || !int.TryParse(parts[1], out var year))
            throw new FormatException("Invalid month or year value");

        return new MonthYear(month, year);
    }

    /// <summary>
    /// Tries to parse a "MM-yyyy" formatted string to MonthYear
    /// </summary>
    /// <param name="value">String in "MM-yyyy" format</param>
    /// <param name="result">Parsed MonthYear if successful</param>
    /// <returns>True if parsing succeeded, false otherwise</returns>
    public static bool TryParse(string? value, out MonthYear result)
    {
        result = default;

        if (string.IsNullOrWhiteSpace(value))
            return false;

        var parts = value.Split('-');
        if (parts.Length != 2)
            return false;

        if (!int.TryParse(parts[0], out var month) || !int.TryParse(parts[1], out var year))
            return false;

        if (month < 1 || month > 12)
            return false;

        if (year < 1 || year > 9999)
            return false;

        result = new MonthYear(month, year);
        return true;
    }

    /// <summary>
    /// Converts to DateOnly for database storage.
    /// Note: Caller is responsible for ensuring day is valid for the month (e.g., day 31 for February will throw).
    /// </summary>
    /// <param name="day">Day of month (default: 1, always valid for any month)</param>
    /// <returns>DateOnly representation</returns>
    public DateOnly ToDateOnly(int day = 1) => new(Year, Month, day);

    /// <summary>
    /// Returns string in "MM-yyyy" format
    /// </summary>
    public override string ToString() => $"{Month:D2}-{Year}";

    /// <summary>
    /// Creates a MonthYear from a DateOnly
    /// </summary>
    public static MonthYear FromDateOnly(DateOnly date) => new(date.Month, date.Year);

    /// <summary>
    /// Gets current month-year
    /// </summary>
    public static MonthYear Current => FromDateOnly(DateOnly.FromDateTime(DateTime.Today));

    public override bool Equals(object? obj) =>
        obj is MonthYear other && Month == other.Month && Year == other.Year;

    public override int GetHashCode() => HashCode.Combine(Month, Year);

    public static bool operator ==(MonthYear left, MonthYear right) =>
        left.Month == right.Month && left.Year == right.Year;

    public static bool operator !=(MonthYear left, MonthYear right) => !(left == right);

    /// <summary>
    /// Implicit conversion to DateOnly (uses day 1)
    /// </summary>
    public static implicit operator DateOnly(MonthYear monthYear) => monthYear.ToDateOnly();
}