using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for KhachHangController.
/// </summary>
public class KhachHangControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public KhachHangControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/khach-hang/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/khach-hang/chi-tiet/{nonExistentId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Combobox_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/khach-hang/combobox");
        response.Should().BeSuccessful();
    }
}