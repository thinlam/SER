using QLHD.Tests.Integration.Infrastructure;

namespace QLHD.Tests.Integration.Controllers;

/// <summary>
/// Integration tests for KeHoachKinhDoanhNamController.
/// Tests CRUD operations with child collections (BoPhan, CaNhan).
/// </summary>
public class KeHoachKinhDoanhNamControllerTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly TestWebApplicationFactory _factory;

    public KeHoachKinhDoanhNamControllerTests(TestWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    #region Create Tests

    [Fact]
    public async Task Create_ShouldReturnOkAndEntity_WhenModelIsValid()
    {
        // Arrange
        var model = new KeHoachKinhDoanhNamInsertModel
        {
            BatDau = DateOnly.FromDateTime(DateTime.Today),
            KetThuc = DateOnly.FromDateTime(DateTime.Today.AddYears(1)),
            GhiChu = "Test plan"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/ke-hoach-kinh-doanh-nam/them-moi", model);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        result.Should().NotBeNull();
        result!.Result.Should().BeTrue();
        result.DataResult.Should().NotBeNull();
        result.DataResult!.BatDau.Should().Be(model.BatDau);
    }

    [Fact]
    public async Task Create_ShouldReturnError_WhenBatDauIsMissing()
    {
        // Arrange
        var model = new { GhiChu = "Test" }; // Missing required BatDau

        // Act
        var response = await _client.PostAsJsonAsync("/api/ke-hoach-kinh-doanh-nam/them-moi", model);

        // Assert - API returns 200 OK with Result=false for validation errors
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi>();
        result.Should().NotBeNull();
        result!.Result.Should().BeFalse();
    }

    [Fact]
    public async Task Create_ShouldCreateChildCollections_WhenProvided()
    {
        // Arrange
        var model = new KeHoachKinhDoanhNamInsertModel
        {
            BatDau = DateOnly.FromDateTime(DateTime.Today),
            KetThuc = DateOnly.FromDateTime(DateTime.Today.AddYears(1)),
            GhiChu = "Test with children",
            BoPhans = new List<KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel>
            {
                new()
                {
                    DonViId = 1,
                    DoanhKySo = 100000,
                    LaiGopKy = 10000,
                    DoanhSoXuatHoaDon = 80000,
                    LaiGopXuatHoaDon = 8000,
                    ThuTien = 50000,
                    LaiGopThuTien = 5000,
                    ChiPhiTrucTiep = 5000,
                    ChiPhiPhanBo = 2000,
                    LoiNhuan = 10000
                }
            },
            CaNhans = new List<KeHoachKinhDoanhNam_CaNhanInsertOrUpdateModel>
            {
                new()
                {
                    UserPortalId = 1,
                    DoanhKySo = 50000,
                    LaiGopKy = 5000,
                    DoanhSoXuatHoaDon = 40000,
                    LaiGopXuatHoaDon = 4000,
                    ThuTien = 25000,
                    LaiGopThuTien = 2500,
                    ChiPhiTrucTiep = 2500,
                    ChiPhiPhanBo = 1000,
                    LoiNhuan = 5000
                }
            }
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/ke-hoach-kinh-doanh-nam/them-moi", model);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        result!.DataResult!.BoPhans.Should().NotBeNull().And.HaveCount(1);
        result.DataResult.CaNhans.Should().NotBeNull().And.HaveCount(1);
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_ShouldReturnOkAndUpdatedEntity_WhenModelIsValid()
    {
        // Arrange - Create first
        var createModel = new KeHoachKinhDoanhNamInsertModel
        {
            BatDau = DateOnly.FromDateTime(DateTime.Today),
            KetThuc = DateOnly.FromDateTime(DateTime.Today.AddYears(1)),
            GhiChu = "Original note"
        };
        var createResponse = await _client.PostAsJsonAsync("/api/ke-hoach-kinh-doanh-nam/them-moi", createModel);
        var createResult = await createResponse.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        var createdId = createResult!.DataResult!.Id;

        // Act - Update
        var updateModel = new KeHoachKinhDoanhNamUpdateModel
        {
            BatDau = DateOnly.FromDateTime(DateTime.Today),
            KetThuc = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
            GhiChu = "Updated note"
        };
        var updateResponse = await _client.PutAsJsonAsync($"/api/ke-hoach-kinh-doanh-nam/cap-nhat/{createdId}", updateModel);

        // Assert
        updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var updateResult = await updateResponse.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        updateResult!.DataResult!.GhiChu.Should().Be("Updated note");
    }

    [Fact]
    public async Task Update_ShouldReturnError_WhenEntityDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        var updateModel = new KeHoachKinhDoanhNamUpdateModel { BatDau = DateOnly.FromDateTime(DateTime.Today) };

        // Act
        var response = await _client.PutAsJsonAsync($"/api/ke-hoach-kinh-doanh-nam/cap-nhat/{nonExistentId}", updateModel);

        // Assert - API returns 200 OK with Result=false for non-existent entity
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi>();
        result.Should().NotBeNull();
        result!.Result.Should().BeFalse();
    }

    #endregion

    #region GetList Tests

    [Fact]
    public async Task GetList_ShouldReturnSuccess()
    {
        // Act
        var response = await _client.GetAsync("/api/ke-hoach-kinh-doanh-nam/danh-sach");

        // Assert
        response.Should().BeSuccessful();
    }

    [Fact]
    public async Task GetList_ShouldReturnPaginatedList()
    {
        // Act
        var response = await _client.GetAsync("/api/ke-hoach-kinh-doanh-nam/danh-sach");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi<PaginatedList<KeHoachKinhDoanhNamDto>>>();
        result.Should().NotBeNull();
        result!.DataResult.Should().NotBeNull();
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_NonExistentId_ShouldReturnError()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var response = await _client.GetAsync($"/api/ke-hoach-kinh-doanh-nam/chi-tiet/{nonExistentId}");

        // Assert - API returns 200 OK with Result=false for non-existent entity
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi>();
        result.Should().NotBeNull();
        result!.Result.Should().BeFalse();
    }

    [Fact]
    public async Task GetById_ShouldIncludeChildCollections_WhenEntityExists()
    {
        // Arrange - Create entity with children
        var createModel = new KeHoachKinhDoanhNamInsertModel
        {
            BatDau = DateOnly.FromDateTime(DateTime.Today),
            KetThuc = DateOnly.FromDateTime(DateTime.Today.AddYears(1)),
            GhiChu = "Test with children",
            BoPhans = new List<KeHoachKinhDoanhNam_BoPhanInsertOrUpdateModel>
            {
                new() { DonViId = 1, LoiNhuan = 10000 }
            },
            CaNhans = new List<KeHoachKinhDoanhNam_CaNhanInsertOrUpdateModel>
            {
                new() { UserPortalId = 1, LoiNhuan = 5000 }
            }
        };
        var createResponse = await _client.PostAsJsonAsync("/api/ke-hoach-kinh-doanh-nam/them-moi", createModel);
        var createResult = await createResponse.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        var createdId = createResult!.DataResult!.Id;

        // Act
        var response = await _client.GetAsync($"/api/ke-hoach-kinh-doanh-nam/chi-tiet/{createdId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        result!.DataResult!.BoPhans.Should().NotBeNull().And.HaveCount(1);
        result.DataResult.CaNhans.Should().NotBeNull().And.HaveCount(1);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_NonExistentId_ShouldReturnError()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var response = await _client.DeleteAsync($"/api/ke-hoach-kinh-doanh-nam/xoa/{nonExistentId}");

        // Assert - API returns 200 OK with Result=false for non-existent entity
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<ResultApi>();
        result.Should().NotBeNull();
        result!.Result.Should().BeFalse();
    }

    [Fact]
    public async Task Delete_ShouldReturnOk_WhenEntityExists()
    {
        // Arrange - Create entity
        var createModel = new KeHoachKinhDoanhNamInsertModel
        {
            BatDau = DateOnly.FromDateTime(DateTime.Today),
            GhiChu = "To be deleted"
        };
        var createResponse = await _client.PostAsJsonAsync("/api/ke-hoach-kinh-doanh-nam/them-moi", createModel);
        var createResult = await createResponse.Content.ReadFromJsonAsync<ResultApi<KeHoachKinhDoanhNamDto>>();
        var createdId = createResult!.DataResult!.Id;

        // Act
        var deleteResponse = await _client.DeleteAsync($"/api/ke-hoach-kinh-doanh-nam/xoa/{createdId}");

        // Assert
        deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Verify deleted - API returns 200 OK with Result=false for non-existent entity
        var getResponse = await _client.GetAsync($"/api/ke-hoach-kinh-doanh-nam/chi-tiet/{createdId}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        var getResult = await getResponse.Content.ReadFromJsonAsync<ResultApi>();
        getResult.Should().NotBeNull();
        getResult!.Result.Should().BeFalse();
    }

    #endregion
}