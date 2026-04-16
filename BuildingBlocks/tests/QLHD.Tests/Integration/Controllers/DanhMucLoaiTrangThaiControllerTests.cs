using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DanhMucLoaiTrangThaiController.
/// </summary>
public class DanhMucLoaiTrangThaiControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DanhMucLoaiTrangThaiControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-loai-trang-thai/danh-sach");
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("api/danh-muc-loai-trang-thai/chi-tiet/9999");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}