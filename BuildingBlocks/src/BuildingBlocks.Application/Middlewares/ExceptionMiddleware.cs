using System.Net;
using System.Net.Mime;
using System.Text.RegularExpressions;
using BuildingBlocks.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace BuildingBlocks.Application.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly Serilog.ILogger _logger = Serilog.Log.ForContext<ExceptionMiddleware>();

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ManagedException ex)
        {
            await HandleException(context, HttpStatusCode.OK, ex, ex.Message);
        }
        catch (Exception ex)
        {
            if (ex.InnerException is SqlException sqlEx)
            {
                var msg = sqlEx.Number switch
                {
                    251 => "Sai kiểu dữ liệu",
                    515 => "Giá trị không được để trống",
                    547 => ParseForeignKeyError(sqlEx),
                    2601 => "Khoá chính đã tồn tại",
                    2627 => "Trường dữ liệu trùng lặp",
                    _ => null
                };

                if (msg != null)
                {
                    await HandleException(context, HttpStatusCode.OK, ex, msg);
                    return;
                }
            }
            await HandleException(context, HttpStatusCode.BadRequest, ex, null);
        }
    }

    /// <summary>
    /// Parses SqlException 547 to extract detailed FK error message.
    /// FK constraint naming: FK_{DependentTable}_{PrincipalTable}_{FKColumn}
    /// </summary>
    private static string ParseForeignKeyError(SqlException sqlEx)
    {
        var message = sqlEx.Message;

        // Extract constraint name via regex
        var constraintMatch = Regex.Match(message, @"constraint ""(\w+)""");
        if (!constraintMatch.Success) return "Khoá ngoại không hợp lệ";

        var constraintName = constraintMatch.Groups[1].Value;
        var parts = constraintName.Split('_');

        // FK_{DependentTable}_{PrincipalTable}_{FKColumn}
        if (parts.Length >= 4 && parts[0] == "FK")
        {
            var fkColumn = parts[3];        // e.g., GiamDocId
            var principalTable = parts[2];  // e.g., DanhMucGiamDoc

            return $"{fkColumn} -> Khoá ngoại liên kết bảng {principalTable} không tồn tại";
        }

        return "Khoá ngoại không hợp lệ";
    }

    private async Task HandleException(HttpContext context, HttpStatusCode statusCode, Exception exception, string? customMessage = null)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)statusCode;

        if (exception is ManagedException { Errors: not null } managedEx)
        {
            var err = ResultApi.Fail(string.Join(",", managedEx.Errors.SelectMany(e => e.Value)));
            _logger.Error(string.Join(",", managedEx.Errors.SelectMany(e => e.Value)));
            await context.Response.WriteAsJsonAsync(err);
        }
        else
        {
            var errorMessage = customMessage ?? ErrorMessageConstants.InternalServerError;
            var err = ResultApi.Fail(errorMessage);
            _logger.Error(exception, "An error occurred with custom message: {CustomMessage}. Full details: {ExceptionMessage}",
                errorMessage, exception.Message);
            await context.Response.WriteAsJsonAsync(err);
        }
    }
}