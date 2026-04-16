using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DanhMucLoaiThanhToanController.
/// </summary>
public class DanhMucLoaiThanhToanControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DanhMucLoaiThanhToanControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-loai-thanh-toan/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnBadRequest()
    {
        // API returns 400 Bad Request for non-existent ID
        var response = await _client.GetAsync("api/danh-muc-loai-thanh-toan/chi-tiet/9999");
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Combobox_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-loai-thanh-toan/combobox");
        response.Should().BeSuccessful();
    }
}