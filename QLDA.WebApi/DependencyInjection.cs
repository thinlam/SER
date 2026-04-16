using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QLDA.Domain.Constants;

namespace QLDA.WebApi;

public static class DependencyInjection {
    /// <summary>
    /// Registers JWT Bearer authentication using provided JwtSettings.
    /// Mirrors the inline configuration previously in Program.cs
    /// </summary>
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtSettings jwt, IWebHostEnvironment environment) {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

        services
            .AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    RoleClaimType = ClaimConstants.Roles,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    // ValidIssuer = jwt.Issuer,
                    // ValidAudience = jwt.Audience,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    ValidateLifetime = environment.IsProduction()
                };
            });

        return services;
    }
}
