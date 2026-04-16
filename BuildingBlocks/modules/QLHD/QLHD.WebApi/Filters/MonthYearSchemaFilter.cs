using BuildingBlocks.Domain.ValueTypes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QLHD.WebApi.Filters;

/// <summary>
/// Swagger schema filter for MonthYear struct.
/// Ensures Swagger generates correct schema (string format: "MM-yyyy") instead of object.
/// </summary>
public class MonthYearSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(MonthYear) || context.Type == typeof(MonthYear?))
        {
            schema.Type = "string";
            schema.Format = "MM-yyyy";
            schema.Example = new Microsoft.OpenApi.Any.OpenApiString("03-2025");
            schema.Description = "Month-Year in MM-yyyy format (e.g., 03-2025 for March 2025)";
            schema.Properties.Clear();
        }
    }
}