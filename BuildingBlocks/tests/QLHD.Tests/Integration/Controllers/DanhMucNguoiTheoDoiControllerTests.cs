using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DanhMucNguoiTheoDoiController.
/// </summary>
public class DanhMucNguoiTheoDoiControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DanhMucNguoiTheoDoiControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-nguoi-theo-doi/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnBadRequest()
    {
        // API returns 400 Bad Request for non-existent ID
        var response = await _client.GetAsync("api/danh-muc-nguoi-theo-doi/chi-tiet/9999");
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}