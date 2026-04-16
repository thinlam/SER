using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DanhMucLoaiChiPhiController.
/// </summary>
public class DanhMucLoaiChiPhiControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DanhMucLoaiChiPhiControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-loai-chi-phi/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnBadRequest()
    {
        // API returns 400 Bad Request for non-existent ID
        var response = await _client.GetAsync("api/danh-muc-loai-chi-phi/chi-tiet/9999");
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Combobox_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-loai-chi-phi/combobox");
        response.Should().BeSuccessful();
    }
}