using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for ChiPhiController.
/// </summary>
public class ChiPhiControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ChiPhiControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/chi-phi/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetByHopDong_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/chi-phi/{nonExistentId}/danh-sach");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetDetail_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/chi-phi/chi-tiet/{nonExistentId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}