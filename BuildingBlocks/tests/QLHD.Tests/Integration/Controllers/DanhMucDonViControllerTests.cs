using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DanhMucDonViController.
/// Legacy table with combobox/phong-ban/don-vi endpoints.
/// </summary>
public class DanhMucDonViControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DanhMucDonViControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Combobox_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-don-vi/combobox");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetPhongBanList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-don-vi/danh-sach/phong-ban");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetDonViList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-don-vi/danh-sach/don-vi");
        response.Should().BeSuccessful();
    }
}