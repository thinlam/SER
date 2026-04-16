using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for XuatHoaDonController.
/// </summary>
public class XuatHoaDonControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public XuatHoaDonControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/xuat-hoa-don/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetByHopDong_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/xuat-hoa-don/{nonExistentId}/danh-sach");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetDetail_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        // Note: GetDetail requires hopDongId query param based on controller signature
        var response = await _client.GetAsync($"api/xuat-hoa-don/chi-tiet/{nonExistentId}?hopDongId={Guid.NewGuid()}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}