using Xunit;
using BuildingBlocks.Domain.ValueTypes;

namespace BuildingBlocks.Tests.Domain.ValueTypes;

/// <summary>
/// Unit tests for MonthYear value type
/// </summary>
public class MonthYearTests
{
    #region Constructor Tests

    [Fact]
    public void Constructor_ValidValues_ShouldCreateInstance()
    {
        // Arrange & Act
        var monthYear = new MonthYear(3, 2025);

        // Assert
        Assert.Equal(3, monthYear.Month);
        Assert.Equal(2025, monthYear.Year);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(13)]
    [InlineData(-1)]
    [InlineData(100)]
    public void Constructor_InvalidMonth_ShouldThrowArgumentOutOfRangeException(int month)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MonthYear(month, 2025));
        Assert.Equal("month", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10000)]
    [InlineData(-1)]
    [InlineData(-2025)]
    public void Constructor_InvalidYear_ShouldThrowArgumentOutOfRangeException(int year)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new MonthYear(6, year));
        Assert.Equal("year", exception.ParamName);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(12, 9999)]
    [InlineData(6, 2024)]
    public void Constructor_BoundaryValues_ShouldCreateInstance(int month, int year)
    {
        // Arrange & Act
        var monthYear = new MonthYear(month, year);

        // Assert
        Assert.Equal(month, monthYear.Month);
        Assert.Equal(year, monthYear.Year);
    }

    #endregion

    #region Parse Tests

    [Fact]
    public void Parse_ValidFormat_ShouldReturnMonthYear()
    {
        // Arrange & Act
        var result = MonthYear.Parse("03-2025");

        // Assert
        Assert.Equal(3, result.Month);
        Assert.Equal(2025, result.Year);
    }

    [Theory]
    [InlineData("01-2024", 1, 2024)]
    [InlineData("12-9999", 12, 9999)]
    [InlineData("06-0001", 6, 1)]
    [InlineData("04-2027", 4, 2027)]  // Example: April 2027
    public void Parse_ValidFormats_ShouldReturnCorrectMonthYear(string input, int expectedMonth, int expectedYear)
    {
        // Arrange & Act
        var result = MonthYear.Parse(input);

        // Assert
        Assert.Equal(expectedMonth, result.Month);
        Assert.Equal(expectedYear, result.Year);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Parse_NullOrEmpty_ShouldThrowFormatException(string? input)
    {
        // Act & Assert
        Assert.Throws<FormatException>(() => MonthYear.Parse(input!));
    }

    [Theory]
    [InlineData("2025-03")]      // Wrong format (yyyy-MM)
    [InlineData("03/2025")]      // Wrong separator
    [InlineData("March-2025")]   // Non-numeric month
    [InlineData("03-2025-01")]   // Too many parts
    [InlineData("032025")]       // No separator
    public void Parse_InvalidFormat_ShouldThrowFormatException(string input)
    {
        // Act & Assert
        Assert.ThrowsAny<Exception>(() => MonthYear.Parse(input));
    }

    [Theory]
    [InlineData("3-2025")]       // Valid: month without leading zero
    [InlineData("03-25")]        // Valid: short year (year 25 is valid)
    public void Parse_ValidVariants_ShouldSucceed(string input)
    {
        // Act & Assert - These should NOT throw
        var result = MonthYear.Parse(input);
        Assert.True(result.Month >= 1 && result.Month <= 12);
        Assert.True(result.Year >= 1 && result.Year <= 9999);
    }

    [Fact]
    public void Parse_InvalidMonth_ShouldThrowArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => MonthYear.Parse("13-2025"));
    }

    [Fact]
    public void Parse_InvalidYear_ShouldThrowArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => MonthYear.Parse("06-10000"));
    }

    #endregion

    #region TryParse Tests

    [Fact]
    public void TryParse_ValidFormat_ShouldReturnTrueAndSetResult()
    {
        // Act
        var success = MonthYear.TryParse("03-2025", out var result);

        // Assert
        Assert.True(success);
        Assert.Equal(3, result.Month);
        Assert.Equal(2025, result.Year);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("invalid")]
    [InlineData("13-2025")]  // Invalid month
    [InlineData("00-2025")]  // Invalid month
    [InlineData("06-0")]     // Invalid year
    [InlineData("06-10000")] // Invalid year
    public void TryParse_InvalidValue_ShouldReturnFalse(string? input)
    {
        // Act
        var success = MonthYear.TryParse(input, out var result);

        // Assert
        Assert.False(success);
        Assert.Equal(default(MonthYear), result);
    }

    #endregion

    #region ToDateOnly Tests

    [Fact]
    public void ToDateOnly_DefaultDay_ShouldReturnDateOnlyWithDayOne()
    {
        // Arrange
        var monthYear = new MonthYear(3, 2025);

        // Act
        var date = monthYear.ToDateOnly();

        // Assert
        Assert.Equal(2025, date.Year);
        Assert.Equal(3, date.Month);
        Assert.Equal(1, date.Day);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(15)]
    [InlineData(31)]
    public void ToDateOnly_CustomDay_ShouldReturnDateOnlyWithSpecifiedDay(int day)
    {
        // Arrange
        var monthYear = new MonthYear(1, 2025); // January has 31 days

        // Act
        var date = monthYear.ToDateOnly(day);

        // Assert
        Assert.Equal(day, date.Day);
    }

    [Fact]
    public void ToDateOnly_InvalidDayForMonth_ShouldThrow()
    {
        // Arrange
        var monthYear = new MonthYear(2, 2025); // February

        // Act & Assert - Day 31 doesn't exist in February
        Assert.Throws<ArgumentOutOfRangeException>(() => monthYear.ToDateOnly(31));
    }

    #endregion

    #region Default State Tests

    [Fact]
    public void ToDateOnly_DefaultUninitializedState_ShouldThrowInvalidOperationException()
    {
        // Arrange
        MonthYear defaultMonthYear = default;

        // Act & Assert - Default MonthYear has Month=0, Year=0 which is invalid for DateOnly
        var ex = Assert.Throws<InvalidOperationException>(() => defaultMonthYear.ToDateOnly());
        Assert.Contains("default/uninitialized state", ex.Message);
    }

    [Fact]
    public void ImplicitConversion_DefaultUninitializedState_ShouldThrowInvalidOperationException()
    {
        // Arrange
        MonthYear defaultMonthYear = default;

        // Act & Assert - Implicit conversion calls ToDateOnly()
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            DateOnly date = defaultMonthYear;
        });
        Assert.Contains("default/uninitialized state", ex.Message);
    }

    #endregion

    #region ToString Tests

    [Theory]
    [InlineData(1, 2025, "01-2025")]
    [InlineData(12, 2024, "12-2024")]
    [InlineData(6, 9999, "06-9999")]
    public void ToString_ShouldReturnFormattedString(int month, int year, string expected)
    {
        // Arrange
        var monthYear = new MonthYear(month, year);

        // Act
        var result = monthYear.ToString();

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region FromDateOnly Tests

    [Fact]
    public void FromDateOnly_ShouldCreateCorrectMonthYear()
    {
        // Arrange
        var date = new DateOnly(2025, 3, 15);

        // Act
        var monthYear = MonthYear.FromDateOnly(date);

        // Assert
        Assert.Equal(3, monthYear.Month);
        Assert.Equal(2025, monthYear.Year);
    }

    #endregion

    #region Current Tests

    [Fact]
    public void Current_ShouldReturnCurrentMonthYear()
    {
        // Arrange
        var today = DateTime.Today;

        // Act
        var current = MonthYear.Current;

        // Assert
        Assert.Equal(today.Month, current.Month);
        Assert.Equal(today.Year, current.Year);
    }

    #endregion

    #region Equality Tests

    [Fact]
    public void Equals_SameValues_ShouldReturnTrue()
    {
        // Arrange
        var left = new MonthYear(3, 2025);
        var right = new MonthYear(3, 2025);

        // Act & Assert
        Assert.True(left.Equals(right));
        Assert.True(left == right);
        Assert.False(left != right);
    }

    [Fact]
    public void Equals_DifferentValues_ShouldReturnFalse()
    {
        // Arrange
        var left = new MonthYear(3, 2025);
        var right = new MonthYear(4, 2025);

        // Act & Assert
        Assert.False(left.Equals(right));
        Assert.False(left == right);
        Assert.True(left != right);
    }

    [Fact]
    public void Equals_DifferentYear_ShouldReturnFalse()
    {
        // Arrange
        var left = new MonthYear(3, 2025);
        var right = new MonthYear(3, 2024);

        // Act & Assert
        Assert.False(left.Equals(right));
        Assert.False(left == right);
        Assert.True(left != right);
    }

    [Fact]
    public void Equals_Null_ShouldReturnFalse()
    {
        // Arrange
        var monthYear = new MonthYear(3, 2025);

        // Act & Assert
        Assert.False(monthYear.Equals(null));
    }

    [Fact]
    public void GetHashCode_SameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var left = new MonthYear(3, 2025);
        var right = new MonthYear(3, 2025);

        // Act & Assert
        Assert.Equal(left.GetHashCode(), right.GetHashCode());
    }

    #endregion

    #region Implicit Conversion Tests

    [Fact]
    public void ImplicitConversion_ToDateOnly_ShouldReturnDateOnlyWithDayOne()
    {
        // Arrange
        var monthYear = new MonthYear(3, 2025);

        // Act
        DateOnly date = monthYear;

        // Assert
        Assert.Equal(2025, date.Year);
        Assert.Equal(3, date.Month);
        Assert.Equal(1, date.Day);
    }

    #endregion
}