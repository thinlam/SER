using System.Text.Json;
using BuildingBlocks.Application.Common.Converters;
using BuildingBlocks.Domain.ValueTypes;
using Xunit;

namespace BuildingBlocks.Tests.Application.Converters;

/// <summary>
/// Unit tests for MonthYearJsonConverter
/// </summary>
public class MonthYearJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public MonthYearJsonConverterTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new MonthYearJsonConverter());
    }

    #region String Format Tests

    [Fact]
    public void Read_StringFormat_ShouldParseCorrectly()
    {
        // Arrange
        var json = "\"03-2025\"";

        // Act
        var result = JsonSerializer.Deserialize<MonthYear>(json, _options);

        // Assert
        Assert.Equal(3, result.Month);
        Assert.Equal(2025, result.Year);
    }

    [Theory]
    [InlineData("\"01-2024\"", 1, 2024)]
    [InlineData("\"12-9999\"", 12, 9999)]
    [InlineData("\"6-2025\"", 6, 2025)]
    [InlineData("\"04-2027\"", 4, 2027)]  // Example: April 2027
    public void Read_StringFormat_ValidFormats_ShouldParseCorrectly(string json, int expectedMonth, int expectedYear)
    {
        // Act
        var result = JsonSerializer.Deserialize<MonthYear>(json, _options);

        // Assert
        Assert.Equal(expectedMonth, result.Month);
        Assert.Equal(expectedYear, result.Year);
    }

    [Fact]
    public void Read_StringFormat_InvalidFormat_ShouldThrowJsonException()
    {
        // Arrange
        var json = "\"invalid\"";

        // Act & Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MonthYear>(json, _options));
    }

    #endregion

    #region Object Format Tests

    [Fact]
    public void Read_ObjectFormat_ShouldParseCorrectly()
    {
        // Arrange
        var json = "{\"month\":3,\"year\":2025}";

        // Act
        var result = JsonSerializer.Deserialize<MonthYear>(json, _options);

        // Assert
        Assert.Equal(3, result.Month);
        Assert.Equal(2025, result.Year);
    }

    [Fact]
    public void Read_ObjectFormat_CaseInsensitive_ShouldParseCorrectly()
    {
        // Arrange
        var json = "{\"Month\":3,\"Year\":2025}";

        // Act
        var result = JsonSerializer.Deserialize<MonthYear>(json, _options);

        // Assert
        Assert.Equal(3, result.Month);
        Assert.Equal(2025, result.Year);
    }

    [Theory]
    [InlineData("{\"month\":1,\"year\":2024}", 1, 2024)]
    [InlineData("{\"month\":12,\"year\":9999}", 12, 9999)]
    public void Read_ObjectFormat_ValidValues_ShouldParseCorrectly(string json, int expectedMonth, int expectedYear)
    {
        // Act
        var result = JsonSerializer.Deserialize<MonthYear>(json, _options);

        // Assert
        Assert.Equal(expectedMonth, result.Month);
        Assert.Equal(expectedYear, result.Year);
    }

    [Fact]
    public void Read_ObjectFormat_InvalidMonth_ShouldThrowJsonException()
    {
        // Arrange - month 0 is invalid
        var json = "{\"month\":0,\"year\":2025}";

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MonthYear>(json, _options));
        Assert.Contains("month must be between 1 and 12", exception.Message);
    }

    [Fact]
    public void Read_ObjectFormat_InvalidMonth13_ShouldThrowJsonException()
    {
        // Arrange - month 13 is invalid
        var json = "{\"month\":13,\"year\":2025}";

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MonthYear>(json, _options));
        Assert.Contains("month must be between 1 and 12", exception.Message);
    }

    [Fact]
    public void Read_ObjectFormat_InvalidYear0_ShouldThrowJsonException()
    {
        // Arrange - year 0 is invalid
        var json = "{\"month\":3,\"year\":0}";

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MonthYear>(json, _options));
        Assert.Contains("year must be between 1 and 9999", exception.Message);
    }

    [Fact]
    public void Read_ObjectFormat_MissingMonth_ShouldThrowJsonException()
    {
        // Arrange
        var json = "{\"year\":2025}";

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MonthYear>(json, _options));
        Assert.Contains("must contain both 'month' and 'year'", exception.Message);
    }

    [Fact]
    public void Read_ObjectFormat_MissingYear_ShouldThrowJsonException()
    {
        // Arrange
        var json = "{\"month\":3}";

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MonthYear>(json, _options));
        Assert.Contains("must contain both 'month' and 'year'", exception.Message);
    }

    #endregion

    #region Write Tests

    [Fact]
    public void Write_ShouldReturnStringFormat()
    {
        // Arrange
        var monthYear = new MonthYear(3, 2025);

        // Act
        var json = JsonSerializer.Serialize(monthYear, _options);

        // Assert
        Assert.Equal("\"03-2025\"", json);
    }

    [Theory]
    [InlineData(1, 2024, "\"01-2024\"")]
    [InlineData(12, 9999, "\"12-9999\"")]
    public void Write_ValidValues_ShouldReturnCorrectString(int month, int year, string expected)
    {
        // Arrange
        var monthYear = new MonthYear(month, year);

        // Act
        var json = JsonSerializer.Serialize(monthYear, _options);

        // Assert
        Assert.Equal(expected, json);
    }

    #endregion

    #region Round-trip Tests

    [Fact]
    public void RoundTrip_ShouldPreserveValue()
    {
        // Arrange
        var original = new MonthYear(6, 2025);

        // Act
        var json = JsonSerializer.Serialize(original, _options);
        var result = JsonSerializer.Deserialize<MonthYear>(json, _options);

        // Assert
        Assert.Equal(original, result);
    }

    #endregion
}