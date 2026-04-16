using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DanhMucLoaiHopDongController.
/// Simplest DanhMuc tests - good starting point.
/// </summary>
public class DanhMucLoaiHopDongControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DanhMucLoaiHopDongControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        // Act
        var response = await _client.GetAsync("api/danh-muc-loai-hop-dong/danh-sach");

        // Assert
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetCombobox_ShouldReturnSuccess()
    {
        // Act
        var response = await _client.GetAsync("api/danh-muc-loai-hop-dong/combobox");

        // Assert
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnBadRequest()
    {
        // Arrange - use non-existent ID
        const int nonExistentId = 99999;

        // Act
        var response = await _client.GetAsync($"api/danh-muc-loai-hop-dong/chi-tiet/{nonExistentId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Create_ValidModel_ShouldReturnCreatedDto()
    {
        // Arrange
        var model = new
        {
            Ma = "TEST_LHD_001",
            Ten = "Loại hợp đồng test",
            MoTa = "Mô tả test",
            Used = true
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/danh-muc-loai-hop-dong/them-moi", model);

        // Assert
        response.Should().BeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<ResultApi>();
        result.Should().NotBeNull();
        result!.Result.Should().BeTrue();
    }
}