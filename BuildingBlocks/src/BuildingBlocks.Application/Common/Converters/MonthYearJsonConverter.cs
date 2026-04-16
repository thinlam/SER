using System.Text.Json;
using System.Text.Json.Serialization;
using BuildingBlocks.Domain.ValueTypes;

namespace BuildingBlocks.Application.Common.Converters;

/// <summary>
/// JSON converter for MonthYear struct.
/// Handles serialization between MonthYear and both "MM-yyyy" string format and object format { month, year }.
/// </summary>
public class MonthYearJsonConverter : JsonConverter<MonthYear>
{
    public override MonthYear Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Handle string format: "03-2025"
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();

            if (string.IsNullOrEmpty(stringValue))
                throw new JsonException("MonthYear value cannot be null or empty");

            if (!MonthYear.TryParse(stringValue, out var result))
                throw new JsonException($"Invalid MonthYear format: '{stringValue}'. Expected format: MM-yyyy");

            return result;
        }

        // Handle object format: { "month": 3, "year": 2025 }
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            int? month = null;
            int? year = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName?.ToLowerInvariant())
                    {
                        case "month":
                            month = reader.GetInt32();
                            break;
                        case "year":
                            year = reader.GetInt32();
                            break;
                    }
                }
            }

            if (!month.HasValue || !year.HasValue)
                throw new JsonException("MonthYear object must contain both 'month' and 'year' properties");

            // Validate values
            if (month.Value < 1 || month.Value > 12)
                throw new JsonException($"Invalid MonthYear: month must be between 1 and 12, got {month.Value}");

            if (year.Value < 1 || year.Value > 9999)
                throw new JsonException($"Invalid MonthYear: year must be between 1 and 9999, got {year.Value}");

            return new MonthYear(month.Value, year.Value);
        }

        throw new JsonException($"Unexpected token type {reader.TokenType} for MonthYear. Expected string \"MM-yyyy\" or object {{ month, year }}");
    }

    public override void Write(Utf8JsonWriter writer, MonthYear value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}