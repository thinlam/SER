using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BuildingBlocks.Domain.Constants;

namespace QLHD.Tests.Integration.Infrastructure;

/// <summary>
/// Mock authentication handler that bypasses JWT validation and provides test claims.
/// Simulates authenticated user with all QLHD roles for testing.
/// </summary>
public class MockAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MockAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Create claims for test user with all QLHD roles
        // Use ClaimTypes.Role for role-based authorization (User.IsInRole)
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "test-user"),
            new Claim(ClaimTypes.NameIdentifier, "test-user-id"),
            // Add BuildingBlocks base role
            new Claim(ClaimTypes.Role, BuildingBlocks.Domain.Constants.RoleConstants.RegisteredUsers),
            // Add all QLHD roles for full access
            new Claim(ClaimTypes.Role, QLHD.Domain.Constants.RoleConstants.QLHD_All),
            new Claim(ClaimTypes.Role, QLHD.Domain.Constants.RoleConstants.QLHD_QuanTri),
            new Claim(ClaimTypes.Role, QLHD.Domain.Constants.RoleConstants.QLHD_ChuyenVien),
            new Claim(ClaimTypes.Role, QLHD.Domain.Constants.RoleConstants.QLHD_LanhDao),
            new Claim(ClaimTypes.Role, QLHD.Domain.Constants.RoleConstants.QLHD_LanhDaoDonVi),
            new Claim(ClaimTypes.Role, QLHD.Domain.Constants.RoleConstants.QLHD_KeToan)
        };

        var identity = new ClaimsIdentity(claims, "TestScheme");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "TestScheme");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}