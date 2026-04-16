using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for TienDoController.
/// GetList requires hopDongId query parameter.
/// </summary>
public class TienDoControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public TienDoControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_WithHopDongId_ShouldReturnSuccess()
    {
        var hopDongId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/tien-do/danh-sach?hopDongId={hopDongId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/tien-do/chi-tiet/{nonExistentId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}