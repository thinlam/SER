using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for BaoCaoTienDoController.
/// Has approval workflow with /cho-duyet and /duyet endpoints.
/// </summary>
public class BaoCaoTienDoControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public BaoCaoTienDoControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_WithTienDoId_ShouldReturnSuccess()
    {
        var tienDoId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/bao-cao-tien-do/danh-sach?tienDoId={tienDoId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        var nonExistentId = Guid.NewGuid();
        var response = await _client.GetAsync($"api/bao-cao-tien-do/chi-tiet/{nonExistentId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetPending_WithNguoiDuyetId_ShouldReturnSuccess()
    {
        var nguoiDuyetId = 1L;
        var response = await _client.GetAsync($"api/bao-cao-tien-do/cho-duyet?nguoiDuyetId={nguoiDuyetId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}