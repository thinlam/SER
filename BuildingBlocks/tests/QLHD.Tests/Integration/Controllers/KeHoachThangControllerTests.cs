using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for KeHoachThangController.
/// Uses int ID type.
/// </summary>
public class KeHoachThangControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public KeHoachThangControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/ke-hoach-thang/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/ke-hoach-thang/chi-tiet/9999");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Combobox_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/ke-hoach-thang/combobox");
        response.Should().BeSuccessful();
    }
}