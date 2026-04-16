using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for PhuLucHopDongController.
/// </summary>
public class PhuLucHopDongControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public PhuLucHopDongControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/phu-luc-hop-dong/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetByHopDong_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/phu-luc-hop-dong/{nonExistentId}/danh-sach");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/phu-luc-hop-dong/{nonExistentId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}