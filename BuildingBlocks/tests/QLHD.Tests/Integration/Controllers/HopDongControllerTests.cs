using QLHD.Tests.Integration.Infrastructure;
using QLHD.Application.HopDongs.DTOs;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for HopDongController.
/// Core business entity CRUD operations.
/// </summary>
public class HopDongControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;
    private static readonly Guid TestKhachHangId = Guid.Parse("00000000-0000-0000-0000-000000000001");

    public HopDongControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        // Act
        var response = await _client.GetAsync("api/hop-dong/danh-sach");

        // Assert
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var response = await _client.GetAsync($"api/hop-dong/chi-tiet/{nonExistentId}");

        // Assert - API returns 200 with error message for non-existent IDs
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Create_ValidModel_ShouldReturnCreatedDto()
    {
        // Arrange - minimal valid model
        var model = new HopDongInsertModel
        {
            SoHopDong = "HD-TEST-001",
            Ten = "Hợp đồng test",
            KhachHangId = TestKhachHangId,
            NgayKy = DateOnly.FromDateTime(DateTime.Today),
            SoNgay = 30,
            NgayNghiemThu = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
            LoaiHopDongId = 1,
            GiaTri = 1000000,
            GiaTriBaoLanh = 0
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/hop-dong/them-moi", model);

        // Assert
        response.Should().BeSuccessful();
        var result = await response.Content.ReadFromJsonAsync<ResultApi<HopDongDto>>();
        result.Should().NotBeNull();
        result!.Result.Should().BeTrue($"Error: {result.ErrorMessage}");
        result.DataResult.Ten.Should().Be("Hợp đồng test");
    }

    [Fact]
    public async Task Delete_NonExistentId_ShouldReturnSuccess()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var response = await _client.DeleteAsync($"api/hop-dong/xoa/{nonExistentId}");

        // Assert - API returns 200 with error message for non-existent IDs
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}