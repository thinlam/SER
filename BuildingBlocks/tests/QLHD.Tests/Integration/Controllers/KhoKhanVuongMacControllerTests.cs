using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for KhoKhanVuongMacController.
/// GetList requires hopDongId query parameter.
/// </summary>
public class KhoKhanVuongMacControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public KhoKhanVuongMacControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_WithHopDongId_ShouldReturnSuccess()
    {
        var hopDongId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/kho-khan-vuong-mac/danh-sach?hopDongId={hopDongId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/kho-khan-vuong-mac/chi-tiet/{nonExistentId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}