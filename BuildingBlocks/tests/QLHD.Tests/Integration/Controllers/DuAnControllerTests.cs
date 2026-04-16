using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for DuAnController.
/// Note: DuAn has complex dependencies (DmDonVi, DanhMucNguoiPhuTrach, etc.)
/// Full CRUD tests require extensive seed data.
/// </summary>
public class DuAnControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;

    public DuAnControllerTests(TestWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        // Act
        var response = await _client.GetAsync("api/du-an/danh-sach");

        // Assert
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnSuccess()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var response = await _client.GetAsync($"api/du-an/chi-tiet/{nonExistentId}");

        // Assert - API returns 200 with error message for non-existent IDs
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Delete_NonExistentId_ShouldReturnSuccess()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var response = await _client.DeleteAsync($"api/du-an/xoa/{nonExistentId}");

        // Assert - API returns 200 even for non-existent IDs (ResultApi.Fail)
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}